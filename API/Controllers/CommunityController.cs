using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class CommunityController : ControllerBase{
    private readonly ICommunityService? _communityService;
    private readonly IlogError _logError;

    public CommunityController(IlogError logError, ICommunityService? communityService){
        _logError = logError;
        _communityService = communityService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<CommunityDTO>> GetAll(int? likesCount) {
    try{
            var query = _communityService.GetAll().AsQueryable();
            if(likesCount.HasValue){
                query = query.Where(community => community.LikesCount> likesCount.Value)
                .OrderByDescending(community => community.LikesCount);
            }

            var community = query.ToList();
            if(community.Count==0){
                return NotFound();
            }
            return community;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los mensajes");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<CommunityDTO> Get(int id)
    {
        try{
        var messages = _communityService.GetCommunityDTO(id);

        if(messages == null){
            _logError.LogErrorMethod(new Exception("No se encontró el mensaje"), $"Error al obtener la información del mensaje con ID {id}");
            return NotFound();
        }

        return messages;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del mensaje con el id {id}");
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
        var messages = _communityService.GetCommunityDTO(id);
    
        if (messages is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el mensaje con ID {id}"), "Error al intentar eliminar el mensaje");
            return NotFound();
        }
        
        _communityService.DeleteCommunity(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el mensaje");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}