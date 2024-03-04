using YourProject.Models.Blocks;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace YourProject.Controllers
{
    public class VevGenericBlockViewComponent : BlockComponent<VevContentBlock>
    {

        protected override IViewComponentResult InvokeComponent(VevContentBlock currentContent)
        {
            // Returns the raw HTML for the block. You can alter the html before 
            // rendering, but beware that this might be a large string, and can be 
            // time consuming. Consider caching the changed html.
            if (string.IsNullOrEmpty(currentContent.ImportedHtml) == false)
                return new HtmlContentViewComponentResult(new HtmlString(currentContent.ImportedHtml));

            // Can happen if the block is created manually, or something failed 
            // during import
            return Content("This block has no imported HTML");

        }

    }
}
