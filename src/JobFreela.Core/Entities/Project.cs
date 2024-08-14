using JobFreela.Core.Enums;

namespace JobFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        Status = ProjectStatus.Created;
        Comments = new List<ProjectComment>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public User Client { get; private set; }
    public int IdFreelancer { get; private set; }
    public User Freelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatus Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public void Cancel()
    {
        if (Status == ProjectStatus.Created || Status == ProjectStatus.InProgress)
        {
            Status = ProjectStatus.Cancelled;
        }
    }
    public void Start()
    {
        if (Status == ProjectStatus.Created)
        {
            Status = ProjectStatus.InProgress;
            StartedAt = DateTime.UtcNow;
        }
    }
    public void Finish()
    {
        if (Status == ProjectStatus.PaymentPending)
        {
            Status = ProjectStatus.Finished;
            FinishedAt = DateTime.UtcNow;
        }
    }

    public void SetPaymentPending()
    {
        Status = ProjectStatus.PaymentPending;
        FinishedAt = null;
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}