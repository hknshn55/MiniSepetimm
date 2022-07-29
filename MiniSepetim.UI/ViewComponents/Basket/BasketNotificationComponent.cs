using Microsoft.AspNetCore.Mvc;
using MiniSepetim.UI.Models;
using MiniSepetim.UI.Models.Basket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniSepetim.UI.ViewComponents.Basket
{
    public class BasketNotificationComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public BasketNotificationComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketItem> basket = new List<BasketItem>();
            basket = _basketService.GetBasket(User.Identity.Name);
            if (basket != null)
            {
                if (basket.Count > 0)
                {


                    int count = 0;
                    foreach (var item in basket)
                    {
                        count += item.Count;
                    }
                    return View(count);
                }

            }

            return View(0);
        }
    }
}
