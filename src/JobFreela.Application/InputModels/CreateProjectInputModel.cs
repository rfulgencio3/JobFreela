namespace JobFreela.Application.InputModels;

public class CreateProjectInputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}
