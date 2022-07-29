using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using MiniSepetim.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSepetim.UI.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISellerService _sellerService;


        public SellerController(IProductService productService, ISellerService sellerService)
        {
            _productService = productService;
            _sellerService = sellerService;
        }

        public async Task< IActionResult> MyProduct()
        {
            var productList = (await _productService.ProductPictureList()).Where(x=>x.SellerUserName == User.Identity.Name);
            
            return View(productList);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetProductById(id);
            
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.ProductUpdate(product);

            return RedirectToAction("MyProduct");
        }
    }
}
