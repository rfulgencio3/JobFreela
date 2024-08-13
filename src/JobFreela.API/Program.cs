using AspNetCore.Scalar;
using FluentValidation.AspNetCore;
using JobFreela.API.Filters;
using JobFreela.Application.Commands.CreateProject;
using JobFreela.Application.Validators;
using JobFreela.Core.Repositories;
using JobFreela.Core.Services;
using JobFreela.Infra.Auth;
using JobFreela.Infra.Persistence;
using JobFreela.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobFreelaDbContext>(options =>
    options.UseInMemoryDatabase("JobFreelaCs"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("JobFreelaCs")));

// Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectCommentRepository, ProjectCommentRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();

// Mediator
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
    app.UseScalar(options =>
    {
        options.UseTheme(Theme.Default);
        options.UseLayout(Layout.Modern);
        options.RoutePrefix = "api-docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
