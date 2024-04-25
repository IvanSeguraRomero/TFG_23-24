using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class GameController : ControllerBase{
    private readonly IGameService? _gameService;
    private readonly IlogError _logError;

    public GameController(IlogError logError, IGameService? gameService){
        _logError = logError;
        _gameService = gameService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<GameDTO>> GetAll() {
    try{
            return _gameService.GetAll();
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los juegos");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<GameDTO> Get(int id)
    {
        try{
        var games = _gameService.GetGameDTO(id);

        if(games == null){
            _logError.LogErrorMethod(new Exception("No se encontró el juego"), $"Error al obtener la información del juego con ID {id}");
            return NotFound();
        }

        return games;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del juego con el id {id}");
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
        var games = _gameService.GetGameDTO(id);
    
        if (games is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el juego con ID {id}"), "Error al intentar eliminar el juego");
            return NotFound();
        }
        
        _gameService.DeleteGame(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el juego");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}