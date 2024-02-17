using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core;

public class ProjetTests
{
    private static readonly string _title = "test_project";
    private static readonly string _description = "test_description";
    private static readonly long _idClient = 10;
    private static readonly long _idFreelancer = 15;
    private static readonly decimal _totalCost = 16997.777M;

    [Theory]
    [InlineData("a", "b", 10, 10, "00.005")]
    [InlineData("project test", "description", 1000, 1000000, "666.666")]
    [InlineData("????===+++", "____?", 99999, 1, "99.001")]
    public void GivenProjectWithValidInformation_WhenCreated_ThenReturnsCreatedProject(
        string title, 
        string description, 
        long idClient, 
        long idFreelancer,
        string totalCostString)
    {
        //Arrange
        decimal totalCost = decimal.Parse(totalCostString);

        //Act
        Project newProject = new Project(title, description, idClient, idFreelancer, totalCost);

        //Assert
        Assert.Equal(newProject.Status, ProjectStatusEnum.Created);
        Assert.IsType<Project>(newProject);
        Assert.NotNull(newProject);
        Assert.Equal(newProject.Title, title);
        Assert.Equal(newProject.Description, description);
        Assert.Equal(newProject.IdClient, idClient);
        Assert.Equal(newProject.IdFreelancer, idFreelancer);
        Assert.Equal(newProject.TotalCost, totalCost);
    }

    [Fact]
    public void GivenProjectCreated_WhenStarted_ThenSetProjetStatusInProgress()
    {
        //Arrange
        Project project = new Project(_title, _description, _idClient, _idFreelancer, _totalCost);
        //Act
        project.Start();
        //Assert
        Assert.Equal(project.Status, ProjectStatusEnum.InProgress);
    }

    [Fact]
    public void GivenProjectWithCreatedStatus_WhenCancelled_ThenSetStatusToCancelled()
    {
        //Arrange
        Project project = new Project(_title, _description, _idClient, _idFreelancer, _totalCost);

        //Act
        project.Cancel();

        //Assert
        Assert.Equal(project.Status, ProjectStatusEnum.Cancelled);
    }

    [Fact]
    public void GivenProjectWithInProgressStatus_WhenFinished_ThenSetProjectStatusFinished()
    {
        //Arrange
        Project project = new Project(_title, _description, _idClient, _idFreelancer, _totalCost);
        project.Start();

        //Act
        project.Finish();

        //Assert
        Assert.Equal(project.FinishAt.Value.ToString("dd/MM/yyyy:HH:mm"), DateTime.UtcNow.ToString("dd/MM/yyyy:HH:mm"));
        Assert.Equal(project.Status, ProjectStatusEnum.Finished);
    }
}