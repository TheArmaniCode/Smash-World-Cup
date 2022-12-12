using SmashWorldCup.Models;

namespace SmashWorldCup.Interfaces
{
    public interface IGameService
    {
        List<VenueModel> GetVenuesByGameID(int inGameID);
    }
}
