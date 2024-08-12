using JobFreela.Application.Services.Interfaces;
using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JobFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly JobFreelaDbContext _context;
    public ProjectService(JobFreelaDbContext context)
    {
        _context = context;
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
        var project = _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefault(p => p.Id == id);

        if (project is null) return null;

        var projectDetailsViewModel = new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.FullName,
            project.Freelancer.FullName);

        return projectDetailsViewModel; 
    }

    public void Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        project.Start();

        _context.SaveChanges();
    }

    public void Finish(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        project.Finish();

        _context.SaveChanges();
    }
}
