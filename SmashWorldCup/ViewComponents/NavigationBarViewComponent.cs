using Microsoft.AspNetCore.Mvc;

namespace SmashWorldCup.ViewComponents
{
    public class NavigationBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
