using JobFreela.Application.ViewModels;
using MediatR;

namespace JobFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{
}
