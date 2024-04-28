using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface IStudioRepository
    {
        void AddStudio(Studio studio);
        Studio GetStudio(int id);
        StudioDTO GetStudioDTO(int id);
        void UpdateStudio(Studio studio);
        void DeleteStudio(int id);
        List<StudioDTO> GetAll();
        List<GameDTO> GetStudioGames(int id);
    }
}