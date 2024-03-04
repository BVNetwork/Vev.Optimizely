using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Vev.Optimizely.CMS;

namespace YourProject.Models.Pages
{
    [ContentType(
        DisplayName = "Vev Content Page",
        Description = "A page generated from Vev Studio and published to Optimizely",
        GUID = "E9A8A087-7A09-4A4C-A984-E06063043CB4")]
    [SiteImageUrl]
    public class VevContentPage : SitePageData, IVevPageContent
    {
        public virtual int Version { get; set; }
        public virtual string ProjectId { get; set; }
        [CultureSpecific]
        public virtual string PageKey { get; set; }
        
        [CultureSpecific]
        [Display(Name = "Imported HTML", Description = "The HTML generated in Vev")]
        [UIHint(UIHint.Textarea)]
        public virtual string ImportedHtml { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            HideSiteFooter = true;
            HideSiteHeader = true;
        }
    }

}
