using YourProject.Models.Pages;
using YourProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace YourProject.Controllers
{
    public class VevContentPageController : PageControllerBase<VevContentPage>
    {

        public IActionResult Index(VevContentPage currentPage)
        {
            
            var model = PageViewModel.Create(currentPage);
            return View(model);
            
            // Returns the HTML raw. You can alter the html before rendering,
            // but beware that this might be a large string, and can be time
            // consuming. Consider caching the changed html
            if (string.IsNullOrEmpty(currentPage.ImportedHtml) == false)
                return GeneratePageHtml(currentPage.ImportedHtml);

            // If the page has been created but no HTML has been imported,
            // or if the page has been created manually. Shows a simple message.
            return Content("This page has no imported HTML", "text/plain");
        }

        public ContentResult GeneratePageHtml(string vevContent)
        {
            string htmlWrapperBegin = "<html><head></head><body>";
            string htmlWrapperEnd = "</body></html>";
                
            return Content( htmlWrapperBegin + vevContent + htmlWrapperEnd, "text/html");
        }
    }
}
