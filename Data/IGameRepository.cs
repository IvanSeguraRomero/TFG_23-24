using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface IGameRepository
    {
        void AddGame(Game game);
        Game GetGame(int id);
        GameDTO GetGameDTO(int id);
        void UpdateGame(Game game);
        void DeleteGame(int id);
        List<GameDTO> GetAll();
    }
}