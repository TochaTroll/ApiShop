using System;
using System.Collections.Generic;

namespace ApiShop.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateTime OrderDeliveryDate { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderPickupPoint { get; set; }

    public string OrderComposition { get; set; } = null!;

    public string? FullNameClient { get; set; }

    public int OrderKey { get; set; }

    public virtual PickPoint OrderPickupPointNavigation { get; set; } = null!;

    public virtual ICollection<Product> ProductArticleNumbers { get; set; } = new List<Product>();
}
