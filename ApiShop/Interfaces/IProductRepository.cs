using ApiShop.Dto;
using ApiShop.Model;

namespace ApiShop.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();   
        Task<ICollection<Product>> GetProductsByName (string name);
        Task<ICollection<Product>> GetProductsByManufacturer(string manufacturer);
        Task<ICollection<Product>> GetProductsByProvider(string provider);
        Task<ICollection<Product>> GetProductsByCategory(string category);
        Task <Product> GetProductByArticle(string article);
        Task<bool> CreateProduct (Product product);
        Task<bool> SaveProduct();



    }
}
