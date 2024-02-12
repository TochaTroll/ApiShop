using System;
using System.Collections.Generic;

namespace ApiShop.Model;

public partial class PickPoint
{
    public int IdPickPoint { get; set; }

    public string AdressPickPoint { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
