using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using otopark.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace otopark.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CarPlateViewModel model = new CarPlateViewModel
            {

                isRecordAdded = false,
                vehiclePlate = "",
                vehicleLoginTime = new DateTime(),
                errorMessage = "Yer yok",
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CarPlateViewModel model)
        {
            //Ekleme kontrol işlemleri burada yapılacak
            if (!ModelState.IsValid)
            {

                CarPlateViewModel errorModel = new CarPlateViewModel
                {
                    isRecordAdded = false,
                    vehiclePlate = "",
                    vehicleLoginTime = new DateTime()
                };
                //hata
                return View(errorModel);
            }
            //onay
            CarPlateViewModel successModel = new CarPlateViewModel
            {
                isRecordAdded = true,
                vehiclePlate = "", //plaka girilecek
                vehicleLoginTime = new DateTime() // kayıt zamanı girilecek
            };
            return View(successModel);
        }

        public IActionResult Pay()
        {
            PayModelView model = new PayModelView
            {
                vehiclheId = 123,
                Plate = "test",
                Price = 13.2, 
                Duration = "süre", 
                LoginTime = new DateTime(2022, 12, 12, 12, 12, 12),
                ExitTime = new DateTime(2022, 12, 12, 12, 12, 12)
            };
            return View(model);
        }

        [HttpPost]
        [Route("Home/Pay/{id?}")]
        public IActionResult Pay(int id)
        {
            
            //ödeme işlemini gerçekleştirir...
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

