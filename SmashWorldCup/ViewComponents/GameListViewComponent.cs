using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class GameListViewComponent : ViewComponent
    {
        private readonly IGameService _gameService;

        public GameListViewComponent(SmashDbContext smashDbContext, IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inGameID)
        {
            var games = _gameService.GetGames();
            TempData["currentGameID"] = _gameService.GetGameById(inGameID).ID;

            return View(games);
        }
    }
}
