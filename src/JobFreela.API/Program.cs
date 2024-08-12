using AspNetCore.Scalar;
using JobFreela.Application.Commands.CreateComment;
using JobFreela.Application.Commands.CreateProject;
using JobFreela.Application.Commands.CreateSkill;
using JobFreela.Application.Commands.CreateUser;
using JobFreela.Application.Services.Implementations;
using JobFreela.Application.Services.Interfaces;
using JobFreela.Core.Repositories;
using JobFreela.Infra.Persistence;
using JobFreela.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();

// Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddDbContext<JobFreelaDbContext>(options =>
    options.UseInMemoryDatabase("JobFreelaCs"));
//options.UseSqlServer(builder.Configuration.GetConnectionString("JobFreelaCs")));

// Mediator
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateCommentCommand).Assembly));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateSkillCommand).Assembly));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

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
