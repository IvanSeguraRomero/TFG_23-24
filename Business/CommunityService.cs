namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class CommunityService : IGameService{
    private readonly ICommunityRepository _repository;

    public CommunityService(ICommunityRepository repository){
        _repository = repository;
    }

    public void AddCommunity(Community community)
    {
        _repository.AddCommunity(community);
    }

    public void DeleteCommunity(int id)
    {
        _repository.DeleteCommunity(id);
    }

    public List<CommunityDTO> GetAll()
    {
       return _repository.GetAll();
       
    }

    public Community GetCommunity(int id)
    {
        return _repository.GetCommunity(id);
    }

    public CommunityDTO GetCommunityDTO(int id)
    {
        return _repository.GetCommunityDTO(id);
    }

    public void UpdateCommunity(Community community)
    {
        _repository.UpdateCommunity(community);
    }
}