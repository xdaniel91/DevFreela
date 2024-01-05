using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Filters;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Default services
builder.Services.AddControllers(e => e.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(e => e.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//Database
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("devfreela")));

//Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

//Services
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
