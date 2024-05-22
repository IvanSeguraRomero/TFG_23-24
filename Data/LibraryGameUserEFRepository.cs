using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class LibraryGameUserEFRepository : ILibraryGameUserRepository
    {
        public readonly Context _context;

        public LibraryGameUserEFRepository(Context context) => _context = context;

        public void AddLibraryGameUser(LibraryGameUser libraryGameUser)
        {
            _context.LibraryGameUsers.Add(libraryGameUser);
            SaveChanges();
        }

        public void DeleteLibraryGameUser(int id)
        {
            var libraryGameUser = _context.LibraryGameUsers.Find(id);
             if(libraryGameUser==null){
                throw new KeyNotFoundException("LibraryGameUser not found.");
            }
            _context.LibraryGameUsers.Remove(libraryGameUser);
            SaveChanges();
        }

        public List<LibraryGameUserDTO> GetAll()
        {
           var studioRepository= new StudioEFRepository(_context);
           var  libraryGameUsers = _context.LibraryGameUsers.ToList();
           var  libraryGameUsersDto = libraryGameUsers.Select(l=>new LibraryGameUserDTO{
                LibraryGameUserId=l.LibraryGameUserId,
                AddedDate= l.AddedDate,
                Rating= l.Rating,
                HoursPlayed= l.HoursPlayed,
                LastPlayed= l.LastPlayed,
                UserID = l.UserID
           }).ToList();
           return libraryGameUsersDto;
        }

        public LibraryGameUser GetLibraryGameUser(int id)
        {
             var libraryGameUser=_context.LibraryGameUsers.Include(g=>g.Games).Include(g=>g.User).FirstOrDefault(l=>l.LibraryGameUserId==id);
            return libraryGameUser;
        }

        public LibraryGameUserDTO GetLibraryGameUserDTO(int id)
        {
           var studioRepository= new StudioEFRepository(_context);
           var  libraryGameUsers = _context.LibraryGameUsers.ToList();
           var  libraryGameUsersDto = libraryGameUsers.Select(l=>new LibraryGameUserDTO{
                LibraryGameUserId=l.LibraryGameUserId,
                AddedDate= l.AddedDate,
                Rating= l.Rating,
                HoursPlayed= l.HoursPlayed,
                LastPlayed= l.LastPlayed,
                UserID = l.UserID
           }).FirstOrDefault(l=>l.LibraryGameUserId==id);
           return libraryGameUsersDto;
        }

        public List<GameDTO> GetLibraryGameUserGames(int id){
                var studioRepository= new StudioEFRepository(_context);
                var libraryGameUsersDto = _context.LibraryGameUsers.Where(l => l.UserID == id).SelectMany(l => l.Games)
                .Select(g => new GameDTO
                {
                    GameID= g.GameID,
                    Name = g.Name,
                    Description = g.Description,
                    Synopsis = g.Synopsis,
                    Price = g.Price,
                    Discount=g.Discount,
                    ReleaseDate = g.ReleaseDate,
                    Categories = g.Categories,
                    StudioID=g.StudioID,
                })
                .ToList();

            return libraryGameUsersDto;
        }

        public void SaveChanges()
            {
                _context.SaveChanges();
            }

        public void UpdateLibraryGameUser(LibraryGameUser libraryGameUser)
        {
             _context.Entry(libraryGameUser).State=EntityState.Modified;
            SaveChanges();
        }
    }
}