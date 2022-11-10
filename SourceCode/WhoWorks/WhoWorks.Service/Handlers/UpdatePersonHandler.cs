using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Commands;
using WhoWorks.Service.Helpers;
using WhoWorks.Service.ModelsDto;

namespace WhoWorks.Service.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdatePersonHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PersonDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await unitOfWork.GetRepository<Person>().Update(request.Person.ToPerson());

            await unitOfWork.SaveChanges(cancellationToken);

            return person?.ToPersonDto();
        }
    }
}
