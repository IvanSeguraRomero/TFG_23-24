using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface IGameShopRepository
    {
        void AddGameShop(GameShop gameShop);
        GameShop GetGameShop(int id);
        GameShopDTO GetGameShopDTO(int id);
        void UpdateGameShop(GameShop gameShop);
        void DeleteGameShop(int id);
        List<GameShopDTO> GetAll();
        List<GameDTO> GetGamesShop(int id);
    }
}