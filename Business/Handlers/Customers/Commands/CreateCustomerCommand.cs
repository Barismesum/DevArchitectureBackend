using Business.BusinessAspects;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Commands
{
    public class CreateCustomerCommand:IRequest<IResult>
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string MobilePhones { get; set; }
        public string Email { get; set; }
        public bool isDeleted { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand,IResult>
        {
            private readonly ICustomerRepository _customerRepository;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            [SecuredOperation(Priority = 1)]
            public async Task<IResult>Handle(CreateCustomerCommand request,CancellationToken cancellationToken)
            {
                var isThereAnyCustomer=await _customerRepository.GetAsync(c=>c.CustomerId==request.CustomerId);

                if(isThereAnyCustomer!=null)
                {
                    return new ErrorResult(Messages.AlreadyExist);
                }

                var customer = new Customer
                {
                    CustomerName = request.CustomerName,
                    CustomerId = request.CustomerId,
                    Address = request.Address,
                    MobilePhones = request.MobilePhones,
                    Email = request.Email,
                    isDeleted = false,
                    CreatedDate = request.CreatedDate,
                    CreatedUserId=request.CreatedUserId,

                };

                _customerRepository.Add(customer);
                await _customerRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }


        }


    }
}
