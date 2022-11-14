using MediatR;
using MediatR.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WhoWorks.API.Controllers;
using WhoWorks.Core;
using WhoWorks.Domain.Models;
using WhoWorks.Service.Handlers;
using WhoWorks.Service.ModelsDto;
using WhoWorks.Service.Queries;

namespace PersonControllerTests
{
    public class GetAllPersonTests
    {
        [Fact]
        public void GetAllPersonTest()
        {
            //Arrange
            var listPersonsFromDB = new List<Person>() { new Person { Id = 10 } };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(item => item.GetRepository<Person>().GetAllAsync()).ReturnsAsync(listPersonsFromDB);

            var services = new ServiceCollection();
            var serviceConfig = new MediatRServiceConfiguration();
            ServiceRegistrar.AddRequiredServices(services, serviceConfig);
            services.AddScoped<IRequestHandler<GetAllPersonsQuery, List<PersonDto>>, GetAllPersonsHandler>();
            services.AddSingleton(typeof(IUnitOfWork), unitOfWorkMock.Object);
          
            var provider = services.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediator>();
            var personController = new PersonController(mediator);
          
            //Act
            var actionResult =  personController.GetAll();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            
            var resultModel = (OkObjectResult)actionResult.Result;
            Assert.NotNull(resultModel);
            Assert.NotNull(resultModel.Value);

            Assert.IsType<List<PersonDto>>(resultModel.Value);
            var actualListPersons = resultModel.Value as List<PersonDto>;
            Assert.NotNull(actualListPersons);
            Assert.True(actualListPersons.Count == listPersonsFromDB.Count);
        }


    }
}