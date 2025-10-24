namespace ScanEat.Application.DTOs.Order
{
    public class UpdateOrderStatusDto
    {
        public Guid TenantId { get; set; }
        public string Status { get; set; } = default!;
    }
}
