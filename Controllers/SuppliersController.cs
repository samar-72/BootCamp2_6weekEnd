﻿using BootCamp2_6weekEnd.Filters;
using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Implement;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6weekEnd.Controllers
{
    [SessionAuthourize]
    public class SuppliersController : Controller
    {
        private readonly IRepository<Supplier> _repository;
        public SuppliersController(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        // GET: Suppliers
        public IActionResult Index()
        {
            var Suppliers = _repository.GetAll();

            return View(Suppliers);
        }


        public IActionResult Details(int id)
        {
            var supplier = _repository.GetById(id);

            return View(supplier);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = _repository.GetById(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            _repository.Update(supplier);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = _repository.GetById(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);

        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var supplier = _repository.GetById(id);
            _repository.Delete(supplier);
            return RedirectToAction(nameof(Index));
        }


    }
}