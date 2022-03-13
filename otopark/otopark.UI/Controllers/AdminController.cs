using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using otopark.Business.Abstract;
using otopark.Entities.Concrete;
using otopark.UI.Models.Admin;

namespace otopark.UI.Controllers
{
    public class AdminController : Controller
    {
        #region services
        private ICarParkService _carParkService;
        private IRecordService _recordService;
        private IRoleService _roleService;
        private IUserService _userService;
        private IVehicleService _vehicleService;
        #endregion

        //Constructor
        public AdminController(ICarParkService carParkService, IRecordService recordService, IRoleService roleService, IUserService userService, IVehicleService vehicleService)
        {
            _carParkService = carParkService;
            _recordService = recordService;
            _roleService = roleService;
            _userService = userService;
            _vehicleService = vehicleService;
        }

        public int selectedParkId = 1; //default olarak id 1 olan park yerini getiriyoruz ileride ihtiyaca göre değiştirilebilir...

        public IActionResult Index()
        {
            AdminIndexModel model = new AdminIndexModel
            {
                capacity = _carParkService.GetById(selectedParkId).Data.Capacity,
                carParkTimePrice = _carParkService.GetById(selectedParkId).Data.Price,
                currentVehicleCount = _recordService.GetRecordCountByParkId(selectedParkId).Data,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(decimal carParkTimePrice, int capacity)
        {
            var carPark = _carParkService.GetById(selectedParkId);

            if (capacity < _recordService.GetAllOnlineRecords().Data.Count)
            {
                ViewBag.Message = "Güncelleme hatası..";
                return RedirectToAction("Index", "Admin");
            }
            carPark.Data.Price = carParkTimePrice;
            carPark.Data.Capacity = capacity;
            _carParkService.Update(carPark.Data);
            ViewBag.Message = "Başarıyla güncellendi..";
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult AllRecords()
        {
            AllRecordsModel model = new AllRecordsModel();
            model.records = new List<AdminRecordModel>();
            var records = _recordService.GetAll().Data.Where(r => r.CarParkId == selectedParkId && r.State == false)
                .ToList();
            foreach (var record in records)
            {
                 model.records.Add(new AdminRecordModel
                 {
                     plate = _vehicleService.GetById(record.VehicleId).Data.Plate,
                     duration = record.Duration.ToString(),
                     loginTime = record.LoginTime.ToString(),
                     exitTime = record.ExitTime.ToString(),
                     totalPrice = record.TotalPrice.ToString()
                 });
            };
            return View(model);
        }
        public IActionResult AllRecordsSortAsc()
        {

            // sıralanmış şekilde kayıtları getirir
            AllRecordsModel model = new AllRecordsModel();
            model.records = new List<AdminRecordModel>();
            var records = _recordService.GetAll().Data.Where(r => r.CarParkId == selectedParkId && r.State == false).OrderByDescending(r=>r.TotalPrice)
                .ToList();
            foreach (var record in records)
            {
                model.records.Add(new AdminRecordModel
                {
                    plate = _vehicleService.GetById(record.VehicleId).Data.Plate,
                    duration = record.Duration.ToString(),
                    loginTime = record.LoginTime.ToString(),
                    exitTime = record.ExitTime.ToString(),
                    totalPrice = record.TotalPrice.ToString()
                });
            };
            return View(model);
        }

    }
}
