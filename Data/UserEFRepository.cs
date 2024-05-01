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
                MessageID=u.MessageID
            }).ToList();
            return usersDTO;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == id);
            return user;
        }

        public UserDTO GetUserDTO(int id)
        {
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
                MessageID=u.MessageID
            }).FirstOrDefault(user=>user.UserID==id);
            return userDTO;
        }

        public List<UserDTO> getUsersGameId(int gameId)
            {
                var libraryGameUsers = _context.LibraryGameUsers;
                var usersDTO = libraryGameUsers.Where(l => l.Games.Any(g => g.GameID == gameId)).Select(u => new UserDTO{
                    Name=u.User.Name,
                    Surname=u.User.Surname,
                    Password=u.User.Password,
                    Age=u.User.Age,
                    Email=u.User.Email,
                    RegisterDate=u.User.RegisterDate,
                    Active=u.User.Active
                }).ToList();   
                return usersDTO;      
            }


        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

          public void SaveChanges()
        {
            _context.SaveChanges();
        }
         public List<CommunityDTO> GetMessagesUser(int userId)
            {
                var messagesDTO = _context.Communities.Where(c => c.UserID == userId).Select(c => new CommunityDTO
                    {
                        MessageID = c.MessageID,
                        UserID = c.UserID,
                        Message = c.Message,
                        PublicationDate = c.PublicationDate,
                        LikesCount=c.LikesCount
                        }).ToList();
                return messagesDTO;
            }
    }
}