using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Business.Handlers.Consumers.Commands
{
    public class CreateConsumerCommand: IRequest<IResult>
    {
       
            public int ConsumerId { get; set; }
            public string FullName { get; set; }
            public string MobilePhones { get; set; }
            public string Email { get; set; }
            public int Gender { get; set; }
            public string Password { get; set; }
            public int RolId { get; set; }
            public bool isDeleted { get; set; }



            public class CreateConsumerCommandHandler : IRequestHandler<CreateConsumerCommand, IResult>
            {
                private readonly IConsumerRepository _consumerRepository;

                public CreateConsumerCommandHandler(IConsumerRepository consumerRepository)
                {
                    _consumerRepository = consumerRepository;
                }

                public async Task<IResult> Handle(CreateConsumerCommand request, CancellationToken cancellationToken)
                {
                    var isThereAnyUser = await _consumerRepository.GetAsync(c => c.Email == request.Email);


                    if (isThereAnyUser != null)
                    {
                        return new ErrorResult(Messages.NameAlreadyExist);
                    }

                    var consumer = new Consumer
                    {
                        Email = request.Email,
                        FullName = request.FullName,
                        MobilePhones = request.MobilePhones,
                        Gender = request.Gender,
                        RolId = request.RolId,
                        isDeleted=false,
                    };

                    _consumerRepository.Add(consumer);
                    await _consumerRepository.SaveChangesAsync();
                    return new SuccessResult(Messages.Added);


                }
            }
        }
    }

