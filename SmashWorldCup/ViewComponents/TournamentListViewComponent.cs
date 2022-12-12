using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class TournamentListViewComponent : ViewComponent
    {
        private readonly ITournamentService _tournamentService;

        public TournamentListViewComponent(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inTournamentID)
        {
            var tournaments = _tournamentService.GetTournaments().ToList();

            if (inTournamentID != 0) TempData["TournamentID"] = inTournamentID;

            return View(tournaments);
        }
    }
}
