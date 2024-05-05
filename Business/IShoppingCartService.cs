using FlashGamingHub.Models;

namespace FlashGamingHub.Business
{
    public interface IShoppingCartService
    {
        void AddShoppingCart(ShoppingCart shoppingCart);
        ShoppingCart GetShoppingCart(int id);

        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(int id);
        // List<GameDTO> GetStudioGames(int id);
    }
}