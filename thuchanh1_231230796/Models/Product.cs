namespace thuchanh1_231230796.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }


        public List<Product> GetProductList ()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, ImageUrl = "/images/products/ncd1.jpg", Name = "Nồi cơm điện cao tần Nagakawa NAG0102" },
                new Product { Id = 2, ImageUrl = "/images/products/ncd1.jpg", Name = "Nồi cơm điện Sunhouse SHD8602" },
                new Product { Id = 3, ImageUrl = "/images/products/ncd1.jpg", Name = "Nồi cơm điện Panasonic SR-CP188" }
            };
            return products;
        }

        public Product GetProductById(int id)
        {
            var products = GetProductList();
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
