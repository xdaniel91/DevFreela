using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Exceptions;

namespace DevFreela.UnitTests;

public class ProjetTests

{
    private static readonly string _title = "Title"; 
    private static readonly string _description = "Description"; 
    private static readonly long _idClient = 30L; 
    private static readonly long _idFreelancer = 15L; 
    private static readonly decimal _totalCost = 4000.666M; 

    [Theory]
    [InlineData("Title", "Description", 10L, 20L, "3688.80")]
    [InlineData("Another title", "Another description", 1L, 100L, "40000.800")]
    [InlineData("", null, 1L, 100L, "40000.30")]
    [InlineData(null, "", 4L, 2000L, "40000.02")]
    [InlineData(" ", " ", 2L, 100000L, "40000.001")]
    public void GivenCorrecltlyInformations_WhenProjectStarts_ProjectStatusIsInProgress(
    string title, string description, long idClient, long idFreelancer, string totalCostString)
    {
        //Arrange
        decimal totalCost = decimal.Parse(totalCostString);
        var project = new Project(title, description, idClient, idFreelancer, totalCost);
        
        //Act
        project.Start();

        //Assert
        Assert.Equal(project.Status, ProjectStatusEnum.InProgress);
        Assert.Equal(project.Description, description);
        Assert.Equal(project.Title, title);
        Assert.Equal(project.IdClient, idClient);
        Assert.Equal(project.IdFreelancer, idFreelancer);
        Assert.Equal(project.CreatedAt.ToString("dd/MM/yyyy:hh:mm:ss"), DateTime.UtcNow.ToString("dd/MM/yyyy:hh:mm:ss"));
        Assert.Equal(project.TotalCost, totalCost);
    }

    [Fact]
    public void GivenProjectWithInvalidStatus_WhenProjectStarts_ThrowsException()
    {
        //Arrange
        var project = new Project(_title, _description, _idClient, _idFreelancer, _totalCost);
        project.Cancel();
        
        //Act
        var act = () => project.Start();

        //Assert
        var exception = Assert.Throws<DomainException>(act);
    }
}