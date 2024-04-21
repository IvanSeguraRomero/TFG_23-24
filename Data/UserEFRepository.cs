using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class UserEFRepository : IUserRepository
    {
        public readonly Context _context;

        public UserEFRepository(Context context) => _context = context;

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user=_context.Users.Find(id);
            if(user==null){
                throw new KeyNotFoundException("User not found.");
            }
            _context.Users.Remove(user);
            SaveChanges();
        }

        public List<UserDTO> GetAll()
        {
            //falta posible include en linea 33 para games y messages
            var gamesRepository=new GameEFRepository(_context);
            var messagesRepository=new CommunityEFRepository(_context);
            var users=_context.Users.ToList();
            var usersDTO=users.Select(u=>new UserDTO{
                UserID=u.UserID,
                Name = u.Name,
                Surname=u.Surname,
                Password=u.Password,
                Age=u.Age,
                Email = u.Email,
                RegisterDate=u.RegisterDate,
                Active=u.Active,
                games=gamesRepository.GetGamesUser(u.UserID),
                messages=messagesRepository.GetMessagesUser(u.UserID)
            }).ToList();
            return usersDTO;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public UserDTO GetUserDTO(int id)
        {
           var gamesRepository=new GameEFRepository(_context);
           var messagesRepository=new CommunityEFRepository(_context);
           var users=_context.Users.ToList();
            var userDTO=users.Select(u=>new UserDTO{
                UserID=u.UserID,
                Name = u.Name,
                Surname=u.Surname,
                Password=u.Password,
                Age=u.Age,
                Email = u.Email,
                RegisterDate=u.RegisterDate,
                Active=u.Active,
                games=gamesRepository.GetGamesUser(u.UserID),
                messages=messagesRepository.GetMessagesUser(u.UserID)
            }).FirstOrDefault(user=>user.UserID==id);
            return userDTO;
        }

        //necesito de alguna forma acceder a los juegos de UserDTO pero este actualmente en el context es User y no tiene games
        // public List<UserDTO> getUsersGame(int id){

        //     var users = _context.Users
        //     .Where(u => u.games.Any(g => g.GameID == id))
        //     .Select(u => new UserDTO
        //     {
        //         UserID = u.UserID,
        //         Name = u.Name,
        //         Surname = u.Surname,
        //         Password = u.Password,
        //         Age = u.Age,
        //         Email = u.Email,
        //         RegisterDate = u.RegisterDate,
        //         Active = u.Active,
        //         games = u.Games.Select(g => new GameDTO
        //         {
        //             // Asigna las propiedades del juego según sea necesario
        //         }).ToList()
        //     })
        //     .ToList();

        //     return users;
        // }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

          public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}