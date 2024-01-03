using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ItemService.Data;
using ItemService.Dtos;

namespace ItemService.Controllers;

[Route("api/item/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly IItemRepository _repository;
    private readonly IMapper _mapper;

    public RestauranteController(IItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets all Restaurantes
    /// </summary>
    /// <returns>List of Restaurantes</returns>
    [HttpGet]
    public ActionResult<IEnumerable<RestauranteReadDto>> GetRestaurantes()
    {
        try
        {
            string jsonString =
                "[\n  {\n    \"Id\": 2,\n    \"Nome\": \"restaurante Haroldo 2\",\n    \"Endereco\": null,\n    \"Site\": null\n  }\n]";
            IEnumerable<RestauranteReadDto> restaurantes =
                JsonSerializer.Deserialize<IEnumerable<RestauranteReadDto>>(jsonString);


            // var restaurantes = _repository.GetAllRestaurantes();

            return Ok(_mapper.Map<IEnumerable<RestauranteReadDto>>(restaurantes));
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    /// <summary>
    /// Receives a Restaurante from the Restaurante service
    /// </summary>
    /// <returns>Status Ok if everything went well</returns>
    [HttpPost]
    public ActionResult RecebeRestauranteDoRestauranteService(RestauranteReadDto dto)
    {
        try
        {
            Console.WriteLine(dto.Id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
}