using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Helpers;
using WhoWorks.Service.ModelsDto;
using WhoWorks.Service.Queries;

namespace WhoWorks.Service.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPersonByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
           var person = await unitOfWork.GetRepository<Person>().GetByIdAsync(request.Id) ;

           return person?.ToPersonDto();
        }
    }
}
