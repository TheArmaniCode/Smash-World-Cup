using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.ViewComponents
{
    public class VenueListViewComponent : ViewComponent
    {
        private readonly IVenueService _venueService;
        private readonly IGameService _gameService;

        public VenueListViewComponent(IVenueService venueService, IGameService gameService)
        {
            _venueService = venueService;
            _gameService = gameService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inGameID, int inVenueID)
        {
            var venues = new List<VenueModel>();

            if(inGameID != 0) venues = _gameService.GetVenuesByGameID(inGameID).ToList();
            else venues = _venueService.GetVenues().ToList();

            if (inVenueID != 0) TempData["VenueID"] = inVenueID;

            return View(venues);
        }
    }
}
