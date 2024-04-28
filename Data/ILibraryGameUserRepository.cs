using FlashGamingHub.Models;

namespace FlashGamingHub.Data
{
    public interface ILibraryGameUserRepository{
        void AddLibraryGameUser(LibraryGameUser libraryGameUser);
        LibraryGameUser GetLibraryGameUser(int id);
        LibraryGameUserDTO GetLibraryGameUserDTO(int id);
        void UpdateLibraryGameUser(LibraryGameUser libraryGameUser);
        void DeleteLibraryGameUser(int id);
        List<LibraryGameUserDTO> GetAll();
        List<GameDTO> GetLibraryGameUserGames(int id);
    }
    
}