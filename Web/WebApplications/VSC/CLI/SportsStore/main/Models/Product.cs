using System.ComponentModel.DataAnnotations.Schema;
namespace SportsStore.Models
{
    class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "new decimal(2,8)")]
        public decimal Price { get; set; }
    }
}