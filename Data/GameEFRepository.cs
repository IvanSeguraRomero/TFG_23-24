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
            var userRepository= new UserEFRepository(_context);
            var studioRepository= new StudioEFRepository(_context);
            var games=_context.Games.ToList();
            var gamesDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Available=g.Available,
                Studio=studioRepository.GetStudio(g.Studio.StudioID),
                users=userRepository.getUsersGameId(g.GameID)
            }).ToList();
            return gamesDTO;
        }

        public Game GetGame(int id)
        {
            var game=_context.Games.Include(g=>g.Studio).FirstOrDefault(g=>g.GameID==id);
            return game;
        }

        public GameDTO GetGameDTO(int id)
        {
            var userRepository= new UserEFRepository(_context);
            var studioRepository= new StudioEFRepository(_context);
            var games=_context.Games.ToList();
            var gameDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Available=g.Available,
                Studio=studioRepository.GetStudio(g.Studio.StudioID),
                users=userRepository.getUsersGameId(g.GameID)
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
            var games = _context.Games.Where(g => g.StoresAvailableAt.Any(s => s.StoreID == storeId)).Select(g => new GameDTO
                {
                    Name = g.Name,
                    Description = g.Description,
                    Price = g.Price,
                    ReleaseDate = g.ReleaseDate,
                    Available = g.Available,
                    StudioID = g.StudioID,
                    Studio = new StudioDTO
                    {
                       Name= g.Studio.Name,
                       Fundation=g.Studio.Fundation,
                       Country=g.Studio.Country,
                       EmailContact=g.Studio.EmailContact,
                       Website=g.Studio.Website,
                       Active=g.Studio.Active
                    }
                    }).ToList();

            return games;
        }
          public List<GameDTO> getGamesStudio(int studioId){
             var games = _context.Games.Where(g => g.Studio.StudioID==studioId).Select(gd => new GameDTO
                {
                    Name = gd.Name,
                    Description = gd.Description,
                    Price = gd.Price,
                    ReleaseDate = gd.ReleaseDate,
                    Available = gd.Available,
                    StudioID = gd.StudioID,
                    StoresAvailableAt = gd.StoresAvailableAt.Select(s => new GameShopDTO
                        {
                            Price = s.Price,
                            Discount = s.Discount,
                            Stock = s.Stock,
                            AnnualSales = s.AnnualSales,
                            LastUpdated = s.LastUpdated,
                            Categories = s.Categories,
                            Origin = s.Origin
                        }).ToList()
                }).ToList();
            return games;
        }

    }
    }
