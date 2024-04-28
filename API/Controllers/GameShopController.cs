using FlashGamingHub.Models;
using FlashGamingHub.Business;
using Microsoft.AspNetCore.Mvc;
using FlashGamingHub.common;

namespace FlashGamingHub.Controllers;

[ApiController]
[Route("[controller]")]

public class GameShopController : ControllerBase{
    private readonly IGameShopService? _gameShopService;
    private readonly IlogError _logError;

    public GameShopController(IlogError logError, IGameShopService? gameShopService){
        _logError = logError;
        _gameShopService = gameShopService;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<GameShopDTO>> GetAll(string? categorie) {
    try{
            var query =  _gameShopService.GetAll().AsQueryable();
            if(!string.IsNullOrEmpty(categorie)){
                query = query.Where(gameShop => gameShop.Categories.ToLower().Contains(categorie.ToLower()));
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
    public IActionResult Create([FromBody] GameShopCreateDTO gameShopCreateDTO)
    {
        try{            
        if (!ModelState.IsValid)
        {
            _logError.LogErrorMethod(new Exception("No se pudo crear la tienda"), $"Error al almacenar la información de la tienda {ModelState}");
            return BadRequest(ModelState);
        }

        var gameShopDTO = new GameShop
        {
            Price= gameShopCreateDTO.Price,
            Discount= gameShopCreateDTO.Discount,
            Stock= gameShopCreateDTO.Stock,
            AnnualSales= gameShopCreateDTO.AnnualSales,
            LastUpdated=gameShopCreateDTO.LastUpdated,
            Categories=gameShopCreateDTO.Categories,
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
        public IActionResult Update(int id,[FromBody] GameShopUpdateDTO gameShopUpdateDTO)
        {
            try{
            var existingGameShop = _gameShopService.GetGameShop(id);

            if (existingGameShop == null)
            {
                 _logError.LogErrorMethod(new Exception("No se encontró la tienda"), $"Error al intentar acutalizar la tienda con el id {id}");
                return NotFound();
            }

            if(gameShopUpdateDTO.Price!=null){
                existingGameShop.Price=(decimal)gameShopUpdateDTO.Price;
            }
            if(gameShopUpdateDTO.Discount!=null){
                existingGameShop.Discount=(decimal)gameShopUpdateDTO.Discount;
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
            if(gameShopUpdateDTO.Categories!=null){
                existingGameShop.Categories=gameShopUpdateDTO.Categories;
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
    public IActionResult Delete(int id)
    {
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
    public ActionResult<List<GameDTO>> GetGameShopGames(int id){
        try{
            var games = _gameShopService.GetGameShopGames(id);
            if(games == null || games.Count == 0){
                _logError.LogErrorMethod(new Exception($"No se encontraron juegos en la tienda con ID {id}"), "Error al intentar obtener los juegos");
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