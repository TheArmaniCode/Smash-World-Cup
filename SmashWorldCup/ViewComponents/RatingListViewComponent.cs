using Microsoft.AspNetCore.Mvc;

namespace SmashWorldCup.ViewComponents
{
    public class RatingListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
