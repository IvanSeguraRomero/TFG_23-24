using FlashGamingHub.Models;
namespace FlashGamingHub.Business;
    public interface IStudioService
    {
        void AddStudio(Studio studio);
        StudioDTO GetStudio(int id);
        StudioDTO GetStudioDTO(int id);
        void UpdateStudio(Studio studio);
        void DeleteStudio(int id);
        List<StudioDTO> GetAll();
        List<GameDTO> GetStudioGames(int id);
    }