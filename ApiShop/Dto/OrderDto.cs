namespace ApiShop.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string OrderStatus { get; set; } = null!;

        public DateTime OrderDeliveryDate { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderPickupPoint { get; set; }

        public string OrderComposition { get; set; } = null!;

        public string? FullNameClient { get; set; }

        public int OrderKey { get; set; }
    }
}
