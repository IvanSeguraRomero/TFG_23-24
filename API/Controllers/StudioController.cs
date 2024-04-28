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

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] StudioCreateDTO studioCreateDTO)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el estudio"), $"Error al almacenar la información del estudio {ModelState}");
            return BadRequest(ModelState);
        }

        var studioDTO = new Studio
        {
            Name=studioCreateDTO.Name,
            Fundation=studioCreateDTO.Fundation,
            Country=studioCreateDTO.Country,
            EmailContact=studioCreateDTO.EmailContact,
            Website=studioCreateDTO.Website,
            Active=studioCreateDTO.Active
        };

        _studioService.AddStudio(studioDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = studioDTO.StudioID }, studioCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear un nuevo estudio");
                return StatusCode(500, "Error interno del servidor");
        }
    }



   // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] StudioUpdateDTO studioUpdateDTO)
        {
            try{
            var existingStudio = _studioService.GetStudio(id);

            if (existingStudio == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró el estudio"), $"Error al intentar acutalizar el estudio con el id {id}");
                return NotFound();
            }

            if(studioUpdateDTO.Name!=null){
                existingStudio.Name=studioUpdateDTO.Name;
            }
            if(studioUpdateDTO.Fundation!=null){
                existingStudio.Fundation=(DateTime)studioUpdateDTO.Fundation;
            }
            if(studioUpdateDTO.Country!=null){
                existingStudio.Country=studioUpdateDTO.Country;
            }
            if(studioUpdateDTO.EmailContact!=null){
                existingStudio.EmailContact=studioUpdateDTO.EmailContact;
            }
            if(studioUpdateDTO.Website!=null){
                existingStudio.Website=studioUpdateDTO.Website;
            }
            if(studioUpdateDTO.Active!=null){
                existingStudio.Active=(bool)studioUpdateDTO.Active;
            }
            
            
            
            _studioService.UpdateStudio(existingStudio);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar el estudio");
                return StatusCode(500, "Error interno del servidor");
        }
        }



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