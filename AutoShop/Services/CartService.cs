using Data.Entities;
using Data;
using Shop.Helpers;

namespace Shop.Services
{
    public interface ICartService
    {
        void Add(int id);

        void Remove(int id);
        bool IsInCart(int id);
        void RemoveAll();
      
        int GetCount();
        IEnumerable<Product> GetAll();
    }
    public class CartService : ICartService
    {
        private readonly ShopDbContextcs context;
        private readonly HttpContext httpContext;

        public CartService(ShopDbContextcs contextcs, IHttpContextAccessor accessor)
        {
            this.context = contextcs;
            this.httpContext = accessor.HttpContext;
        }
        public void Add(int id)
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null)
                ids = new List<int>();

            ids.Add(id);

            // save
            httpContext.Session.Set("cartData", ids);
        }

        public IEnumerable<Product> GetAll()
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null) return new List<Product>();

            // get products by id collection
            var products = ids.Select(id => context.Products.Find(id)).ToList();
            return products;
        }

    

        public void Remove(int id)
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null) return;

            ids.Remove(id);

            // save
            httpContext.Session.Set("cartData", ids);
        }
        public int GetCount()
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null) return 0;

            return ids.Count;
        }

        public bool IsInCart(int id)
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null) return false;

            return ids.Contains(id);
        }
        public void RemoveAll()
        {
            List<int>? ids = httpContext.Session.Get<List<int>>("cartData");
            if (ids == null)
            {
                ids = new List<int>();
            }
            ids.Clear();
            httpContext.Session.Set("cartData", ids);
            
        }


    }
}
