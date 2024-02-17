using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using FluentAssertions;
using Moq;

namespace DevFreela.UnitTests;

public sealed class GetAllProjectsCommandHandlerTests
{
    [Fact]
    public async Task GivenThreeProjects_WhenExecuted_ThenReturnsThreeProjects()
    {
        //Arrange
        List<Project> projects = new()
        {
            new("a volta dos que nunca foram", "alligator", 10, 20, 1500),
            new("a volta dos que já foram", "mondial", 5, 100, 2699),
            new("a volta dos que ainda vão", "tapioca", 1, 5, 6.300M)
        };

        var projectRepository = new Mock<IProjectRepository>();
        projectRepository.Setup(x => x.GetAllAsync(CancellationToken.None).Result).Returns(projects);

        var getAllProjectsQuery = new GetAllProjectsQuery();
        var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository.Object);

        //Act
        var result = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
        result.Should().HaveSameCount(projects);
        projectRepository.Verify(pr => pr.GetAllAsync(CancellationToken.None).Result, Times.Once);
    }
}
