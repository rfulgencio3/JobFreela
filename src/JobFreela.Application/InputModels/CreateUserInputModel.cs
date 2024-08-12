namespace JobFreela.Application.InputModels;

public class CreateUserInputModel
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
}
