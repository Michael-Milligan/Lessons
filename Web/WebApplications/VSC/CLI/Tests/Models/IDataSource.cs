using System.Collections.Generic;
namespace Testing.Models
{
    public interface IDataSource
    {
        public IEnumerable<Product> Products { get; }
    }
}