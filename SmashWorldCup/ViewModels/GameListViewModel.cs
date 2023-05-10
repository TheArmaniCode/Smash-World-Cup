using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.ViewModels
{
    public class GameListViewModel
    {
        private readonly ICharacterService _characterService;
        private readonly IGameService _gameService;

        public GameListViewModel(ICharacterService characterService, IGameService gameService)
        {

        }

        public GameListViewModel()
        {

        }

        public List<GameModel> GameList { get; set; }
        public CharacterModel Character = new CharacterModel();
    }
}
