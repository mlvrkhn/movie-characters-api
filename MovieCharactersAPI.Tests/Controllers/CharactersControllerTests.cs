using Moq;
using MovieCharactersAPI.Controllers;
using MovieCharactersAPI.Features.Characters;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;


public class CharactersControllerTests
{
    private readonly Mock<ICharacterService> _mockService;
    private readonly CharactersController _controller;

    public CharactersControllerTests()
    {
        _mockService = new Mock<ICharacterService>();
        var mockMapper = new Mock<IMapper>();
        _controller = new CharactersController(_mockService.Object, mockMapper.Object);
    }

    [Fact]
    public async Task GetCharacters_ReturnsOkResult()
    {
        // Arrange
        var characters = new List<CharacterDTO>
        {
            new CharacterDTO { Id = 1, FullName = "Test Character" }
        };
        _mockService.Setup(service => service.GetAllCharactersAsync())
            .ReturnsAsync(characters);

        // Act
        var result = await _controller.GetCharacters();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedCharacters = Assert.IsType<List<CharacterDTO>>(okResult.Value);
        Assert.Single(returnedCharacters);
    }
} 