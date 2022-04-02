using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class ClientController : Controller
    {

        IClientRepository clientRepository;
        public ClientController(IClientRepository ClientRepo)
        {
            clientRepository = ClientRepo;
        }

        //Client/GetAllClients
        public IActionResult GetAllClients()

        {
            List<Client> clients = clientRepository.GetAll();
            return View(clients);
        }

        public ActionResult Details(int id)
        {

            Client client = clientRepository.GetById(id);
            return View(client);
        }

        public IActionResult NewClient()
        {
            return View(new Client());
        }
        [HttpPost]
        public IActionResult SaveNewClient(Client client)
        {
            if (client.Name != null && client.Profession != null && client.phone != null && client.Faculty != null)
            {
                clientRepository.Insert(client);
                return RedirectToAction("GetAllClients");
            }

            return View("NewClient",client);

        }
        

        [HttpGet]
        public IActionResult GenerateQRcode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerateQRcode(string qrcode)
        {

            using (MemoryStream ms = new MemoryStream())
            {

                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qRCodeGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitmap = qrCode.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    bitmap.Save("F:\\ITI\\Asp.net Core Web Api\\Project\\Test.png", ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }

        // For Scanning Use Sacn-IT to Office application
    }
}
