using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class RatingListViewComponent : ViewComponent
    {
        private readonly ICharacterService _characterService;

        public RatingListViewComponent(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inCharacterID)
        {
            var character = _characterService.GetCharacterByID(inCharacterID);

            return View(character);
        }
    }
}
