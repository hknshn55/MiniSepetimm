using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Entities.Dtos;
using MiniSepetim.Entities.Dtos.RegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSepetim.UI.Controllers
{
 
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _authService.Login(loginDto);
                if (result.Succeeded)
                {
                    var user = _authService.GetUserByEmail(loginDto.Email);
                    var role = await _authService.GetRoleByUserName(user.UserName);
                    switch (role)
                    {
                        case "Customer":
                        case "Seller": return RedirectToAction("Index", "Product");
                        default: return RedirectToAction("Index", "Category");
                    }
                }
                
            }
            
            ModelState.AddModelError("","Lütfen girilen değerleri kontrol ediniz!");
            return View(loginDto);
        }
        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(AdminRegisterDto adminRegisterDto)
        {
            IdentityResult result = await _authService.AdminRegister(adminRegisterDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(adminRegisterDto);
        }
        [HttpGet]
        public IActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            IdentityResult result = await _authService.CustomerRegister(customerRegisterDto);
            if (result.Succeeded) //iş katmanında oluşturma başarılıysa
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(customerRegisterDto);
        }
        [HttpGet]
        public IActionResult SellerRegister()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SellerRegister(SellerRegisterDto sellerRegisterDto)
        {
            IdentityResult result = await _authService.SellerRegister(sellerRegisterDto);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(sellerRegisterDto);
        }
        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
