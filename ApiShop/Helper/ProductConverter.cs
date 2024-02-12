using ApiShop.Context;
using ApiShop.Dto;
using ApiShop.Model;

namespace ApiShop.Helper
{
    public class ProductConverter
    {      
        public static Product ConvertorProducts(ShopContext shopContext, ProductDto productDto)
        {
            var product = (from p in shopContext.Products
                           select new Product
                           {
                               ProductArticleNumber = productDto.ProductArticleNumber,
                               ProductName = productDto.ProductName,
                               ProductDescription = productDto.ProductDescription,
                               ProductCategory = shopContext.Categories.Where(x => x.NameCategory == productDto.ProductCategory).Select(x => x.IdCategory).First(),
                               ProductCost = productDto.ProductCost,
                               ProductDiscountAmount = productDto.ProductDiscountAmount,
                               ProductManufacturer = productDto.ProductManufacturer,
                               ProductPhoto = productDto.ProductPhoto,
                               ProductProvider = productDto.ProductProvider,
                               ProductQuantityInStock = productDto.ProductQuantityInStock,
                               ProductSale = productDto.ProductSale,
                               ProductStatus = productDto.ProductStatus,
                               ProductUnit = productDto.ProductUnit,
                           }).First();

            return product;
        }
    }
}
