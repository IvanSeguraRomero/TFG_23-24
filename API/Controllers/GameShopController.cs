using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authorization;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class GameShopController : ControllerBase{
    private readonly IGameShopService? _gameShopService;
    private readonly IlogError _logError;
    private readonly IAuthService _authService;

    public GameShopController(IlogError logError, IGameShopService? gameShopService, IAuthService authService){
        _logError = logError;
        _gameShopService = gameShopService;
        _authService= authService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<GameShopDTO>> GetAll(string? orderAnnualSales) {
    try{
            var query =  _gameShopService.GetAll().AsQueryable();
            if(!string.IsNullOrEmpty(orderAnnualSales)){
                //De menos a más
                if(orderAnnualSales.ToLower() == "asc"){
                    query = query.OrderBy(gameshop => gameshop.AnnualSales);
                }
                //De más a menos
                else if(orderAnnualSales.ToLower() == "desc"){
                    query = query.OrderByDescending(gameshop => gameshop.AnnualSales);
                }
            }
            var gameShops = query.ToList();
            if(gameShops.Count==0){
                return NotFound();
            }
            return gameShops;
      }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de las tiendas");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<GameShopDTO> Get(int id)
    {
        try{
        var gameShop = _gameShopService.GetGameShopDTO(id);

        if(gameShop == null){
            _logError.LogErrorMethod(new Exception("No se encontró la tienda"), $"Error al obtener la información de la tienda con ID {id}");
            return NotFound();
        }

        return gameShop;
        }catch (Exception ex)
        {
            _logError.LogErrorMethod(ex, $"Error al obtener la información de la tienda con el id {id}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    // POST action
    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] GameShopCreateDTO gameShopCreateDTO)
    {
        if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear la tienda"), $"Error al almacenar la información de la tienda {ModelState}");
            return BadRequest(ModelState);
        }

        var gameShopDTO = new GameShop
        {
            Event= gameShopCreateDTO.Event,
            Stock= gameShopCreateDTO.Stock,
            AnnualSales= gameShopCreateDTO.AnnualSales,
            LastUpdated=gameShopCreateDTO.LastUpdated,
            Origin=gameShopCreateDTO.Origin
        };

        _gameShopService.AddGameShop(gameShopDTO);

        // Devolver la respuesta CreatedAtAction con el nuevo DTO
        return CreatedAtAction(nameof(Get), new { id = gameShopDTO.StoreID }, gameShopCreateDTO);
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al crear una nueva tienda");
                return StatusCode(500, "Error interno del servidor");
        }
    }



    // PUT action
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id,[FromBody] GameShopUpdateDTO gameShopUpdateDTO)
        {
            if (!_authService.IsAdmin(HttpContext.User))
        {
            return Forbid();
        }
            try{
            var existingGameShop = _gameShopService.GetGameShop(id);

            if (existingGameShop == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró la tienda"), $"Error al intentar acutalizar la tienda con el id {id}");
                return NotFound();
            }

            if(gameShopUpdateDTO.Event!=null){
                existingGameShop.Event=gameShopUpdateDTO.Event;
            }
            if(gameShopUpdateDTO.Stock!=null){
                existingGameShop.Stock=(int)gameShopUpdateDTO.Stock;
            }
            if(gameShopUpdateDTO.AnnualSales!=null){
                existingGameShop.AnnualSales=(int)gameShopUpdateDTO.AnnualSales;
            }
            if(gameShopUpdateDTO.LastUpdated!=null){
                existingGameShop.LastUpdated=(DateTime)gameShopUpdateDTO.LastUpdated;
            }
            if(gameShopUpdateDTO.Origin!=null){
                existingGameShop.Origin=gameShopUpdateDTO.Origin;
            }
            
            _gameShopService.UpdateGameShop(existingGameShop);

            return NoContent();
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al actualizar la tienda");
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
        var gameShop = _gameShopService.GetGameShopDTO(id);
    
        if (gameShop is null){
            _logError.LogErrorMethod(new Exception($"No se encontró la tienda con ID {id}"), "Error al intentar eliminar la tienda");
            return NotFound();
        }
        
        _gameShopService.DeleteGameShop(id);
    
        return NoContent();
        }catch(Exception ex){
                _logError.LogErrorMethod(ex, "Error al eliminar la tienda");
                return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("{id}/games")]
    public ActionResult<List<GameDTO>> GetGameShopGames(int id, string? category, decimal? price, string? orderDate, string? orderPrice, string? orderName){
        try{
            var query = _gameShopService.GetGameShopGames(id).AsQueryable();
            if(!string.IsNullOrEmpty(category) && category.ToLower()!="ninguna"){
                query = query.Where(game => game.Categories.ToLower().Contains(category.ToLower()));
            }
            if(price.HasValue && price.Value>0){
                query = query.Where(game => game.Price<price.Value);
            }
            if(!string.IsNullOrEmpty(orderDate)){
                if(orderDate.ToLower() == "asc"){
                    query = query.OrderBy(game => game.ReleaseDate);
                }else if(orderDate.ToLower() == "desc" ){
                    query = query.OrderByDescending(game => game.ReleaseDate);
                }
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
            if(!string.IsNullOrEmpty(orderName)){
                //De la A a la Z
                if(orderName.ToLower() == "asc"){
                    query = query.OrderBy(game => game.Name);
                } 
                //De la Z a la A
                else if(orderName.ToLower() == "desc"){
                    query = query.OrderByDescending(game => game.Name);
                }
            }
            var games = query.ToList();
            if(games == null || games.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron juegos en la tienda con ID {id}"), "Error al intentar obtener los juegos");
                return NotFound();
            }
            return games;
        }catch(Exception ex){
                 _logError.LogErrorMethod(ex, "Error al obtener los juegos");
                return StatusCode(500, "Error interno del servidor");
        }
    }
}