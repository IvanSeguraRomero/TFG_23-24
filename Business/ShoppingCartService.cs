namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;

public class ShoppingCartService : IShoppingCartService{

    private readonly IShoppingCartRepository _repository;

    public ShoppingCartService(IShoppingCartRepository repository){
        _repository = repository;
    }

    public void AddGameToShoppingCart(int shoppingCartId, int gameId)
    {
        _repository.AddGameToShoppingCart(shoppingCartId,gameId);
    }

    public void AddShoppingCart(ShoppingCart shoppingCart)
    {
        _repository.AddShoppingCart(shoppingCart);
    }

    public void DeleteShoppingCart(int id)
    {
        _repository.DeleteShoppingCart(id);
    }

    public ShoppingCart GetShoppingCart(int id)
    {
        return _repository.GetShoppingCart(id);
    }

    public void RemoveGameFromShoppingCart(int shoppingCartId, int gameId)
    {
        _repository.RemoveGameFromShoppingCart(shoppingCartId,gameId);
    }

    public void UpdateShoppingCart(ShoppingCart shoppingCart)
    {
        _repository.UpdateShoppingCart(shoppingCart);
    }
}