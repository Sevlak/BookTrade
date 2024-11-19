using Microsoft.AspNetCore.Mvc;

namespace BookTrade.Web.ViewComponents;

public class TradesViewComponent: ViewComponent
{
    //TODO: We should gather all ongoing trades for the user here
    public TradesViewComponent()
    {
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var test = new List<string> { "Test1", "Test2", "Test3" };
        return View(test);
    }
}