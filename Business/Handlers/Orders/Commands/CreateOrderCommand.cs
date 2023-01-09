﻿using Business.BusinessAspects;
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

namespace Business.Handlers.Orders.Commands
{
    public class CreateOrderCommand:IRequest<IResult>
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Piece { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,IResult> 
        {
            private readonly IOrderRepository _orderRepository;

            public CreateOrderCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            [SecuredOperation(Priority = 1)]
            public async Task<IResult>Handle(CreateOrderCommand request,CancellationToken cancellationToken)
            {
                var isThereAnyOrder=await _orderRepository.GetAsync(o=>o.OrderId==request.OrderId);

                if(isThereAnyOrder !=null)
                {
                    return new ErrorResult(Messages.AlreadyExist);
                }

                var order = new Order
                {
                 CustomerId=request.CustomerId,
                 ProductId=request.ProductId,
                 Piece=request.Piece,
                 CreatedDate=request.CreatedDate,
                    CreatedUserId = request.CreatedUserId,
                };

                _orderRepository.Add(order);
                await _orderRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);





            }
        }


    }
}
