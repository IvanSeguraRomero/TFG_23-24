using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class GameShopController : ControllerBase{
    private readonly IGameShopService? _gameShopService;
    private readonly IlogError _logError;

    public GameShopController(IlogError logError, IGameShopService? gameShopService){
        _logError = logError;
        _gameShopService = gameShopService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<GameShopDTO>> GetAll(string? categorie) {
    try{
            var query =  _gameShopService.GetAll().AsQueryable();
            if(!string.IsNullOrEmpty(categorie)){
                query = query.Where(gameShop => gameShop.Categories.ToLower().Contains(categorie.ToLower()));
            }
            var gameShops = query.ToList();
            if(gameShops.Count==0){
                return NotFound();
            }
            return gameShops;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de las tiendas");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<GameShopDTO> Get(int id)
    {
        try{
        var gameShop = _gameShopService.GetGameShopDTO(id);

        if(gameShop == null){
            _logError.LogErrorMethod(new Exception("No se encontró la tienda"), $"Error al obtener la información de la tienda con ID {id}");
            return NotFound();
        }

        return gameShop;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de la tienda con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // POST action -- REALIZAR CUANDO HAYA CREATE DTO



    // PUT action -- REALIZAR CUANDO HAYA UPDATE DTO



    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try{
        var gameShop = _gameShopService.GetGameShopDTO(id);
    
        if (gameShop is null){
            _logError.LogErrorMethod(new Exception($"No se encontró la tienda con ID {id}"), "Error al intentar eliminar la tienda");
            return NotFound();
        }
        
        _gameShopService.DeleteGameShop(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar la tienda");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/games")]
    public ActionResult<List<GameDTO>> GetGameShopGames(int id){
        try{
            var games = _gameShopService.GetGameShopGames(id);
            if(games == null || games.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron juegos en la tienda con ID {id}"), "Error al intentar obtener los juegos");
                return NotFound();
            }else{
                return games;
            }
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al obtener los juegos");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}