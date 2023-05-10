using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Controllers
{
    public class CharacterController : Controller
    {
        private readonly SmashDbContext _smashDbContext;
        private readonly ICharacterService _characterService;
        public CharacterController(SmashDbContext smashDbContext, ICharacterService characterService)
        {
            _smashDbContext = smashDbContext;
            _characterService = characterService;
        }

        public IActionResult Index(string inSearchValue, string inSearchCategory)
        {
            List<CharacterModel> characters;

            if (inSearchValue != null)
            {
                characters = _characterService.SearchCharacters(inSearchValue, inSearchCategory);
            }
            else
            {
                characters = _characterService.GetCharacters();
            }

            return View(characters);
        }

        public IActionResult CharacterRecord(int inCharacterID)
        {
            var character = _characterService.GetCharacterForView(inCharacterID);

            return View(character);
        }

        public IActionResult Properties(int inCharacterID)
        {
            var character = _characterService.GetCharacterForView(inCharacterID);

            return View(character);
        }

        [HttpPost]
        public IActionResult Properties(int inCharacterID, string inName, int inGameID, int inRating, string inColor, string inTextColor, string inLogo)
        {
            _characterService.UpdateCharacterProperties(inCharacterID, inName, inGameID, inRating, inColor, inTextColor, inLogo);

            if (inLogo != null && !System.IO.File.Exists("/img/Logos/" + inLogo))
            {

            }

            return View(inCharacterID);
        }
    }
}
