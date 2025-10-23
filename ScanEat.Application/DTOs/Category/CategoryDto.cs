namespace ScanEat.Application.DTOs.Category
{
    public class CategoryDto
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
