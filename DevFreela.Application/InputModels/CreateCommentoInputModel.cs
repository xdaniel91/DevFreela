namespace DevFreela.Application.InputModels;
public class CreateCommentoInputModel
{
    public long IdUser { get; set; }
    public long IdProject { get; set; }
    public string Content { get; set; }
}
