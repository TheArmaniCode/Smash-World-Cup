using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.Controllers
{
    public class DrawController : Controller
    {

        private readonly ILogger<DrawController> _logger;
        private readonly ICharacterService _characterService;

        public DrawController(ILogger<DrawController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
        }
        public IActionResult Index()
        {
            var characters = _characterService.GetCharacters();

            return View(characters);
        }

        public IActionResult FinalsDraw()
        {
            return View();
        }
    }
}
