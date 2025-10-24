using BootCamp2_6weekEnd.Repository.Base;
using BootCamp2_6weekEnd.Repository.Implement;
using BootCamp2_6weekEnd.Data;
using Microsoft.EntityFrameworkCore;
using BootCamp2_6weekEnd.Interfaces;
using BootCamp2_6weekEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
//  1) إعداد الخدمات
// -------------------------

// إضافة دعم الـ MVC (Controllers + Views)

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();

//  تأكد أن اسم ConnectionString في appsettings.json هو "DefaultConnection" وليس "DefualtConnection"
var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");

  builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

//  تسجيل الـ Repositories في الـ Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));
//builder.Services.AddScoped<IRepoEmployee, RepoEmployee>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

// إضافة Distributed Cache + Session (مطلوبة لتفعيل الـSession)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // مدة بقاء الجلسة
    options.Cookie.HttpOnly = true;                 // يمنع الوصول من JS
    options.Cookie.IsEssential = true;              // ضروري للتطبيق
});

// دعم الوصول إلى HttpContext في أي مكان (اختياري لكنه مفيد)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// -------------------------
//  2) إعداد الـPipeline
// -------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//  لازم Session قبل Authorization
app.UseSession();

app.UseAuthorization();

// تعريف المسار الافتراضي
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

// ✅ تشغيل التطبيق
app.Run();