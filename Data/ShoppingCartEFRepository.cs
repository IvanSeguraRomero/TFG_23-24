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

    }
