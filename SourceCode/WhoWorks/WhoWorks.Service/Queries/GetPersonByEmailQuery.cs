using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Domain.ModelsDto;

namespace WhoWorks.Service.Queries
{
    public record GetPersonByEmailQuery (string Email):IRequest<PersonDto>;
    
}
