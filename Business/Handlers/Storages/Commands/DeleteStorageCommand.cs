﻿using Business.BusinessAspects;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Storages.Commands
{
    public class DeleteStorageCommand:IRequest<IResult>
    {
        public int ProductId { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUserId { get; set; }

        public class DeleteStorageCommandHandler:IRequestHandler<DeleteStorageCommand,IResult>
        {
            private readonly IStorageRepository _storageRepository;

            public DeleteStorageCommandHandler(IStorageRepository storageRepository)
            {
                _storageRepository = storageRepository;
            }
            [SecuredOperation(Priority = 1)]
            public async Task<IResult>Handle(DeleteStorageCommand request,CancellationToken cancellationToken)
            {
                var storageToDelete = _storageRepository.Get(s => s.ProductId == request.ProductId);
                
                storageToDelete.isDeleted=true;
                storageToDelete.LastUpdatedDate= request.LastUpdatedDate;
                storageToDelete.LastUpdatedUserId = request.LastUpdatedUserId;

                _storageRepository.Update(storageToDelete);
                await _storageRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}