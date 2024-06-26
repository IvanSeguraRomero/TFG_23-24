using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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
                Synopsis=game.Synopsis,
                Price=game.Price,
                ReleaseDate=game.ReleaseDate,
                Categories=game.Categories,
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
    public IActionResult Create([FromBody] ShoppingCartCreateDTO shoppingCart)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el carrito"), $"Error al almacenar la información del carrito {ModelState}");
            return BadRequest(ModelState);
        }

        var shoppingCartDTO = new ShoppingCart
        {
           UserID=shoppingCart.UserID,
           Total=shoppingCart.Total,
           FechaCreacion=shoppingCart.FechaCreacion
        };

        _shoppingCartService.AddShoppingCart(shoppingCartDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = shoppingCartDTO.ShoppingCartID }, shoppingCartDTO);
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

            if(shoppingCart.Games!=null){
               var updateGames = shoppingCart.Games.Select(g =>
                {
                    var newGame = new Game();
                    if (g.Name != null)
                        newGame.Name = g.Name;

                    if (g.Description != null)
                        newGame.Description = g.Description;
                    
                    if (g.Synopsis != null)
                        newGame.Synopsis = g.Synopsis;

                    if (g.Price != null)
                        newGame.Price = (decimal)g.Price;

                    if (g.ReleaseDate != null)
                        newGame.ReleaseDate = (DateTime)g.ReleaseDate;
                    
                    if(g.Categories != null)
                        newGame.Categories = g.Categories;


                    return newGame;
                }).ToList();
                existingShoppingCart.Games=updateGames;
            }
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

    [HttpPost("{id}/games/{gameId}")]
    public IActionResult AddGameShoppingCart(int id, int gameId)
    {
        if (!_authService.HasAccessToResource(id, HttpContext.User))
        {
            return Forbid();
        }
        try
        {
            _shoppingCartService.AddGameToShoppingCart(id, gameId);
            return Ok("Game added to cart");
        }
        catch (DuplicateNameException ex)
        {
        _logError.LogErrorMethod(ex, "Intento de añadir un juego duplicado al carrito");
        return Conflict("Game already added");
        }
         catch (Exception ex)
        {
        _logError.LogErrorMethod(ex, "Error al añadir el juego al carrito");
        return StatusCode(500, "An unexpected error occurred");
        }
    }

    [HttpDelete("{id}/games/{gameId}")]
    public IActionResult RemoveGameShoppingCart(int id, int gameId)
    {
        
        if (!_authService.HasAccessToResource(id, HttpContext.User))
        {
            return Forbid();
        }
        
        try
        {
            _shoppingCartService.RemoveGameFromShoppingCart(id, gameId);
            return Ok("Game removed from the shoppingCart");
        }
        catch (KeyNotFoundException ex)
        {
            _logError.LogErrorMethod(ex, "Intento de eliminar un juego que no existe en el carrito");
            return NotFound("Game not found in shoppingCart");
        }
        catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, "Error al eliminar el juego del carrito");
            return StatusCode(500, "An unexpected error occurred");
        }
    }

    [HttpGet("{id}/games")]
    public IActionResult GetGamesInShoppingCart(int id)
    {
        if (!_authService.HasAccessToResource(id, HttpContext.User))
        {
            return Forbid();
        }

        try
        {
            var shoppingCart = _shoppingCartService.GetShoppingCart(id);

            if (shoppingCart == null)
            {
                _logError.LogErrorMethod(new Exception($"No se encontró el carrito con ID {id}"), "Error al obtener los juegos del carrito");
                return NotFound("Shopping cart not found");
            }

            var gamesInCart = shoppingCart.Games.Select(game => new GameDTO
            {
                GameID = game.GameID,
                Name = game.Name,
                Description = game.Description,
                Synopsis = game.Synopsis,
                Price = game.Price,
                Discount = game.Discount,
                ReleaseDate = game.ReleaseDate,
                Categories = game.Categories,
                StudioID = game.StudioID
            }).ToList();

            return Ok(gamesInCart);
        }
        catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener los juegos del carrito con ID {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }


}