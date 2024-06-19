using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco13._4._0_rc2.Controllers;

namespace Umbraco13._4._0_rc2.Composers
{
    public class SillyRouteComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.Configure<UmbracoPipelineOptions>(options =>
            {
                options.AddFilter(new UmbracoPipelineFilter(nameof(CustomVirtualPageController))
                {
                    Endpoints = app => app.UseEndpoints(e =>
                    {
                        // danish
                        e.MapControllerRoute("CustomVirtualPageController", "/silly", new { Controller = "CustomVirtualPage", Action = "Index" });

                    })
                });
            });

        }
    }
}
