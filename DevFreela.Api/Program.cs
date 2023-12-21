using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Default services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("devfreela")));

//Dependency injection
builder.Services.AddScoped<IUserService, UserService>();

//Others services
builder.Services.AddMediatR(typeof(CreateProjectCommand)); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
