using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Vev.Optimizely.CMS;

namespace YourProject.Models.Blocks
{
    [ContentType(
        DisplayName = "Vev Content Block",
        Description = "A block generated from Vev Studio and published to Optimizely",
        GUID = "92BDABD3-0CC3-4664-B627-813CAEF5E5A4")]
    [SiteImageUrl]
    public class VevContentBlock : BlockData, IVevContent
    {
        public virtual int Version { get; set; }
        public virtual string ProjectId { get; set; }
        [CultureSpecific]
        public virtual string PageKey { get; set; }
        
        [CultureSpecific]
        [Display(Name = "Imported HTML", Description = "The HTML generated in Vev")]
        [UIHint(UIHint.Textarea)]
        public virtual string ImportedHtml { get; set; }
    }
}
