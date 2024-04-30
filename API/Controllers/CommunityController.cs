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
                query = query.Where(community => community.LikesCount>= likesCount.Value)
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

    // POST action
    [HttpPost]
    public IActionResult Create([FromBody] CommunityCreateDTO communityCreateDTO)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear la comunidad"), $"Error al almacenar la información de la comunidad {ModelState}");
            return BadRequest(ModelState);
        }

        var communityDTO = new Community
        {
            Message= communityCreateDTO.Message,
            PublicationDate= communityCreateDTO.PublicationDate,
            ActiveMember= communityCreateDTO.ActiveMember,
            LikesCount= communityCreateDTO.LikesCount
        };

        _communityService.AddCommunity(communityDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = communityDTO.MessageID }, communityCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear una nueva comunidad");
                return StatusCode(500, "Error interno del servidor");
        }
    }


     // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] CommunityUpdateDTO communityUpdateDTO)
        {
            try{
            var existingCommunity = _communityService.GetCommunity(id);

            if (existingCommunity == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró la comunidad"), $"Error al intentar acutalizar la comunidad con el id {id}");
                return NotFound();
            }

            if(communityUpdateDTO.Message!=null){
                existingCommunity.Message=communityUpdateDTO.Message;
            }
            if(communityUpdateDTO.PublicationDate!=null){
                existingCommunity.PublicationDate=(DateTime)communityUpdateDTO.PublicationDate;
            }
            if(communityUpdateDTO.ActiveMember!=null){
                existingCommunity.ActiveMember= (bool)communityUpdateDTO.ActiveMember;
            }
            if(communityUpdateDTO.LikesCount!=null){
                existingCommunity.LikesCount= (int)communityUpdateDTO.LikesCount;
            }
            
            _communityService.UpdateCommunity(existingCommunity);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar la comunidad");
                return StatusCode(500, "Error interno del servidor");
        }
        }



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