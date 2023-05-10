using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.ViewModels;
using System.Dynamic;

namespace SmashWorldCup.ViewComponents
{
    public class GameListViewComponent : ViewComponent
    {
        private readonly ICharacterService _characterService;
        private readonly IGameService _gameService;

        public GameListViewComponent(SmashDbContext smashDbContext, ICharacterService characterService, IGameService gameService)
        {
            _characterService = characterService;
            _gameService = gameService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inCharacterID = 0)
        {
            var gameListModel = new GameListViewModel();

            gameListModel.GameList = _gameService.GetGames();
            if(inCharacterID != 0)
            {
                gameListModel.Character = _characterService.GetCharacterByID(inCharacterID);
            }

            return View(gameListModel);

        }
    }
}
