namespace ApiShop.Dto
{
    public class ProductDto
    {
        public string ProductArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string ProductCategory { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;

        public string ProductManufacturer { get; set; } = null!;

        public string ProductProvider { get; set; } = null!;

        public string? ProductPhoto { get; set; }

        public decimal ProductCost { get; set; }

        public string ProductUnit { get; set; } = null!;

        public byte? ProductDiscountAmount { get; set; }

        public byte? ProductSale { get; set; }

        public int ProductQuantityInStock { get; set; }

        public string? ProductStatus { get; set; }
       
    }
}
