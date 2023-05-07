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

        public List<GameModel> GetGames()
        {
            return _smashDbContext.Games.ToList();
        }

        public GameModel GetGameById(int inGameID)
        {
            return _smashDbContext.Games.SingleOrDefault(g => g.ID == inGameID);
        }

        public List<VenueModel> GetVenuesByGameID(int inGameID)
        {
            return _smashDbContext.Venues.Where(v => v.GameID == inGameID).ToList();
        }
    }
}
