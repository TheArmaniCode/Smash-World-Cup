using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;
using System.Globalization;

namespace SmashWorldCup.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int inFighterID1, int inFighterID2, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inSuddenDeath)
        {
            TempData["message"] = _matchService.AddMatch(inFighterID1, inFighterID2, inScore1, inScore2, inTournamentID, inStageID, inDate, inVenueID, inSuddenDeath);

            return View();
        }

        public IActionResult EditMatch(int inMatchID)
        {
            var match = _matchService.GetMatchByID(inMatchID);

            var dt = new DateTime();

            if(match.Date != null) dt = match.Date ?? DateTime.UtcNow;       

            TempData["dt"] = dt.ToString("yyyy-MM-dd HH:mm:ss");

            return View(match);
        }

        [HttpPost]
        public IActionResult EditMatch(int inMatchID, int inFighterID1, int inFighterID2, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inFighterID3)
        {
            _matchService.EditMatch(inMatchID, inFighterID1, inFighterID2, inScore1, inScore2, inTournamentID, inStageID, inDate, inVenueID, inFighterID3);

            if(inStageID >= 19) return RedirectToAction("Index", "Tournament", new { inTournamentID = inTournamentID });
            else return RedirectToAction("Qualifiers", "Tournament", new { inTournamentID = inTournamentID });
        }
    }
}
