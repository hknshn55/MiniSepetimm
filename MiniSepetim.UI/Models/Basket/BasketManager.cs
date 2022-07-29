using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MiniSepetim.UI.Models.Basket
{
    public class BasketManager : IBasketService
    {
        private readonly IHttpContextAccessor _httpContext;

        public BasketManager(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void AddBasket(BasketItem item,string userName)
        {

            string cookie = GetCookie("Basket",userName);
            if (!string.IsNullOrEmpty(cookie))
            {
                List<BasketItem> basketList = ConvertObject<BasketItem>(cookie);

                var basket = basketList.FirstOrDefault(x=>x.ProductId==item.ProductId);
                var basketCount = 0;
                if (basket != null)
                {
                    basketCount = basket.Count;
                    basketList.Remove(basket);
                }
                item.Count = basketCount + 1;
                basketList.Add(item);
                
                CreateCookie("Basket", ConvertJson(basketList),userName);
            }
            else
            {
                List<BasketItem> items = new List<BasketItem>();
                items.Add(item);
                CreateBasket(items,userName);
            }

        }
        public void RemoveBasket(int basketItemId,string userName)
        {
            string cookie = GetCookie("Basket",userName);
            if (!string.IsNullOrEmpty(cookie))
            {
                List<BasketItem> basketList = ConvertObject<BasketItem>(cookie);
                BasketItem basketItem = basketList.First(x => x.ProductId == basketItemId);
                basketList.Remove(basketItem);
                CreateCookie("Basket", ConvertJson(basketList),userName);
            }
        }
        public List<BasketItem> GetBasket(string userName)
        {
            string basketList = GetCookie("Basket",userName);
            if (string.IsNullOrEmpty(basketList))
            {
                return null;
            }
            return ConvertObject<BasketItem>(basketList);

        }



        public void CreateBasket(List<BasketItem> basketItems,string userName)
        {
            string cookie = GetCookie("Basket",userName);
            if (string.IsNullOrEmpty(cookie))
            {
                string basketList = ConvertJson<BasketItem>(basketItems);
                CreateCookie("Basket", basketList,userName);
            }
        }

        public void CreateCookie(string key, string value,string userName)
        {
            

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Secure = false;
            cookie.SameSite = SameSiteMode.Strict;

            _httpContext.HttpContext.Response.Cookies.Append(userName+""+key, value, cookie);
        }

        private string GetCookie(string key, string userName)
        {
            return _httpContext.HttpContext.Request.Cookies[userName+""+key];

        }


        public string ConvertJson<T>(List<T> data)
        {
            return JsonConvert.SerializeObject(data);
        }
        public List<T> ConvertObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<List<T>>(value);
        }

        public void RemoveCookie(string cookieName,string userName)
        {
            _httpContext.HttpContext.Response.Cookies.Delete(userName+""+cookieName);
        }
    }
}
