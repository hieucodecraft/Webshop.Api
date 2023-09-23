namespace Webshop.Api.Products
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
