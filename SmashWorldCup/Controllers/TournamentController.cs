using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Controllers
{
    public class TournamentController : Controller
    {
        public SmashDbContext _smashDbContext;
        public IMatchService _matchService;
        public ITournamentService _tournamentService;
        public TournamentController(SmashDbContext smashDbContext, IMatchService matchService, ITournamentService tournamentService)
        {
            _smashDbContext = smashDbContext;
            _matchService = matchService;
            _tournamentService = tournamentService;
        }

        public IActionResult Index()
        {
            var tournaments = _tournamentService.GetTournaments();

            HttpContext.Session.SetInt32("TournamentsCount", tournaments.Count);

            return View(tournaments);
        }

        public IActionResult ViewTournament(int inTournamentID)
        {
            var tournament = _tournamentService.GetTournamentByID(inTournamentID);

            TempData["TournamentsCount"] = HttpContext.Session.GetInt32("TournamentsCount");

            return View(tournament);
        }

        [HttpPost]
        public IActionResult EditMatch(int inMatchID, int inStageID)
        {
            return RedirectToAction("EditMatch", "Match", new { inMatchID = inMatchID, inStageID = inStageID});
        }

        public IActionResult Qualifiers(int inTournamentID)
        {
            var tournament = _tournamentService.GetTournamentByID(inTournamentID);

            TempData["TournamentsCount"] = HttpContext.Session.GetInt32("TournamentsCount");

            return View(tournament);
        }
    }
}
