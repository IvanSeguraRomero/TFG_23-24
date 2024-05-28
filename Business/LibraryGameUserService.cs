namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class LibraryGameUserService : ILibraryGameUserService{
    private readonly ILibraryGameUserRepository _repository;
    public LibraryGameUserService(ILibraryGameUserRepository repository) { 
        _repository = repository;
    }

    public void AddLibraryGameUser(LibraryGameUser libraryGameUser)
    {
        _repository.AddLibraryGameUser(libraryGameUser);
    }

    public void DeleteLibraryGameUser(int id)
    {
        _repository.DeleteLibraryGameUser(id);
    }

    public List<LibraryGameUserDTO> GetAll()
    {
        return _repository.GetAll();
    }

    public LibraryGameUser GetLibraryGameUser(int id)
    {
        return _repository.GetLibraryGameUser(id);
    }

    public LibraryGameUserDTO GetLibraryGameUserDTO(int id)
    {
        return _repository.GetLibraryGameUserDTO(id);
    }

    public List<GameDTO> GetLibraryGameUserGames(int id)
    {
         return _repository.GetLibraryGameUserGames(id);
    }

    public void UpdateLibraryGameUser(LibraryGameUser libraryGameUser)
    {
        _repository.UpdateLibraryGameUser(libraryGameUser);
    }

    public void AddGameToLibraryGameUser(int libraryGameUserID, int gameId){
        _repository.AddGameToLibraryGameUser(libraryGameUserID, gameId);
    }
}