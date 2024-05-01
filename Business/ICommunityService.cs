using FlashGamingHub.Models;
namespace FlashGamingHub.Business;

    public interface ICommunityService
    {
        void AddCommunity(Community community);
        Community GetCommunity(int id);
        CommunityDTO GetCommunityDTO(int id);
        void UpdateCommunity(Community community);
        void DeleteCommunity(int id);
        List<CommunityDTO> GetAll();
    }