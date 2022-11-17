using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Helpers;
using WhoWorks.Domain.ModelsDto;
using WhoWorks.Service.Queries;

namespace WhoWorks.Service.Handlers
{
    public class GetPersonByEmailHandler : IRequestHandler<GetPersonByEmailQuery, PersonDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPersonByEmailHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PersonDto> Handle(GetPersonByEmailQuery request, CancellationToken cancellationToken)
        {
          var person = await unitOfWork.GetRepository<Person>()
                .SinglOrDefaulAsync(item => item.Email== request.Email);

            return person?.ToPersonDto();
        }
    }
}
