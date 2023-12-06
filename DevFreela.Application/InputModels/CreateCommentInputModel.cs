namespace DevFreela.Application.InputModels;
public class CreateCommentInputModel
{
    public long IdUser { get; set; }
    public long IdProject { get; set; }
    public string Content { get; set; }
}
