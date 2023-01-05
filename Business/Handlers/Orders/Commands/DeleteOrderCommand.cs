using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Orders.Commands
{
    public class DeleteOrderCommand:IRequest<IResult>
    {
        public int OrderId { get; set;}
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedConsumerId { get; set; }


        public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand,IResult>
        {
            private readonly IOrderRepository _orderRepository;

            public DeleteOrderCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<IResult>Handle(DeleteOrderCommand request,CancellationToken cancellationToken)
            {
                var orderToDelete = _orderRepository.Get(o => o.OrderId == request.OrderId);

                orderToDelete.isDeleted = true;
                orderToDelete.LastUpdatedDate = request.LastUpdatedDate;
                orderToDelete.LastUpdatedConsumerId = request.LastUpdatedConsumerId;
                _orderRepository.Update(orderToDelete);
                await _orderRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);



            }


        }

    }
}
