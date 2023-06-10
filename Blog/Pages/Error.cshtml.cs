using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Pages
{
    /// <summary>Represents an error page view model.</summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        /// <summary>Gets or sets the request identifier.</summary>
        public string? RequestId { get; set; }

        /// <summary>
        ///     Gets whether to show the request identifier.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if request identifier is not null or whitespace; 
        ///   otherwise, <see langword="false" />.
        /// </value>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}