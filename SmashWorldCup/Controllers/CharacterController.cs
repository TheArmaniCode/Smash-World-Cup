using Grpc.Core;
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
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CharacterController(SmashDbContext smashDbContext, ICharacterService characterService, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _smashDbContext = smashDbContext;
            _characterService = characterService;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Properties(int inCharacterID, string inName, int inGameID, int inRating, string inColor, string inTextColor, IFormFile inLogo)
        {
            _characterService.UpdateCharacterProperties(inCharacterID, inName, inGameID, inRating, inColor, inTextColor, inLogo.FileName);

            if (inLogo != null && !System.IO.File.Exists("\\img\\Logos\\" + inLogo.FileName))
            {
                _fileService.AddLogo(inLogo);
            }

            return View(inCharacterID);
        }
    }
}
