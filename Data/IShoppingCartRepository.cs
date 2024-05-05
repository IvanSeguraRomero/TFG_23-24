using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface IShoppingCartRepository
    {
        void AddShoppingCart(ShoppingCart shoppingCart);
        ShoppingCart GetShoppingCart(int id);
        // ShoppingCart GetShoppingCart(int id);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(int id);
        // List<GameDTO> GetStudioGames(int id);
        
    }
}