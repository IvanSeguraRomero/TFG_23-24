using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data
{
    public class CommunityEFRepository : ICommunityRepository
    {
        public readonly Context _context;

        public CommunityEFRepository(Context context) => _context = context;

        public void AddCommunity(Community community)
        {
            _context.Communities.Add(community);
            SaveChanges();
        }

        public void DeleteCommunity(int id)
        {
           var community=_context.Communities.Find(id);
           if(community==null){
                throw new KeyNotFoundException("Community not found.");
            }
            _context.Communities.Remove(community);
            SaveChanges();
        }

        public List<CommunityDTO> GetAll()
        {
            var communities=_context.Communities.Include(c=>c.User).ToList();
            var communitiesDTO=communities.Select(c=>new CommunityDTO{
                MessageID=c.MessageID,
                UserID=c.UserID,
                GameID=c.GameID,
                Message=c.Message,
                PublicationDate=c.PublicationDate,
                Edited=c.Edited,
                LikesCount=c.LikesCount
            }).ToList();
            return communitiesDTO;
        }

        public Community GetCommunity(int id)
        {
            var community=_context.Communities.Include(c=>c.User).FirstOrDefault(c=>c.MessageID==id);
            return community;
        }

        public CommunityDTO GetCommunityDTO(int id)
        {
            var communities=_context.Communities.Include(c=>c.User).ToList();
            var communitieDTO=communities.Select(c=>new CommunityDTO{
                MessageID=c.MessageID,
                UserID=c.UserID,
                GameID=c.GameID,
                Message=c.Message,
                PublicationDate=c.PublicationDate,
                Edited=c.Edited,
                LikesCount=c.LikesCount
            }).FirstOrDefault(community=>community.MessageID == id);
            Console.WriteLine(communitieDTO);
            return communitieDTO;
        }

        public List<CommunityDTO> getMessagesGame(int gameID)
         {
                // Filtrar las comunidades por GameID
                var communities = _context.Communities.Include(c => c.User).Where(c => c.GameID == gameID).ToList();
                
                // Mapear las comunidades filtradas a CommunityDTO
                var communitieDTO = communities.Select(c => new CommunityDTO
                {
                    MessageID = c.MessageID,
                    UserID = c.UserID,
                    GameID = c.GameID,
                    Message = c.Message,
                    PublicationDate = c.PublicationDate,
                    Edited = c.Edited,
                    LikesCount = c.LikesCount
                }).ToList();
                return communitieDTO;
            }




        public void UpdateCommunity(Community community)
        {
            _context.Entry(community).State=EntityState.Modified;
            SaveChanges();
        }

         public void SaveChanges()
        {
            _context.SaveChanges();
        }
       

    }
}