using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class LibraryGameUserController : ControllerBase{
    private readonly LibraryGameUserService? _libraryGameUserService;
    private readonly IlogError _logError;

    public LibraryGameUserController(IlogError logError, LibraryGameUserService? libraryGameUserService){
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

    // POST action -- REALIZAR CUANDO HAYA CREATE DTO



    // PUT action -- REALIZAR CUANDO HAYA UPDATE DTO



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
}