using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.Models;
using System.Collections.Generic;
using QRCoder;
using System.Drawing.Imaging;
using System;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace Cowrk_Space_Mangment_System.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {

        //Client/SaveEditClient
        IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepo)
        {
            this.clientRepository = clientRepo;
        }
        // GET: ClientController1
        public ActionResult GetAllClients()
        {
            List<Client> clinets = clientRepository.GetAll();
            return View(clinets);   
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ShowDetails(id);
            return View();
        }

        // GET: ClientController1/Details/5
        [HttpPost]
        public IActionResult ShowDetails(int id)
        {
            Client client = clientRepository.GetById(id);
            if (client.QR_Code != null) {
                using (MemoryStream ms = new MemoryStream())
                {
               
                    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qRCodeGenerator.CreateQrCode(client.QR_Code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    using (Bitmap bitmap = qrCode.GetGraphic(20))
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        //bitmap.Save("F:\\ITI\\Asp.net Core Web Api\\Project\\" + client.QR_Code + ".png", ImageFormat.Png);
                        bitmap.Save(@"C:\Users\h.Embaby\source\repos\Cowrk-Space-Mangment-System\wwwroot\Images\" + client.QR_Code + ".png", ImageFormat.Png);
                        ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return View(client);
        }

        // GET: ClientController1/Create
        public ActionResult NewClient()
        {
            
            return View(new Client());
        }

        // POST: ClientController1/Create
        [HttpPost]
        public ActionResult SaveNewClient(Client client)
        {

            if (client.Name!=null && client.phone !=null && client.Profession!=null && client.Faculty!=null)
            {
                clientRepository.Insert(client);
                return RedirectToAction("GetAllClients");
            }
            return View("NewClient", client);
        }

      
        public ActionResult EditClient(int id)
        {
            Client client = clientRepository.GetById(id);

            return View(client);
        }

        [HttpPost]
       
        public ActionResult SaveEditClient(int id , Client client)
        {

            if (ModelState.IsValid == true)
            {
           
                clientRepository.Update(id, client);
                return RedirectToAction("GetAllClients");
            }
          
            return View("EditClient", client);
        }

      
        public ActionResult DeleteClient(int id)
        {

            Client client = clientRepository.GetById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult SaveDeleteClient(int id)
        {
           
                clientRepository.Delete(id);
                return RedirectToAction("GetAllClients");
           
           
        }
    }
}
