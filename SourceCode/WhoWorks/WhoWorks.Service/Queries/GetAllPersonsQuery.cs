using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Service.ModelsDto;

namespace WhoWorks.Service.Queries
{
    public record GetAllPersonsQuery ():IRequest<List<PersonDto>>;
   
}
