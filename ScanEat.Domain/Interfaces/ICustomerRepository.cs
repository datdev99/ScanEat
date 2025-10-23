using ScanEat.Domain.Entities;

namespace ScanEat.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        // Define methods for customer data access here
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}
