using AutoMapper;
using ItemService.Controllers;
using ItemService.Data;
using ItemService.Dtos;
using ItemService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ItemService.Tests;

public class ItemControllerTests
{
    private readonly Mock<IItemRepository> _itemRepoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public void GetItensForRestaurante_ReturnsOkResult_WhenRestaurantExists()
    {
        // Arrange
        int testRestaurantId = 1;
        _itemRepoMock.Setup(repo => repo.RestauranteExiste(testRestaurantId)).Returns(true);
        _itemRepoMock.Setup(repo => repo.GetItensDeRestaurante(testRestaurantId)).Returns(new List<Item>());
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ItemReadDto>>(
            It.IsAny<IEnumerable<Item>>())).Returns(new List<ItemReadDto>());
        var controller = new ItemController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.GetItensForRestaurante(testRestaurantId);

        // Assert
        Assert.IsAssignableFrom<ActionResult<IEnumerable<ItemReadDto>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var items = Assert.IsType<List<ItemReadDto>>(okResult.Value);
    }

    [Fact]
    public void GetItensForRestaurante_ReturnsID_WhenRestaurantExists()
    {
        // Arrange
        int testRestaurantId = 1;
        _itemRepoMock.Setup(repo => repo.RestauranteExiste(testRestaurantId)).Returns(true);
        _itemRepoMock.Setup(repo => repo.GetItensDeRestaurante(testRestaurantId)).Returns(new List<Item>());
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ItemReadDto>>(
            It.IsAny<IEnumerable<Item>>())).Returns(new List<ItemReadDto> {new ItemReadDto {Id = 1}});
        var controller = new ItemController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.GetItensForRestaurante(testRestaurantId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var items = Assert.IsType<List<ItemReadDto>>(okResult.Value);

        int itemId = 0;
        if (items.Count > 0)
        {
            itemId = items[0].Id;
        }

        Assert.Equal(1, itemId); // assert that the first item's id is 1
    }

    [Fact]
    public void GetItensForRestaurante_ReturnsNotFoundResult_WhenRestaurantDoesNotExist()
    {
        // Arrange
        int testRestaurantId = 133;
        _itemRepoMock.Setup(repo => repo.RestauranteExiste(testRestaurantId)).Returns(false);
        var controller = new ItemController(_itemRepoMock.Object, _mapperMock.Object);

        // Act
        var result = controller.GetItensForRestaurante(testRestaurantId);

        // Assert
        Assert.IsAssignableFrom<ActionResult<IEnumerable<ItemReadDto>>>(result);
        Assert.IsType<NotFoundResult>(result.Result);
    }
}