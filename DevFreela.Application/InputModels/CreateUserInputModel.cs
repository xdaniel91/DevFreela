namespace DevFreela.Application.InputModels;
public class CreateUserInputModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}
