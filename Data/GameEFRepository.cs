using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class GameEFRepository : IGameRepository
    {
        public readonly Context _context;
        public GameEFRepository(Context context) => _context = context;

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            SaveChanges();
        }

        public void DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            if(game==null){
                throw new KeyNotFoundException("Game not found.");
            }
            _context.Games.Remove(game);
            SaveChanges();
        }

        public List<GameDTO> GetAll()
        {
            
            var studioRepository= new StudioEFRepository(_context);
            var communityRepository= new CommunityEFRepository(_context);
            var games=_context.Games.ToList();
            var gamesDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Synopsis=g.Synopsis,
                Price=g.Price,
                Discount=g.Discount,
                ReleaseDate=g.ReleaseDate,
                Categories=g.Categories,
                messages = communityRepository.getMessagesGame(g.GameID),
                StudioID=g.StudioID
            }).ToList();
            return gamesDTO;
           
        }

        public Game GetGame(int id)
        {
            var game = _context.Games.Include(g => g.Studio).Include(g => g.messages).FirstOrDefault(g => g.GameID == id);
            return game;
        }

        public GameDTO GetGameDTO(int id)
        {
            var studioRepository= new StudioEFRepository(_context);
            var communityRepository= new CommunityEFRepository(_context);
            var games=_context.Games.ToList();
            var gameDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Synopsis=g.Synopsis,
                Price=g.Price,
                Discount=g.Discount,
                ReleaseDate=g.ReleaseDate,
                Categories=g.Categories,
                messages = communityRepository.getMessagesGame(g.GameID),
                StudioID=g.StudioID
            }).FirstOrDefault(game=>game.GameID==id);
            return gameDTO;
        }

        public void UpdateGame(Game game)
        {
            _context.Entry(game).State=EntityState.Modified;
            SaveChanges();
        }

         public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public List<GameDTO> getGameShopGames(int storeId)
        {
            var studioRepository= new StudioEFRepository(_context);
            var games = _context.Games.Where(g => g.StoresAvailableAt.Any(s => s.StoreID == storeId)).Select(g => new GameDTO
                {
                    GameID=g.GameID,
                    Name = g.Name,
                    Description = g.Description,
                    Synopsis = g.Synopsis,
                    Price = g.Price,
                    Discount=g.Discount,
                    ReleaseDate = g.ReleaseDate,
                    Categories=g.Categories,
                    }).ToList();

            return games;
        }
          public List<GameDTO> getGamesStudio(int studioId){
             var games = _context.Games.Where(g => g.Studio.StudioID==studioId).Select(gd => new GameDTO
                {
                    GameID=gd.GameID,
                    Name = gd.Name,
                    Description = gd.Description,
                    Synopsis = gd.Synopsis,
                    Price = gd.Price,
                    Discount=gd.Discount,
                    ReleaseDate = gd.ReleaseDate,
                    Categories=gd.Categories,
                    StudioID=gd.StudioID
                }).ToList();
            return games;
        }

    }
    }
