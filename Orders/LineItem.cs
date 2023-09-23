namespace Webshop.Api.Orders
{
    public class LineItem :BaseModel
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
