using Microsoft.AspNetCore.Mvc;
using SmashWorldCup.Interfaces;

namespace SmashWorldCup.ViewComponents
{
    public class StageListViewComponent : ViewComponent
    {
        private readonly IStageService _stageService;

        public StageListViewComponent(IStageService stageService)
        {
            _stageService = stageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int inStageID)
        {
            var stages = _stageService.GetStages();
            if (inStageID != 0) TempData["StageID"] = inStageID;
            return View(stages);
        }
    }
}
