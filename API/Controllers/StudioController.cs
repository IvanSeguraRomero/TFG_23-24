using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class StudioController : ControllerBase{
    private readonly IStudioService? _studioService;
    private readonly IlogError _logError;

    public StudioController(IlogError logError, IStudioService? studioService){
        _logError = logError;
        _studioService = studioService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<StudioDTO>> GetAll(string? name, string? country) {
    try{
            var query =  _studioService.GetAll().AsQueryable();
            if(!string.IsNullOrEmpty(name)){
                query = query.Where(studio => studio.Name.ToLower().Contains(name.ToLower()));
            }
            if(!string.IsNullOrEmpty(country)){
                query = query.Where(studio => studio.Country.ToLower().Contains(country.ToLower()));
            }
            var studios = query.ToList();
            if(studios.Count==0){
                return NotFound();
            }
            return studios;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los estudios");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<StudioDTO> Get(int id)
    {
        try{
        var studio = _studioService.GetStudioDTO(id);

        if(studio == null){
            _logError.LogErrorMethod(new Exception("No se encontró el estudio"), $"Error al obtener la información del estudio con ID {id}");
            return NotFound();
        }

        return studio;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del estudio con el id {id}");
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
        var studio = _studioService.GetStudioDTO(id);
    
        if (studio is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el estudio con ID {id}"), "Error al intentar eliminar el estudio");
            return NotFound();
        }
        
        _studioService.DeleteStudio(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el estudio");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/games")]
    public ActionResult<List<GameDTO>> GetStudioGames(int id){
        try{
            var games = _studioService.GetStudioGames(id);
            if(games == null || games.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron juegos en el estudio con ID {id}"), "Error al intentar obtener los juegos");
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