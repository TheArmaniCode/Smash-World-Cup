using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class TournamentRankingsViewComponent : ViewComponent
    {
        private readonly SmashDbContext _smashDbContext;
        private readonly ICharacterService _characterService;

        public TournamentRankingsViewComponent(SmashDbContext smashDbContext, ICharacterService characterService)
        {
            _smashDbContext = smashDbContext;
            _characterService = characterService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inID)
        {
            var rankings = _characterService.GetRankingsByCharacter(inID);
            return View(rankings);
        }
    }
}
