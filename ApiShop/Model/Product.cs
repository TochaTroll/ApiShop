using System;
using System.Collections.Generic;

namespace ApiShop.Model;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;
    
    public string ProductDescription { get; set; } = null!;

    public int ProductCategory { get; set; }

    public string ProductManufacturer { get; set; } = null!;

    public string ProductProvider { get; set; } = null!;

    public string? ProductPhoto { get; set; }

    public decimal ProductCost { get; set; }

    public string ProductUnit { get; set; } = null!;

    public byte? ProductDiscountAmount { get; set; }

    public byte? ProductSale { get; set; }

    public int ProductQuantityInStock { get; set; }

    public string? ProductStatus { get; set; }

    public virtual Category ProductCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
