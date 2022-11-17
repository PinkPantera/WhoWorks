using MediatR;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Commands;
using WhoWorks.Domain;
using WhoWorks.Domain.ModelsDto;

namespace WhoWorks.Service.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public InsertPersonHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<PersonDto> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var personToInsert =  await unitOfWork.GetRepository<Person>().GetByIdAsync(request.PersonDto.Id);
            if (personToInsert != null)
            {
                throw new Exception("Person with the same id already exists in the database");
            }

            personToInsert = request.PersonDto.ToPerson();

            await unitOfWork.GetRepository<Person>().AddAsync(personToInsert);
            await unitOfWork.SaveChanges();

            if (personToInsert.Id==0)
            {
                throw new Exception("Person hasn't inserted in the database");
            }
           
            return personToInsert.ToPersonDto();
        }
    }
}
