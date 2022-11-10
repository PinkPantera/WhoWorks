using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.Design.Serialization;
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
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            IActionResult result;
            try
            {
                var person = await mediator.Send(new GetPersonByIdQuery(id));
                if (person == null)
                {
                    result = NotFound();
                }
                else
                {
                    result = Ok(person);
                }
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return result;
        }

        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
        {
            IActionResult result;
            try
            {
                if (personDto == null)
                {
                    return BadRequest();
                }

                var person = await mediator.Send(new GetPersonByEmailQuery(personDto.Email));

                if (person != null)
                {
                    return BadRequest("Person email already in use");
                }

                var insertedPerson = await mediator.Send(new InsertPersonCommand(personDto));
                result = Ok(insertedPerson);

            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return result;

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            IActionResult result;
            try
            {
                var person = await mediator.Send(new DeletePersonCommand(id));

                if (person == null)
                {
                    result = NotFound($"Person with Id = {id} not found");
                }
                else
                {
                    result = Ok(person);
                }
            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return result;

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDto personDto)
        {
            IActionResult result;
            try
            {
                var person = await mediator.Send(new UpdatePersonCommand(personDto));

                if (person == null)
                {
                    result = NotFound($"Person with Id = {personDto.Id} not found");
                }
                else
                {
                    result = Ok(person);
                }

            }
            catch (Exception)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

            return result;
        }
        #endregion
    }
}
