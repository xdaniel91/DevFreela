using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests;

public class ProjetTests

{   [Theory]
    [InlineData("Title", "Description", 10L, 20L, 3688.80)]
    public void TestIfProjectStartWorks(string title, string description, long idClient, long idFreelancer, decimal totalCost)
    {
        //Arrange
        //totalCost = Convert.ToDecimal(totalCost);
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
}