using System.Collections.Generic;
namespace Testing.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class ProductSource : IDataSource
    {
        public IEnumerable<Product> Products { get; }

        public ProductSource(IEnumerable<Product> Source) => Products = Source;
        
    }
}