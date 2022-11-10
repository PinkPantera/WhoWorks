using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Service.ModelsDto;

namespace WhoWorks.Service.Commands
{
    public record UpdatePersonCommand (PersonDto Person):IRequest<PersonDto>;
}
