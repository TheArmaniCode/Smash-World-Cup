using SmashWorldCup.Models;

namespace SmashWorldCup.Interfaces
{
    public interface IGameService
    {
        List<GameModel> GetGames();
        GameModel GetGameById(int inGameID);
        List<VenueModel> GetVenuesByGameID(int inGameID);
    }
}
