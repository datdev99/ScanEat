using MediatR;
using ScanEat.Application.DTOs.Customer;
using ScanEat.Domain.Entities;
using ScanEat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanEat.Application.Features.Commands
{
    public record CreateCustomerCommand(AddCustomerDto customer) : IRequest<Customer>;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        // In a real application, you would inject your DbContext or repository here
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Here you would add logic to save the customer to the database
            // For demonstration, we will just create a new Customer object
            var newCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = request.customer.FullName,
                Phone = request.customer.Phone,
                TenantId = request.customer.TenantId
            };
            
            var result = await _customerRepository.AddCustomerAsync(newCustomer);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
