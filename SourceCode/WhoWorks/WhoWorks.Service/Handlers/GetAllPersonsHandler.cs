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
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<PersonDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPersonsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await unitOfWork.GetRepository<Person>()
                    .GetAllAsync();

            var listPersonDtos = new List<PersonDto>();
            foreach (var person in persons)
            {
                listPersonDtos.Add(person.ToPersonDto());
            }

            return listPersonDtos;
        }
    }
}
