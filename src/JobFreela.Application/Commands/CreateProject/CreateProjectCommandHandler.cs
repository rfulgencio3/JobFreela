﻿using JobFreela.Core.Entities;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IProjectRepository _repository;
    public CreateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(
            request.Title,
            request.Description,
            request.IdClient,
            request.IdFreelancer,
            request.TotalCost
            );

        await _repository.AddAsync(project);

        return project.Id;
    }
}
