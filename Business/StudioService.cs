namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class StudioService : IStudioService{
    private readonly IStudioRepository _repository;

    public StudioService(IStudioRepository repository){
        _repository = repository;
    }

    public void AddStudio(Studio studio)
    {
        _repository.AddStudio(studio);
    }

    public void DeleteStudio(int id)
    {
       _repository.DeleteStudio(id);
    }

    public List<StudioDTO> GetAll()
    {
        return _repository.GetAll();
    }

    public StudioDTO GetStudio(int id)
    {
        return _repository.GetStudio(id);
    }

    public StudioDTO GetStudioDTO(int id)
    {
        return _repository.GetStudioDTO(id);
    }

    public List<GameDTO> GetStudioGames(int id)
    {
        return _repository.GetStudioGames(id);
    }

    public void UpdateStudio(Studio studio)
    {
        _repository.UpdateStudio(studio);
    }
}