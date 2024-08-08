namespace JobFreela.Application.ViewModels;

public class SkillViewModel
{
    public SkillViewModel(int id, string description, int experience, DateTime createdAt)
    {
        Id = id;
        Description = description;
        Experience = experience;
        CreatedAt = createdAt;
    }

    public int Id { get; private set; }
    public string Description { get; private set; }
    public int Experience { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
