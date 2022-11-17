using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Domain.ModelsDto;

namespace WhoWorks.Service.Commands
{
    public record InsertPersonCommand(PersonDto PersonDto) :IRequest<PersonDto>;
}
