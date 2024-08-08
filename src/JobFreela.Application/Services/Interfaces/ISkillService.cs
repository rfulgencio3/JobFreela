using JobFreela.Application.ViewModels;

namespace JobFreela.Application.Services.Interfaces;

public interface ISkillService
{
    List<SkillViewModel> GetAll();
    SkillViewModel GetById(int id);
}
