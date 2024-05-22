using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authorization;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class GameController : ControllerBase{
    private readonly IGameService? _gameService;
    private readonly IlogError _logError;
    private readonly IAuthService _authService;

    public GameController(IlogError logError, IGameService? gameService, IAuthService authService){
        _logError = logError;
        _gameService = gameService;
        _authService= authService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<GameDTO>> GetAll(string? name, decimal? price, string? orderPrice, string? orderDate, string? orderName) {
    try{
            var query = _gameService.GetAll().AsQueryable();
            if(!string.IsNullOrEmpty(name)){
                query = query.Where(game => game.Name.ToLower().Contains(name.ToLower()));
            }
            if(price.HasValue){
                query = query.Where(game => game.Price<price.Value);
            }
            if(!string.IsNullOrEmpty(orderPrice)){
                //Del más barato al más caro
                if(orderPrice.ToLower() == "asc"){
                    query = query.OrderBy(game => game.Price);
                } 
                //Del más caro al más barato
                else if(orderPrice.ToLower() == "desc"){
                    query = query.OrderByDescending(game => game.Price);
                }
            }
            if(!string.IsNullOrEmpty(orderDate)){
                //Del más nuevo al más viejo
                if(orderDate.ToLower() == "asc"){
                    query = query.OrderBy(game => game.ReleaseDate);
                } 
                //Del más viejo al más nuevo
                else if(orderDate.ToLower() == "desc"){
                    query = query.OrderByDescending(game => game.ReleaseDate);
                }
            }
            if(!string.IsNullOrEmpty(orderName)){
                //Por orden alfabético
                if(orderName.ToLower() == "asc"){
                    query = query.OrderBy(game => game.Name);
                } 
                //Por orden alfabético inverso
                else if(orderName.ToLower() == "desc"){
                    query = query.OrderByDescending(game => game.Name);
                }
            }
            var games = query.ToList();
            if(games.Count==0){
                return NotFound();
            }
            return games;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de los juegos");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<GameDTO> Get(int id)
    {
        try{
        var games = _gameService.GetGameDTO(id);

        if(games == null){
            _logError.LogErrorMethod(new Exception("No se encontró el juego"), $"Error al obtener la información del juego con ID {id}");
            return NotFound();
        }

        return games;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información del juego con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // POST action
    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] GameCreateDTO gameCreateDTO)
    {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear el juego"), $"Error al almacenar la información del juego {ModelState}");
            return BadRequest(ModelState);
        }
    
        var gameDTO = new Game
        {
            Name=gameCreateDTO.Name,
            Description=gameCreateDTO.Description,
            Synopsis=gameCreateDTO.Synopsis,
            Price=gameCreateDTO.Price,
            Discount=gameCreateDTO.Discount,
            ReleaseDate=gameCreateDTO.ReleaseDate,
            Categories=gameCreateDTO.Categories,
            StudioID=gameCreateDTO.StudioID,
            StoreID=gameCreateDTO.StoreID
        };
        _gameService.AddGame(gameDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = gameDTO.GameID }, gameCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear un nuevo juego");
                return StatusCode(500, "Error interno del servidor ");
        }
    }



    // PUT action
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id,[FromBody] GameUpdateDTO gameUpdateDTO)
        {
            if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
            
            try{
            var existingGame = _gameService.GetGame(id);

            if (existingGame == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró el juego"), $"Error al intentar acutalizar el juego con el id {id}");
                return NotFound();
            }

            if(gameUpdateDTO.Name!=null){
                existingGame.Name=gameUpdateDTO.Name;
            }
            if(gameUpdateDTO.Description!=null){
                existingGame.Description=gameUpdateDTO.Description;
            }
            if(gameUpdateDTO.Synopsis!=null){
                existingGame.Synopsis=gameUpdateDTO.Synopsis;
            }
            if(gameUpdateDTO.Price!=null){
                existingGame.Price=(decimal)gameUpdateDTO.Price;
            }
            if(gameUpdateDTO.Discount!=null){
                existingGame.Discount=(int)gameUpdateDTO.Discount;
            }
            if(gameUpdateDTO.ReleaseDate!=null){
                existingGame.ReleaseDate=(DateTime)gameUpdateDTO.ReleaseDate;
            }
            if(gameUpdateDTO.Categories!=null){
                existingGame.Categories=gameUpdateDTO.Categories;
            }
            
            _gameService.UpdateGame(existingGame);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar el juego");
                return StatusCode(500, "Error interno del servidor");
        }
        }



    // DELETE action
   [HttpDelete("{id}")]
   [Authorize]
    public IActionResult Delete(int id)
    {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
        try{
        var games = _gameService.GetGameDTO(id);
    
        if (games is null){
            _logError.LogErrorMethod(new Exception($"No se encontró el juego con ID {id}"), "Error al intentar eliminar el juego");
            return NotFound();
        }
        
        _gameService.DeleteGame(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar el juego");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}
