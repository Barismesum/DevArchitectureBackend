﻿using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Commands
{
    public class DeleteCustomerCommand:IRequest<IResult>

    {
        public int CustomerId { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedConsumerId { get; set; }



        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResult>
        {
            private readonly ICustomerRepository _customerRepository;
            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IResult>Handle(DeleteCustomerCommand request,CancellationToken cancellationToken)
            {
                var customerToDelete=_customerRepository.Get(c=>c.CustomerId==request.CustomerId);

                customerToDelete.isDeleted = true;
                customerToDelete.LastUpdatedDate = request.LastUpdatedDate;
                customerToDelete.LastUpdatedConsumerId = request.LastUpdatedConsumerId;
                _customerRepository.Update(customerToDelete);
                await _customerRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}