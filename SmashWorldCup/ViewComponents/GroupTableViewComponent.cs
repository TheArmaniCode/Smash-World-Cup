using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class GroupTableViewComponent : ViewComponent
    {
        private readonly ITournamentService _tournamentService;

        public GroupTableViewComponent(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inTournamentID, int inStageID)
        {
            var table = _tournamentService.CalculateTable(inTournamentID, inStageID);
            return View(table);
        }
    }
}
