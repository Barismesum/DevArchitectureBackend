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

namespace Business.Handlers.Consumers.Commands
{
    public class UpdateConsumerCommand : IRequest<IResult>
    {
        public int ConsumerId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string MobilePhones { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedConsumerId { get; set; }


        public class UpdateConsumerCommandHandler : IRequestHandler<UpdateConsumerCommand, IResult>
        {
            private readonly IConsumerRepository _consumerRepository;

            public UpdateConsumerCommandHandler(IConsumerRepository consumerRepository)
            {
                _consumerRepository = consumerRepository;
            }

            public async Task<IResult> Handle(UpdateConsumerCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyConsumer = await _consumerRepository.GetAsync(c => c.ConsumerId == request.ConsumerId);

                isThereAnyConsumer.FullName = request.FullName;
                isThereAnyConsumer.Email = request.Email;
                isThereAnyConsumer.MobilePhones = request.MobilePhones;
                isThereAnyConsumer.LastUpdatedDate = request.LastUpdatedDate;
                isThereAnyConsumer.LastUpdatedConsumerId = request.LastUpdatedConsumerId;

                _consumerRepository.Update(isThereAnyConsumer);
                await _consumerRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);

            }


        }


    }
}
