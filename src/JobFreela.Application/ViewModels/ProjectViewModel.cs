namespace JobFreela.Application.ViewModels;

public class ProjectViewModel
{
    public ProjectViewModel(string title, string description, DateTime createdAt)
    {
        Title = title;
        Description = description;
        CreatedAt = createdAt;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
