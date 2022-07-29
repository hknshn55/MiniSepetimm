namespace MiniSepetim.UI.Models
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string Paths { get; set; }
        public string CategoryName { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
