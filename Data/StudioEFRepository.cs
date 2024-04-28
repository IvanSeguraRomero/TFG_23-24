using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class StudioEFRepository : IStudioRepository
    {
        public readonly Context _context;
        public StudioEFRepository(Context context) => _context = context;
        public void AddStudio(Studio studio)
        {
            _context.Studios.Add(studio);
            SaveChanges();
        }

        public void DeleteStudio(int id)
        {
            var studio = _context.Studios.Find(id);
            if (studio == null){
                throw new KeyNotFoundException("Studio not found.");
            }
            _context.Studios.Remove(studio);
            SaveChanges();
        }

        public List<StudioDTO> GetAll()
        {
            var gamesRepository=new GameEFRepository(_context);
            var studios = _context.Studios.ToList();
            var studiosDTO=studios.Select(s=>new StudioDTO{
                StudioID=s.StudioID,
                Name=s.Name,
                Fundation=s.Fundation,
                Country=s.Country,
                EmailContact=s.EmailContact,
                Website=s.Website,
                Active=s.Active,
                games=gamesRepository.getGamesStudio(s.StudioID)
            }).ToList();
            return studiosDTO;
        }

        public Studio GetStudio(int id)
        {
            var  studio =_context.Studios.FirstOrDefault(s => s.StudioID == id);
            return studio;
        }

        public StudioDTO GetStudioDTO(int id)
        {
            var gamesRepository=new GameEFRepository(_context);
            var studios = _context.Studios.ToList();
            var studioDTO=studios.Select(s=>new StudioDTO{
                StudioID=s.StudioID,
                Name=s.Name,
                Fundation=s.Fundation,
                Country=s.Country,
                EmailContact=s.EmailContact,
                Website=s.Website,
                Active=s.Active,
                games=gamesRepository.getGamesStudio(s.StudioID)
            }).FirstOrDefault(studio=>studio.StudioID==id);

            return studioDTO;
        }

        public List<GameDTO> GetStudioGames(int id){
            var usersGameRepository=new UserEFRepository(_context);
            var gamesStudio=_context.Games.Where(game=>game.StudioID==id).ToList();
            var gamesForStudioDTO=gamesStudio.Select(g=>new GameDTO{
                GameID=g.GameID,
                Name=g.Name,
                Description=g.Description,
                Price=g.Price,
                ReleaseDate=g.ReleaseDate,
                Available=g.Available,
                StudioID=g.StudioID,
                users=usersGameRepository.getUsersGameId(g.GameID)
            }).ToList();
            return gamesForStudioDTO;
        }

        public void UpdateStudio(Studio studio)
        {
            _context.Entry(studio).State=EntityState.Modified;
            SaveChanges();
        }
         public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}