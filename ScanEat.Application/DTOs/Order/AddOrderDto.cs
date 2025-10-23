namespace ScanEat.Application.DTOs.Order
{
    public class AddOrderDto
    {
        public Guid TenantId { get; set; }
        public Guid CustomerId { get; set; }
        public List<AddOrderItemDto> Items { get; set; } = new();
    }
}
