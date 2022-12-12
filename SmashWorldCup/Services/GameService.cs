using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.Services
{
    public class GameService : IGameService
    {
        private readonly SmashDbContext _smashDbContext;

        public GameService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public List<VenueModel> GetVenuesByGameID(int inGameID)
        {
            return _smashDbContext.Venues.Where(v => v.GameID == inGameID).ToList();
        }
    }
}
