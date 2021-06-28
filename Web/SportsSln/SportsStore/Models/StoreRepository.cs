using System.Linq;

namespace SportsStore.Models
{
    public class StoreRepository: IStoreRepository
    {
        public StoreRepository(StoreDbContext Context)
        {
            this.Context = Context;
        }
        public StoreDbContext Context { get; set; }
        public IQueryable<Product> Products => Context.Products;
    }
}