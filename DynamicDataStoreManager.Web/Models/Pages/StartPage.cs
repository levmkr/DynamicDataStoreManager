using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace DynamicDataStoreManager.Web.Models.Pages
{
    [ContentType(DisplayName = "Start Page", GUID = "4ad9231b-baa3-42fa-8756-e9396f20b182", Description = "")]
    public class StartPage : PageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}