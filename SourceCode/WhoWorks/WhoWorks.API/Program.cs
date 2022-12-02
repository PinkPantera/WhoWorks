using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using WhoWorks.API.HealthChecks;
using WhoWorks.Core;
using WhoWorks.Data.SQLServer;
using WhoWorks.Data.SQLServer.Repositories;
using WhoWorks.Domain.Models;
using WhoWorks.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WhoWorksDatabase");

builder.Services.AddDbContext<WhoWorksDbContext>
    (conextBuilder => conextBuilder.UseSqlServer(connectionString));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<Person>, PersonRepository>();

builder.Services.AddMediatR(typeof(MediatREntrypoint).Assembly);

builder.Services.AddHealthChecks()
 .AddSqlServer(connectionString);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
   ResponseWriter = HealthCheckHelper.WriteResponse
});

app.Run();
