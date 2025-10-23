namespace ScanEat.Application.DTOs.Tenant
{
    public class AddTenantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
    }
}
