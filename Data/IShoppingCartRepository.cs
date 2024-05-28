using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface IShoppingCartRepository
    {
        void AddShoppingCart(ShoppingCart shoppingCart);
        ShoppingCart GetShoppingCart(int id);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
        void DeleteShoppingCart(int id);
        void AddGameToShoppingCart(int shoppingCartId, int gameId);

         void RemoveGameFromShoppingCart(int shoppingCartId, int gameId);
        
    }
}