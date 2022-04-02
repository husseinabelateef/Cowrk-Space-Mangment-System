using BarcodeLib;
using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
        public IActionResult FinalDelete(Guid id)
        {
            ProductRepository.Delete(id);
            return RedirectToAction("GetAllProducts");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Product Product = new Product();
            return View("Add", Product);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Save(Product Product)
        {
            if (ModelState.IsValid)
            {
                // Create an instance of the API
                Barcode barcodeAPI = new Barcode();

                // Define basic settings of the image
                int imageWidth = Product.Id.ToString().Length * 40;
                int imageHeight =120;
                Color foreColor = Color.Black;
                Color backColor = Color.Transparent;

                // Generate the barcode with your settings
                Image barcodeImage = barcodeAPI.Encode(TYPE.CODE128, Product.Id.ToString(), foreColor, backColor, imageWidth, imageHeight);

                // Store image in some path with the desired format
                //Change This Path before You Test
                barcodeImage.Save(@"C:\Users\h.Embaby\source\repos\Cowrk-Space-Mangment-System\wwwroot\Images\" + Product.Name + ".png", ImageFormat.Png);
                Product.BarCode = Product.Name + ".png";

                ProductRepository.Insert(Product);
                return RedirectToAction("GetAllProducts");
            }
            return View("Add",Product);
        }


    }
}
