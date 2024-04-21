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
            var games=_context.Games.ToList();
            var gamesDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Available=g.Available,
                Studio=g.Studio,
                users=userRepository.getUserGameId(g.GameID)
            }).ToList();
            return gamesDTO;
        }

        public Game GetGame(int id)
        {
            var game=_context.Games.Find(id);
            return game;
        }

        public GameDTO GetGameDTO(int id)
        {
            var userRepository= new UserEFRepository(_context);
            var games=_context.Games.ToList();
            var gameDTO=games.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Available=g.Available,
                Studio=g.Studio,
                users=userRepository.getUserGameId(g.GameID)
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
    }
}