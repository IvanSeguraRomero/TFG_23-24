using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class LibraryGameUserController : ControllerBase{
    private readonly ILibraryGameUserService? _libraryGameUserService;
    private readonly IlogError _logError;

    public LibraryGameUserController(IlogError logError, ILibraryGameUserService? libraryGameUserService){
        _logError = logError;
        _libraryGameUserService = libraryGameUserService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<LibraryGameUserDTO>> GetAll() {
    try{
            return _libraryGameUserService.GetAll();
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de las bibliotecas");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<LibraryGameUserDTO> Get(int id)
    {
        try{
        var library = _libraryGameUserService.GetLibraryGameUserDTO(id);

        if(library == null){
            _logError.LogErrorMethod(new Exception("No se encontró la biblioteca"), $"Error al obtener la información de la biblioteca con ID {id}");
            return NotFound();
        }

        return library;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de la biblioteca con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] LibraryGameUserCreateDTO libraryGameUserCreateDTO)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear la biblioteca"), $"Error al almacenar la información de la biblioteca {ModelState}");
            return BadRequest(ModelState);
        }

        var libraryGameUserDTO = new LibraryGameUser
        {
            AddedDate=libraryGameUserCreateDTO.AddedDate,
            Rating=libraryGameUserCreateDTO.Rating,
            HoursPlayed=libraryGameUserCreateDTO.HoursPlayed,
            LastPlayed=libraryGameUserCreateDTO.LastPlayed,
        };

        _libraryGameUserService.AddLibraryGameUser(libraryGameUserDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = libraryGameUserDTO.LibraryGameUserId }, libraryGameUserCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear una nueva biblioteca");
                return StatusCode(500, "Error interno del servidor");
        }
    }



    // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] LibraryGameUserUpdateDTO libraryGameUserUpdateDTO)
        {
            try{
            var existingLibraryGameUser = _libraryGameUserService.GetLibraryGameUser(id);

            if (existingLibraryGameUser == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró la biblioteca"), $"Error al intentar acutalizar la biblioteca con el id {id}");
                return NotFound();
            }

            if(libraryGameUserUpdateDTO.AddedDate!=null){
                existingLibraryGameUser.AddedDate=(DateTime)libraryGameUserUpdateDTO.AddedDate;
            }
            if(libraryGameUserUpdateDTO.Rating!=null){
                existingLibraryGameUser.Rating=(int)libraryGameUserUpdateDTO.Rating;
            }
            if(libraryGameUserUpdateDTO.HoursPlayed!=null){
                existingLibraryGameUser.HoursPlayed=(int)libraryGameUserUpdateDTO.HoursPlayed;
            }
            if(libraryGameUserUpdateDTO.LastPlayed!=null){
                existingLibraryGameUser.LastPlayed=(DateTime)libraryGameUserUpdateDTO.LastPlayed;
            }
            if(libraryGameUserUpdateDTO.UserID!=null){
                existingLibraryGameUser.UserID =libraryGameUserUpdateDTO.UserID;
            }
            
            
            _libraryGameUserService.UpdateLibraryGameUser(existingLibraryGameUser);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar la biblioteca");
                return StatusCode(500, "Error interno del servidor" + ex.Message);
        }
        }



    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try{
        var library = _libraryGameUserService.GetLibraryGameUserDTO(id);
    
        if (library is null){
            _logError.LogErrorMethod(new Exception($"No se encontró la biblioteca con ID {id}"), "Error al intentar eliminar la biblioteca");
            return NotFound();
        }
        
        _libraryGameUserService.DeleteLibraryGameUser(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar la biblioteca");
                return StatusCode(500, "Error interno del servidor");
        }
    }
    [HttpGet("{id}/games")]
    public ActionResult<List<GameDTO>> GetLibraryGameUserGames(int id){
        try{
            var games = _libraryGameUserService.GetLibraryGameUserGames(id);
            if(games == null || games.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron juegos en el usuario con ID {id}"), "Error al intentar obtener los juegos");
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