using JobFreela.Application.InputModels;
using JobFreela.Application.ViewModels;
using System.Data;

namespace JobFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(string query);
    ProjectDetailsViewModel GetById(int id);
    int Create(CreateProjectInputModel inputModel);
    void Update(UpdateRowSource inputModel);
    void Delete(int id);
    void CreateComment(CreateCommentInputModel inputModel);
    void Start(int id);
    void Finish(int id);
}
