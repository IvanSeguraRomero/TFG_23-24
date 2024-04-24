using FlashGamingHub.Models;
namespace FlashGamingHub.Business;
    public interface IGameShopService
    {
        void AddGameShop(GameShop gameShop);
        GameShop GetGameShop(int id);
        GameShopDTO GetGameShopDTO(int id);
        void UpdateGameShop(GameShop gameShop);
        void DeleteGameShop(int id);
        List<GameShopDTO> GetAll();
        List<GameDTO> GetGameShopGames(int id);
    }