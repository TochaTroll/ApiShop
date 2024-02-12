using ApiShop.Context;
using ApiShop.Interfaces;
using ApiShop.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ApiShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ShopContext _shopContext;

        public ProductRepository(ShopContext context)
        {
            _shopContext = context;
        }

        public async Task<ICollection <Product>> GetProductsByName(string name)
        {
            return await _shopContext.Products.Include(p => p.ProductCategoryNavigation).Where(p => p.ProductName == name).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            
             return await _shopContext.Products.Include(p => p.ProductCategoryNavigation).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsByManufacturer(string manufacturer)
        {
            return await _shopContext.Products.Include(p=> p.ProductCategoryNavigation).Where(p => p.ProductManufacturer == manufacturer).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsByProvider(string provider)
        {
           return await _shopContext.Products.Include(p => p.ProductCategoryNavigation).Where(p => p.ProductProvider == provider).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsByCategory(string category)
        {
            return await _shopContext.Products.Include(p => p.ProductCategoryNavigation).Where(p => p.ProductCategoryNavigation.NameCategory == category).ToListAsync();
        }

        public async Task<Product> GetProductByArticle(string article)
        {
            return await _shopContext.Products.Include(p => p.ProductCategoryNavigation).FirstOrDefaultAsync(p => p.ProductArticleNumber == article);
        }

        public async Task<bool> CreateProduct(Product product)
        {
            await _shopContext.Products.AddAsync(product);
            return await SaveProduct();
          
        }

        public async Task<bool> SaveProduct()
        {
            var saved = await _shopContext.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
