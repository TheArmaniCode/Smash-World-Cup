using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class TournamentFinishesViewComponent : ViewComponent
    {
        private readonly ITournamentService _tournamentService;

        public TournamentFinishesViewComponent( ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inTournamentID)
        {
            var characters = _tournamentService.GetTopFourCharacters(inTournamentID);

            TempData["WinnerTitles"] = _tournamentService.GetCharacterFinish(characters[0].ID, inTournamentID);

            return View(characters);
        }
    }
}
