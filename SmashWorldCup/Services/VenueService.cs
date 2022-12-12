using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.Services
{
    public class VenueService : IVenueService
    {
        private readonly SmashDbContext _smashDbContext;

        public VenueService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public List<VenueModel> GetVenues()
        {
            return _smashDbContext.Venues.ToList();
        }
    }
}
