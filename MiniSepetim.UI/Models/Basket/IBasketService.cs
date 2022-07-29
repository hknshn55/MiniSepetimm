using System.Collections.Generic;

namespace MiniSepetim.UI.Models.Basket
{
    public interface IBasketService
    {
        List<BasketItem> GetBasket(string userName);
        void AddBasket(BasketItem item,string userName);
        void RemoveBasket(int basketItemId,string userName);
        void RemoveCookie(string cookieName, string userName);


    }
}
