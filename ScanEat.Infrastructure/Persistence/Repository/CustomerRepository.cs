using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using ScanEat.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Infrastructure.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            return customer;
        }
    }
}
