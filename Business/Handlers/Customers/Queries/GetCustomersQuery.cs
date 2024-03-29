﻿using Business.BusinessAspects;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Queries
{
    public class GetCustomersQuery:IRequest<IDataResult<IEnumerable<Customer>>>
    {
        public class GetCustomersQueryHandler:IRequestHandler<GetCustomersQuery,IDataResult<IEnumerable<Customer>>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMediator _mediator;

            public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMediator mediator)
            {
                _customerRepository = customerRepository;
                _mediator = mediator;
            }
            [SecuredOperation(Priority=1)]
            [CacheRemoveAspect()]
            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<IEnumerable<Customer>>>Handle(GetCustomersQuery request,CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Customer>>(await _customerRepository.GetListAsync());
            }
        }
    }
}
