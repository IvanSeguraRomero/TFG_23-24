using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authorization;

namespace FlashGamingHub.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]

public class UserController : ControllerBase{
    private readonly IUserService? _userService;
    private readonly IlogError _logError;
    private readonly IAuthService _authService;

    public UserController(IlogError logError, IUserService? userService, IAuthService authService){
        _logError = logError;
        _userService = userService;
        _authService= authService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll(bool? active) {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
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
         if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
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

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
    {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el usuario"), $"Error al almacenar la información del usuario {ModelState}");
            return BadRequest(ModelState);
        }

        var userDTO = new User
        {
            Name= userCreateDTO.Name,
            Surname= userCreateDTO.Surname,
            Password=userCreateDTO.Password,
            Age=userCreateDTO.Age,
            Email=userCreateDTO.Email,
            RegisterDate=userCreateDTO.RegisterDate,
            Active=userCreateDTO.Active,
            Role=userCreateDTO.Role
        };

        _userService.AddUser(userDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = userDTO.UserID }, userCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear un nuevo usuario");
                return StatusCode(500, "Error interno del servidor");
        }
    }



    // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UserUpdateDTO userUpdateDTO)
        {
             if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
            try{
            var existingUser = _userService.GetUser(id);

            if (existingUser == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró el usuario"), $"Error al intentar acutalizar el usuario con el id {id}");
                return NotFound();
            }

            if(userUpdateDTO.Name!=null){
                existingUser.Name=userUpdateDTO.Name;
            }
            if(userUpdateDTO.Surname!=null){
                existingUser.Surname=userUpdateDTO.Surname;
            }
            if(userUpdateDTO.Password!=null){
                existingUser.Password=userUpdateDTO.Password;
            }
            if(userUpdateDTO.Age!=null){
                existingUser.Age=(int)userUpdateDTO.Age;
            }
            if(userUpdateDTO.Email!=null){
                existingUser.Email=userUpdateDTO.Email;
            }
            if(userUpdateDTO.RegisterDate!=null){
                existingUser.RegisterDate=(DateTime)userUpdateDTO.RegisterDate;
            }
            if(userUpdateDTO.Active!=null){
                existingUser.Active=(bool)userUpdateDTO.Active;
            }
            if(userUpdateDTO.Role!=null){
                existingUser.Role=userUpdateDTO.Role;
            }
            if(userUpdateDTO.LibraryGameUserID!=null){
                existingUser.LibraryGameUserID=(int)userUpdateDTO.LibraryGameUserID;
            }
            if(userUpdateDTO.MessageID!=null){
                existingUser.MessageID=(int)userUpdateDTO.MessageID;
            }
            
            
            _userService.UpdateUser(existingUser);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar el usuario");
                return StatusCode(500, "Error interno del servidor");
        }
        }



    // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
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

    [HttpGet("{id}/messages")]
    public ActionResult<List<CommunityDTO>> GetMessagesUser(int id){
         if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
        try{
            var messages = _userService.GetMessagesUser(id);
            if(messages == null || messages.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron mensajes en el usuario con ID {id}"), "Error al intentar obtener los mensajes");
                return NotFound();
            }else{
                return messages;
            }
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al obtener los mensajes");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}