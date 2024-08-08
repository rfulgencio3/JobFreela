using JobFreela.Application.InputModels;
using JobFreela.Application.Services.Interfaces;
using JobFreela.Application.ViewModels;
using JobFreela.Core.Entities;
using JobFreela.Infra.Persistence;
using System.Data;

namespace JobFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly JobFreelaDbContext _context;
    public ProjectService(JobFreelaDbContext context)
    {
        _context = context;
    }
    public int Create(CreateProjectInputModel inputModel)
    {
        var project = new Project(
            inputModel.Title, 
            inputModel.Description, 
            inputModel.IdClient, 
            inputModel.IdFreelancer, 
            inputModel.TotalCost
            );

        _context.Projects.Add(project);
        return project.Id;
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(
            inputModel.Content,
            inputModel.IdProject,
            inputModel.IdUser);

        _context.ProjectComments.Add(comment);
    }

    public void Delete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        project.Cancel(); 
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _context.Projects;
        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);
        var projectDetailsViewModel = new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt);

        return projectDetailsViewModel; 
    }

    public void Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        project.Start();
    }

    public void Finish(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        project.Finish();
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }
}
