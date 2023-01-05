using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Consumers.Commands
{
    public class DeleteConsumerCommand:IRequest<IResult>
    {
        public int ConsumerId { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedConsumerId { get; set; }

        public class DeleteConsumerCommandHandler : IRequestHandler<DeleteConsumerCommand,IResult>
        {
            private readonly IConsumerRepository _consumerRepository;

            public DeleteConsumerCommandHandler(IConsumerRepository consumerRepository)
            {
                _consumerRepository = consumerRepository;
            }

            public async Task<IResult> Handle(DeleteConsumerCommand request,CancellationToken cancellationToken)
            {
                var consumerToDelete=_consumerRepository.Get(c=>c.ConsumerId==request.ConsumerId);

                consumerToDelete.isDeleted = true;
                consumerToDelete.LastUpdatedDate = request.LastUpdatedDate;
                consumerToDelete.LastUpdatedConsumerId = request.LastUpdatedConsumerId;
                _consumerRepository.Update(consumerToDelete);
                await _consumerRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
