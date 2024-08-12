using JobFreela.Application.ViewModels;

namespace JobFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetById(int id);
    void Start(int id);
    void Finish(int id);
}
