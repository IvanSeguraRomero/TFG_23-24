using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authorization;

namespace FlashGamingHub.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]

public class ShoppingCartController : ControllerBase{
    private readonly IShoppingCartService? _shoppingCartService;
    private readonly IlogError _logError;
    private readonly IAuthService _authService;

    public ShoppingCartController(IlogError logError, IShoppingCartService? shoppingCartService, IAuthService authService){
        _logError = logError;
        _shoppingCartService = shoppingCartService;
        _authService= authService;
    }

     // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<ShoppingCartDTO> Get(int id)
    {
        if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
        try{
        var shoppingCart = _shoppingCartService.GetShoppingCart(id);

        if(shoppingCart == null){
            _logError.LogErrorMethod(new Exception("No se encontró el carrito"), $"Error al obtener la información del carrito con ID {id}");
            return NotFound();
        }
        var shoppingCartDTO = new ShoppingCartDTO{
            UserID=shoppingCart.UserID,
             Games = shoppingCart.Games.Select(game => new GameDTO
            {
                GameID = game.GameID,
                Name=game.Name,
                Description=game.Description,
                Price=game.Price,
                ReleaseDate=game.ReleaseDate,
                Available=game.Available,
                StudioID=game.StudioID
            }).ToList(),
            Total=shoppingCart.Total,
            FechaCreacion=shoppingCart.FechaCreacion
        };
        return shoppingCartDTO;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del carrito con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }


     // POST action
    [HttpPost]
    public IActionResult Create([FromBody] ShoppingCart shoppingCart)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el carrito"), $"Error al almacenar la información del carrito {ModelState}");
            return BadRequest(ModelState);
        }

        // var studioDTO = new Studio
        // {
        //     Name=shoppingCart.Name,
        //     Fundation=shoppingCart.Fundation,
        //     Country=shoppingCart.Country,
        //     EmailContact=shoppingCart.EmailContact,
        //     Website=shoppingCart.Website,
        //     Active=shoppingCart.Active
        // };

        _shoppingCartService.AddShoppingCart(shoppingCart);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = shoppingCart.ShoppingCartID }, shoppingCart);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear un nuevo carrito");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ShoppingCartUpdateDTO shoppingCart)
        {
        if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
            try{
            var existingShoppingCart = _shoppingCartService.GetShoppingCart(id);

            if (existingShoppingCart == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró el carrito"), $"Error al intentar acutalizar el carrito con el id {id}");
                return NotFound();
            }

            // if(shoppingCart.Games!=null){
            //     existingShoppingCart.Games=shoppingCart.Games;
            // }
            if(shoppingCart.Total!=null){
                existingShoppingCart.Total=(decimal)shoppingCart.Total;
            }
            if(shoppingCart.FechaCreacion!=null){
                existingShoppingCart.FechaCreacion=(DateTime)shoppingCart.FechaCreacion;
            }
            _shoppingCartService.UpdateShoppingCart(existingShoppingCart);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar el carrito");
                return StatusCode(500, "Error interno del servidor");
        }
        }

        // DELETE action
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_authService.HasAccessToResource(id,HttpContext.User))
        {
            return Forbid();
        }
        try{
        var studio = _shoppingCartService.GetShoppingCart(id);
    
        if (studio is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el carrito con ID {id}"), "Error al intentar eliminar el carrito");
            return NotFound();
        }
        
        _shoppingCartService.DeleteShoppingCart(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el carrito");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}