using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using otopark.Business.Abstract;
using otopark.UI.Models;

namespace otopark.UI.Controllers
{
    public class LoginController : Controller
    {
        private IRoleService _roleService;
        private IUserService _userService;

        public LoginController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //Hatalı veri girişi
                return View();
            }

            // doğrulanmış giriş

            var users = _userService.GetAll().Data;
            foreach (var user in users)
            {
                if (user.Name == model.userName && user.Password == model.Password)
                {
                    // giriş başarılı   
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Name == model.userName && user.Password != model.Password)
                {
                    // hatalı şifre   
                    return View();
                }
                else
                {
                    //kullanıcı bulunamadı
                    return View();
                }
            }

            return View();
        }

    }
}
