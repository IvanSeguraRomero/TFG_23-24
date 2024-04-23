using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class LibraryGameUserEFRepository : ILibraryGameUser
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
           var userRepository= new UserEFRepository(_context);
           var  libraryGameUsers = _context.LibraryGameUsers.ToList();
           var  libraryGameUsersDto = libraryGameUsers.Select(l=>new LibraryGameUserDTO{
                AddedDate= l.AddedDate,
                Rating= l.Rating,
                HoursPlayed= l.HoursPlayed,
                LastPlayed= l.LastPlayed,
                User = userRepository.GetUserDTO(l.UserID),
                Games= l.Games.Select(g=>new GameDTO{
                    Name=g.Name,
                    Description=g.Description,
                    Price=g.Price,
                    ReleaseDate=g.ReleaseDate,
                    Available=g.Available,
                    Studio=studioRepository.GetStudio(g.StudioID)
                }).ToList()
           }).ToList();
           return libraryGameUsersDto;
        }

        public LibraryGameUser GetLibraryGameUser(int id)
        {
             var libraryGameUser=_context.LibraryGameUsers.Include(g=>g.Game).Include(g=>g.User).FirstOrDefault(l=>l.UserID==id);
            return libraryGameUser;
        }

        public LibraryGameUserDTO GetLibraryGameUserDTO(int id)
        {
           var studioRepository= new StudioEFRepository(_context);
           var userRepository= new UserEFRepository(_context);
           var  libraryGameUsers = _context.LibraryGameUsers.ToList();
           var  libraryGameUsersDto = libraryGameUsers.Select(l=>new LibraryGameUserDTO{
                AddedDate= l.AddedDate,
                Rating= l.Rating,
                HoursPlayed= l.HoursPlayed,
                LastPlayed= l.LastPlayed,
                User = userRepository.GetUserDTO(l.UserID),
                Games= l.Games.Select(g=>new GameDTO{
                    Name=g.Name,
                    Description=g.Description,
                    Price=g.Price,
                    ReleaseDate=g.ReleaseDate,
                    Available=g.Available,
                    Studio=studioRepository.GetStudio(g.StudioID)
                }).ToList()
           }).FirstOrDefault(l=>l.User.UserID==id);
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