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


        public int selectedParkId = 1; //default olarak id 1 olan park yerini getiriyoruz ileride ihtiyaca göre değiştirilebilir...


        //Ana sayfa
        public IActionResult Index()
        {
            CarPlateViewModel model = new CarPlateViewModel
            {
                park = _carParkService.GetById(selectedParkId).Data, 
                isRecordAdded = false,
                vehiclePlate = "",
                vehicleLoginTime = new DateTime(),
                Message = "",
            };
            return View(model);
        }

        
        // Giriş Çıkış işlemleri
        [HttpPost]
        public IActionResult Index(CarPlateViewModel model)
        {
            model.park = _carParkService.GetById(selectedParkId).Data;
            
            
            //Ekleme kontrol işlemleri burada yapılacak herhangi bir hatalı veri girişinde hata mesajı gösterilecek
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

            string plate = convertToPlate(model.CarPlateProperties.carPlateCityArea,
                model.CarPlateProperties.carPlateTextArea, model.CarPlateProperties.carPlateNumberArea);
            
            int onLineRecords = _recordService.GetRecordCountByParkId(selectedParkId).Data;

            var vehicle = _vehicleService.GetByPlate(plate).Data;

            if (vehicle == null)
            {
                _vehicleService.Add(new Vehicle { Plate = plate });
                vehicle = _vehicleService.GetAll().Data.LastOrDefault();
            }


            if ( _recordService.isCarInParkCheck(vehicle.Id).Data )
            {
                // Araç otoparktan çıkış yapma işlemleri
                
                var record = _recordService.RecordByVehicleId(vehicle.Id).Data;
                TimeSpan span = record.ExitTime.Subtract(record.LoginTime);

                record.ExitTime= DateTime.Now;
                record.Duration = Convert.ToInt32(Math.Ceiling(span.TotalHours));
                record.TotalPrice = record.Duration * _carParkService.GetById(selectedParkId).Data.Price;
                _recordService.Update(record);

                //Çıkış bilgilendirme ve onay sayfasına yönlendirilir.
                return RedirectToAction("PayPage", "Home", record);
            }
            else
            {
                
                // Otopark giriş kontrol ve gerçekleştirimi
                if (model.park.Capacity > onLineRecords)
                {
                     

                    // Otoparka giriş kaydının yapılması
                    _recordService.Add(new Record { CarParkId = selectedParkId, State = true, LoginTime = DateTime.Now, ExitTime = DateTime.Now, VehicleId = _vehicleService.GetByPlate(plate).Data.Id });

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
                    // Park kapasitesinin dolu olduğu uyarısı
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
             
        }

        public IActionResult PayPage(Record record)
        {
            PayModelView model = new PayModelView
            {
                vehiclheId = record.VehicleId,
                Plate = _vehicleService.GetById(record.VehicleId).Data.Plate,
                Price = record.TotalPrice, 
                Duration = record.Duration.ToString(), 
                LoginTime = record.LoginTime.ToLongTimeString(),
                ExitTime = record.ExitTime.ToShortDateString()
            };
            return View(model);
        }

        [Route("Home/Pay/{id?}")]
        public IActionResult Pay(int id)
        {
            var record  = _recordService.RecordByVehicleId(id).Data;
            record.State = false;
            _recordService.Update(record);
            //ödeme işlemini gerçekleştirir...
            return RedirectToAction("Index","Home");
        }

        private string convertToPlate(int city, string text, int num)
        {
            return city.ToString() + text + num.ToString();
        }
         
    }
}

