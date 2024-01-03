using AutoMapper;
using ItemService.Controllers;
using ItemService.Data;
using ItemService.Dtos;
using ItemService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace RestauranteService.Tests;

public class RestauranteServicesTests
{
    private readonly Mock<IItemRepository> _itemRepoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();


    [Fact]
    public void GetRestaurantes_ReturnsOkResult_WhenCalled()
    {
        // Arrange
        _itemRepoMock.Setup(repo => repo.GetAllRestaurantes()).Returns(new List<Restaurante>());
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<RestauranteReadDto>>(
            It.IsAny<IEnumerable<Restaurante>>())).Returns(new List<RestauranteReadDto>());
        var controller = new RestauranteController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.GetRestaurantes();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var restaurantes = Assert.IsType<List<RestauranteReadDto>>(okResult.Value);
    }

    [Fact]
    public void RecebeRestauranteDoRestauranteService_ReturnsOkResult_WhenCalledWithValidDto()
    {
        // Arrange
        var dto = new RestauranteReadDto();
        var controller = new RestauranteController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.RecebeRestauranteDoRestauranteService(dto);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void RecebeRestauranteDoRestauranteService_ReturnsServerErrorResult_WhenCalledWithNullDto()
    {
        // Arrange
        var controller = new RestauranteController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.RecebeRestauranteDoRestauranteService(null);

        // Assert
        Assert.IsType<ObjectResult>(result);
        var serverErrorResult = result as ObjectResult;
        Assert.Equal(500, serverErrorResult?.StatusCode);
    }
}