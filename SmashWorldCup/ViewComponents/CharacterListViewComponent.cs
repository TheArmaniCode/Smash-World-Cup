using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class CharacterListViewComponent : ViewComponent
    {
        private readonly ICharacterService _characterService;

        public CharacterListViewComponent(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inAmount, int inCharacterID)
        {
            var characters = _characterService.GetCharacters();
            TempData["Amount"] = inAmount;
            TempData["CharacterID"] = inCharacterID;

            return View(characters);
        }
    }
}
