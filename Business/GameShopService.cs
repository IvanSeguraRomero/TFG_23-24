namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class GameShopService : IGameShopService{
    private readonly IGameShopRepository _repository;

    public GameShopService(IGameShopRepository repository){
        _repository = repository;
    }

    public void AddGameShop(GameShop gameShop)
    {
        _repository.AddGameShop(gameShop);
    }

    public void DeleteGameShop(int id)
    {
        _repository.DeleteGameShop(id);
    }

    public List<GameShopDTO> GetAll()
    {
        return _repository.GetAll();
    }

    public GameShop GetGameShop(int id)
    {
        return _repository.GetGameShop(id);
    }

    public GameShopDTO GetGameShopDTO(int id)
    {
        return _repository.GetGameShopDTO(id);
    }

    public List<GameDTO> GetGameShopGames(int id)
    {
        return _repository.GetGameShopGames(id);
    }

    public void UpdateGameShop(GameShop gameShop)
    {
        _repository.UpdateGameShop(gameShop);
    }
}