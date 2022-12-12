using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class GroupMatchesViewComponent : ViewComponent
    {
        private readonly SmashDbContext _smashDbContext;
        private readonly ITournamentService _tournamentService;

        public GroupMatchesViewComponent(SmashDbContext smashDbContext, ITournamentService tournamentService)
        {
            _smashDbContext = smashDbContext;
            _tournamentService = tournamentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inTournamentID, int inStageID)
        {
            var characters = _tournamentService.GetMatchesByStage(inTournamentID, inStageID);
            return View(characters);
        }
    }
}
