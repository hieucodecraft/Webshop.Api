namespace Webshop.Api.Orders
{
    public class Order : BaseModel
    {
        public decimal TotalPrice { get; set; }
        public List<LineItem> LineItems { get; set; } = new();
    }
}
