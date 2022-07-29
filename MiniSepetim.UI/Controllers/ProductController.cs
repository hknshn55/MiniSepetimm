using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using MiniSepetim.Entities.Dtos.OrderDtos;
using MiniSepetim.Entities.Dtos.ProductDtos;
using MiniSepetim.UI.Models;
using MiniSepetim.UI.Models.Basket;
using MiniSepetim.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSepetim.UI.Models.ImageTools;

namespace MiniSepetim.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthService _authService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IPictureService _pictureService;
        private readonly IBasketService _basketService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IOrderDetailService orderDetailService, IPictureService pictureService, IAuthService authService, IBasketService basketService, ICategoryService categoryService, IMapper mapper, IOrderService orderService)
        {
            _productService = productService;
            _orderDetailService = orderDetailService;
            _pictureService = pictureService;
            _authService = authService;
            _basketService = basketService;
            _categoryService = categoryService;
            _mapper = mapper;
            _orderService = orderService;
        }






        [Authorize(Roles = "Seller,Admin,Customer")]
        public async Task<IActionResult> Index()
        {
            var productList = await _productService.ProductPictureList();

            return View(productList);
        }







        [Authorize(Roles = "Seller,Admin,Customer")]
        [HttpPost]
        public async Task<IActionResult> Index(string shortBy)
        {
            //bu işlemler iş katmanında yapılabilir. Proje bitiminde düzenlenecek.
            var productList = await _productService.ProductPictureList();
            var maxProductList = await _productService.ProductShortByMaxPrice();
            var minProductList = await _productService.ProductShortByMinPrice();
            switch (shortBy)
            {
                case "Yüksek fiyata göre sırala": return View(maxProductList);
                case "Düşük fiyata göre sırala": return View(minProductList);
                default: return View(productList);
            }
        }







        public async Task<IActionResult> Basket()
        {
            List<BasketItem> basketItems = _basketService.GetBasket(User.Identity.Name);
            
            if (basketItems != null && basketItems.Count > 0)
            {
                var productImages = await _pictureService.PictureList();
                basketItems.ForEach(x =>
                {
                    x.Paths = productImages.SingleOrDefault(y => y.ProductId == x.ProductId).Name;
                });
                return View(basketItems);
            }
            return RedirectToAction("Index");
        }








        [Authorize(Roles = "Seller,Customer")]
        [HttpGet]
        public async Task<IActionResult> BasketAdd(int productId)
        {
            Product product = await _productService.GetProductDetailsByProductId(productId);

            if (product != null && product.UnitInStock > 0)
            {
                BasketItem basketItem = new BasketItem();
                basketItem.ProductId = product.Id;
                basketItem.ProductName = product.Name;
                basketItem.Price = product.Price;
                basketItem.SellerName = product.Seller.Name;
                basketItem.CategoryName = product.Category.Name;
                
                basketItem.Count = product.UnitInStock - (product.UnitInStock - 1);
                _basketService.AddBasket(basketItem, User.Identity.Name);

                //Normalde sipariş onaylandığında veri tabanından 1 eksiltilmeli
                //Siparişi onaylama alanı yaparsan burayı unutma!
                product.UnitInStock = product.UnitInStock - 1;
                await _productService.ProductUpdate(product);
            }

            return RedirectToAction("Index");
        }








        [HttpGet]
        public async Task<IActionResult> AcceptBasket()
        {
            List<BasketItem> basketItem = _basketService.GetBasket(User.Identity.Name); //Sepet
            AppIdentityUser user = await _authService.GetUser(User.Identity.Name); //Müşteri
            OrderDto orderDto = new OrderDto { CustomerId = user.Id, State = true };
            foreach (var item in basketItem) //Sepetin içindeki ürünler
            {
                Product product = await _productService.GetProductById(item.ProductId); //Her bir ürünün kontrolü
                if (product is not null)
                {

                    await _productService.ProductUpdate(product);
                    orderDto.OrderDetails.Add(new OrderDetail { ProductId = product.Id, Count = item.Count, State = true, UnitPrice = product.Price });
                }
            }

            await _orderService.OrderAdd(orderDto);
            _basketService.RemoveCookie("Basket", User.Identity.Name);

            return RedirectToAction("Index");
        }








        [Authorize(Roles = "Seller,Customer")]
        [HttpGet]
        public async Task<IActionResult> BasketDelete(int productId, int count)
        {
            var product = await _productService.GetProductById(productId);
            product.UnitInStock += count;
            await _productService.ProductUpdate(product);

            _basketService.RemoveBasket(productId, User.Identity.Name);


            return RedirectToAction("Basket");
        }







        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.ProductDetail(id);
            return View(product);
        }








        [Authorize(Roles = "Seller")]
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            AddProductVM addProductVM = new AddProductVM();
            var categoryList = await _categoryService.GetListCategory();

            List<CategoryNameDto> categoryNameListDto = new List<CategoryNameDto>();

            foreach (var item in categoryList)
            {
                categoryNameListDto.Add(new CategoryNameDto { CategoryId = item.Id, CategoryName = item.Name });
            }

            addProductVM.Categories = categoryNameListDto;

            return View(addProductVM);
        }









        [Authorize(Roles = "Seller")]
        [HttpPost]

        public async Task<IActionResult> AddProduct(AddProductVM addProductVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Lütfen ilgili alanları doldurunuz!");
                return View(addProductVM);
            }
            //İş katmanına bir uğramak lazım burası fazlasıyla şişti kesinlikle unutma!
            AppIdentityUser user = await _authService.GetUser(User.Identity.Name);
            var category = await _categoryService.GetCategoryByName(addProductVM.CategoryName);

            if (addProductVM.Path==null||user==null||category==null)
            {
                ModelState.AddModelError("", "Geçerli bir veri girmediniz");
                List<CategoryNameDto> categoryNameDtos = (await _categoryService.GetListCategory()).Select(x => new CategoryNameDto { CategoryName = x.Name }).ToList();
                addProductVM.Categories = categoryNameDtos;
                return View(addProductVM);
            }

            string imageBase64Code=await addProductVM.Path.ConvertToBase64();

            var productDto = new ProductDto { SellerId = user.Id, CategoryId = category.Id, Name = addProductVM.Name, Price = addProductVM.Price, Description = addProductVM.Description, State = addProductVM.State, Path = imageBase64Code, Count=addProductVM.Count };


            await _productService.ProductAdd(productDto);
            return RedirectToAction("Index");
        }







        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.ProductDeleteById(id);
            var role = (string)TempData["Role"];
            if (role == "Seller")
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("MyProduct", "Seller");
        }
    }
}
