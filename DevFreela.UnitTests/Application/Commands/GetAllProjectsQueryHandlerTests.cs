using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands;

public class GetAllProjectsQueryHandlerTests
{
    [Fact]
    public void GivenThreeProjectsExists_WhenExecuted_ThenReturnThreeProjectsViewModels()
    {
        //Arrange
        List<Project>? projects = new()
        {
            new ("Google chrome", "Navegador", 10, 15, 10000000000M),
            new ("Mozilla Firefox", "Navegador", 188, 215, 9000.157M),
            new ("Steam", "Plataforma de games", 566, 666, 7777777.666M),
        };

        var mockProjectRepository = new Mock<IProjectRepository>();
        mockProjectRepository.Setup(e => e.GetAllAsync(CancellationToken.None).Result).Returns(projects);

        //Act

        //Assert
    }
}
