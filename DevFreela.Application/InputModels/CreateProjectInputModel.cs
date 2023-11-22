namespace DevFreela.Application.InputModels;
public class CreateProjectInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long IdFreelancer { get; set; }
    public long IdClient { get; set; }
    public decimal TotalCost { get; set; }
}
