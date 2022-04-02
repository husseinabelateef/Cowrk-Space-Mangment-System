using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository ProductRepository;

        public ProductController(IProductRepository _ProductRepository)
        {
            ProductRepository = _ProductRepository;
        }
        public IActionResult GetAllProducts()
        {
            List<Product> Products = ProductRepository.GetAll();
            return View(Products);
        }

        [HttpPost]
        public IActionResult Details(Guid id)
        {
            Product Product = ProductRepository.GetById(id);
            return PartialView("Details", Product);
        }

        [HttpPost]
        public IActionResult Edit(Guid id)
        {
            Product Product = ProductRepository.GetById(id);
            return PartialView("Edit", Product);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Product Product)
        {
            ProductRepository.Update(Product.Id, Product);
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Product Product = ProductRepository.GetById(id);
            return PartialView("Delete", Product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult FinalDelete(Product Product)
        {
            ProductRepository.Delete(Product.Id);
            return RedirectToAction("GetAllProducts");
        }

    }
}
