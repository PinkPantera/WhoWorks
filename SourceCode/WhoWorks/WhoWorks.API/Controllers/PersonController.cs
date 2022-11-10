using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Commands;
using WhoWorks.Service.ModelsDto;
using WhoWorks.Service.Queries;

namespace WhoWorks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        { 
            this.mediator = mediator;
        }

        #region GET
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult result;

            try
            {
                var listPersons = await mediator.Send(new GetAllPersonsQuery());
                result = Ok(listPersons);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message); 
            }

            return result;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonDto personDto)
        {
            IActionResult result;
            try
            {
                var insertedPerson = await mediator.Send(new InsertPersonCommand(personDto));
                result = Ok(insertedPerson);

            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;

        }
        #endregion
    }
}
