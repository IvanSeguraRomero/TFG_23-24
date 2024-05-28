using FlashGamingHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashGamingHub.Data;
    public class ShoppingCartEFRepository : IShoppingCartRepository
    {

        public readonly Context _context;
        public ShoppingCartEFRepository(Context context) => _context = context;



        public void AddShoppingCart(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            SaveChanges();
        }

        public void DeleteShoppingCart(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Find(id);
            if (shoppingCart == null){
                throw new KeyNotFoundException("ShoppingCart not found.");
            }
            _context.ShoppingCarts.Remove(shoppingCart);
            SaveChanges();
        }

        public ShoppingCart GetShoppingCart(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Include(sc => sc.Games).FirstOrDefault(s => s.ShoppingCartID == id);
            
            return shoppingCart;
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            _context.Entry(shoppingCart).State=EntityState.Modified;
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddGameToShoppingCart(int shoppingCartId, int gameId)
        {
            var shoppingCart = _context.ShoppingCarts
                .Include(sh => sh.Games)
                .FirstOrDefault(l => l.UserID == shoppingCartId);

            if (shoppingCart == null)
            {
                throw new KeyNotFoundException("ShoppingCart not found.");
            }

            var game = _context.Games.Find(gameId);
            if (game == null)
            {
                throw new KeyNotFoundException("Game not found.");
            }

            if (shoppingCart.Games.Any(g => g.GameID == gameId))
            {
                throw new InvalidOperationException("Game already in ShoppingCart.");
            }
            shoppingCart.Games.Add(game);
            SaveChanges();
        }

    public void RemoveGameFromShoppingCart(int shoppingCartId, int gameId)
    {
            var shoppingCart = _context.ShoppingCarts
                .Include(l => l.Games)
                .FirstOrDefault(l => l.ShoppingCartID == shoppingCartId);

            if (shoppingCart == null)
            {
                throw new KeyNotFoundException("ShoppingCart not found.");
            }

            var game = shoppingCart.Games.FirstOrDefault(g => g.GameID == gameId);
            if (game == null)
            {
                throw new KeyNotFoundException("Game not found in ShoppingCart.");
            }

            shoppingCart.Games.Remove(game);
            SaveChanges();
        }

    }
