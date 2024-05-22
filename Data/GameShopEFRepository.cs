using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class GameShopEFRepository : IGameShopRepository
    {
        public readonly Context _context;
        public GameShopEFRepository(Context context) => _context = context;

        public void AddGameShop(GameShop gameShop)
        {
            _context.GameShops.Add(gameShop);
            SaveChanges();
        }

        public void DeleteGameShop(int id)
        {
            var gameShop=_context.GameShops.Find(id);
            if(gameShop==null){
                throw new KeyNotFoundException("Game Shop not found.");
            }
            _context.GameShops.Remove(gameShop);
            SaveChanges();
        }

        public List<GameShopDTO> GetAll()
        {
            var gamesRepository=new GameEFRepository(_context);
            var gameShops=_context.GameShops.Include(gs=>gs.Games).ToList();
            var gameShopDTO=gameShops.Select(gs=>new GameShopDTO{
                StoreID=gs.StoreID,
                GameID=gs.GameID,
                Event=gs.Event,
                Stock=gs.Stock,
                AnnualSales=gs.AnnualSales,
                LastUpdated=gs.LastUpdated,
                Origin=gs.Origin
            }).ToList();
            return gameShopDTO;
        }

        public GameShop GetGameShop(int id)
        {
            var gameShop=_context.GameShops.Find(id);
            return gameShop;
        }

        public GameShopDTO GetGameShopDTO(int id)
        {
            var gamesRepository=new GameEFRepository(_context);
            var gameShops=_context.GameShops.Include(gs=>gs.Games).ToList();
            var gameShopDTO=gameShops.Select(gs=>new GameShopDTO{
                StoreID=gs.StoreID,
                GameID=gs.GameID,
                Event=gs.Event,
                Stock=gs.Stock,
                AnnualSales=gs.AnnualSales,
                LastUpdated=gs.LastUpdated,
                Origin=gs.Origin
            }).FirstOrDefault(gs=>gs.StoreID==id);
            return gameShopDTO;
        }

        public List<GameDTO> GetGameShopGames(int id)
        {
            var gamesGameShop=_context.Games.Where(gs=>gs.GameID==id).ToList();
            var gamesForGameShopDTO=gamesGameShop.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Synopsis=g.Synopsis,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Categories=g.Categories,
                StudioID=g.StudioID
            }).ToList();
            return gamesForGameShopDTO;
        }

        public void UpdateGameShop(GameShop gameShop)
        {
           _context.Entry(gameShop).State = EntityState.Modified;
           SaveChanges();
        }
          public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}