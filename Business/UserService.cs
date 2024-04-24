namespace FlashGamingHub.Business;

using FlashGamingHub.Models;
using FlashGamingHub.Data;
using System.Collections.Generic;

public class UserService : IUserService{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository){
        _repository = repository;
    }

    public void AddUser(User user)
    {
        _repository.AddUser(user);
    }

    public void DeleteUser(int id)
    {
        _repository.DeleteUser(id);
    }

    public List<UserDTO> GetAll()
    {
        return _repository.GetAll();
    }

    public User GetUser(int id)
    {
        return _repository.GetUser(id);
    }

    public UserDTO GetUserDTO(int id)
    {
        return _repository.GetUserDTO(id);
    }

    public void UpdateUser(User user)
    {
        _repository.UpdateUser(user);
    }
}