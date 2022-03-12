using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using otopark.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using otopark.Business.Abstract;
using otopark.Entities.Concrete;

namespace otopark.UI.Controllers
{
    public class HomeController : Controller
    {
        #region services
        private ICarParkService _carParkService;
        private IRecordService _recordService;
        private IRoleService _roleService;
        private IUserService _userService;
        private IVehicleService _vehicleService;
        #endregion

        //Constructor
        public HomeController(ICarParkService  carParkService , IRecordService recordService, IRoleService roleService, IUserService userService, IVehicleService vehicleService)
        {
            _carParkService = carParkService;
            _recordService = recordService;
            _roleService= roleService;
            _userService = userService;
            _vehicleService= vehicleService;
        }


        private int selectedParkId = 1; //default olarak id 1 olan park yerini getiriyoruz ileride ihtiyaca göre değiştirilebilir...

        //Ana sayfa
        public IActionResult Index()
        {
            CarPlateViewModel model = new CarPlateViewModel
            {
               // park = _carParkService.GetById(selectedParkId).Data, 
                park=_carParkService.GetAll().Data.LastOrDefault(), 
                isRecordAdded = false,
                vehiclePlate = "",
                vehicleLoginTime = new DateTime(),
                Message = "",
            };
            return View(model);
        }

        
        // giriş çıkış işlemi
        [HttpPost]
        public IActionResult Index(CarPlateViewModel model)
        {
            model.park = _carParkService.GetById(selectedParkId).Data;
            //Ekleme kontrol işlemleri burada yapılacak
            if (!ModelState.IsValid)
            {
                CarPlateViewModel errorModel = new CarPlateViewModel
                {
                    isRecordAdded = false,
                    vehiclePlate = "",
                    vehicleLoginTime = new DateTime(),
                    Message = "Hatalı plaka girişi"
                }; 
                return View(errorModel);
            }

            int onLineRecords = _recordService.GetOnlineRecordCountByParkId(selectedParkId).Data == null ?  0 : _recordService.GetOnlineRecordCountByParkId(selectedParkId).Data;
            if (model.park.Capacity >= onLineRecords ) 
            {
                // ekleme işlemi
                // kayıt ekleme işlemi 
                string plate = convertToPlate(model.CarPlateProperties.carPlateCityArea,
                    model.CarPlateProperties.carPlateTextArea, model.CarPlateProperties.carPlateNumberArea);

                var vehicle = _vehicleService.GetByPlate(plate).Data;

                if (vehicle == null)
                {
                    _vehicleService.Add(new Vehicle { Plate = plate });
                }

                _recordService.Add(new Record { CarParkId = selectedParkId, State = true, LoginTime = DateTime.Now,ExitTime = DateTime.Now, VehicleId = _vehicleService.GetByPlate(plate).Data.Id });
                var record = _recordService.GetAll().Data.LastOrDefault();

                CarPlateViewModel successModel = new CarPlateViewModel
                {
                    isRecordAdded = true,
                    vehiclePlate = vehicle.Plate,
                    vehicleLoginTime = record.LoginTime,
                    Message = $" {vehicle.Plate} plakalı araç başarıyla kaydedildi."
                };
                return View(successModel);
            }
            else
            {
                // park yeri dolu uyarısı
                CarPlateViewModel errorModel = new CarPlateViewModel
                {
                    isRecordAdded = false,
                    vehiclePlate = "",
                    vehicleLoginTime = new DateTime(),
                    Message = "Park Kapasitesi Dolu!"
                };
                return View(errorModel);
            }

          
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


        private string convertToPlate(int city, string text, int num)
        {
            return city.ToString() + text + num.ToString();
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

