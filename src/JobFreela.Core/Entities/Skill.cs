namespace JobFreela.Core.Entities;

public class Skill : BaseEntity
{
    public Skill(string description, int experience)
    {
        Description = description;
        Experience = experience;
    }

    public string Description { get; private set; }
    public int Experience { get; private set; }
}
