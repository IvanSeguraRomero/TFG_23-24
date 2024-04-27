using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase{
    private readonly IUserService? _userService;
    private readonly IlogError _logError;

    public UserController(IlogError logError, IUserService? userService){
        _logError = logError;
        _userService = userService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll(bool? active) {
    try{
            var query = _userService.GetAll().AsQueryable();
            if(active.HasValue){
                if(active.Value){
                    query=query.Where(u => u.Active);
                }else{
                    query=query.Where(u => !u.Active);
                }
            }

            var users = query.ToList();
            if(users.Count==0){
                return NotFound();
            }
            return users;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los usuarios");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        try{
        var user = _userService.GetUserDTO(id);

        if(user == null){
            _logError.LogErrorMethod(new Exception("No se encontró el usuario"), $"Error al obtener la información del usuario con ID {id}");
            return NotFound();
        }

        return user;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del usuario con el id {id}");
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
        var messages = _userService.GetUserDTO(id);
    
        if (messages is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el usuario con ID {id}"), "Error al intentar eliminar el usuario");
            return NotFound();
        }
        
        _userService.DeleteUser(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el usuario");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}