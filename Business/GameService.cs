namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class GameService : IGameService
{   
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository){
        _repository = repository;
    }
    public void AddGame(Game game)
    {
        _repository.AddGame(game);
    }

    public void DeleteGame(int id)
    {
        _repository.DeleteGame(id);
    }

    public List<GameDTO> GetAll()
    {
        return _repository.GetAll();
    }

    public Game GetGame(int id)
    {
        return _repository.GetGame(id);
    }

    public GameDTO GetGameDTO(int id)
    {
        return _repository.GetGameDTO(id);
    }

    public void UpdateGame(Game game)
    {
        _repository.UpdateGame(game);
    }
}