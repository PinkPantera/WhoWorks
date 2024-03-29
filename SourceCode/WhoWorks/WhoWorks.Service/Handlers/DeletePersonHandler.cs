﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Commands;
using WhoWorks.Domain;
using WhoWorks.Domain.ModelsDto;

namespace WhoWorks.Service.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, PersonDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePersonHandler(IUnitOfWork unitOfWork)

        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PersonDto> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await unitOfWork.GetRepository<Person>().GetByIdAsync(request.Id);

            if (person != null)
            {
                unitOfWork.GetRepository<Person>().Remove(person);
                await unitOfWork.SaveChanges();
                return person.ToPersonDto();
            }
            return null;
        }
    }
}
