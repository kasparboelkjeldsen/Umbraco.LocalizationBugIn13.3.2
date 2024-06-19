using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Umbraco13._4._0_rc2.Controllers
{
    public class CustomVirtualPageController : UmbracoPageController, IVirtualPageController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        public CustomVirtualPageController(ILogger<UmbracoPageController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public IPublishedContent? FindContent(ActionExecutingContext actionExecutingContext)
        {
            _umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext);

            return umbracoContext.Content.GetAtRoot().FirstOrDefault();
        }

        public IActionResult Index()
        {
            return View("VirtualPage", CurrentPage);
        }
    }
}
