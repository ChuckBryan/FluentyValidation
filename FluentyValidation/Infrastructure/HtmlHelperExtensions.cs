using System.Web.Mvc;
using HtmlTags;

namespace FluentyValidation.Infrastructure
{
    public static class HtmlHelperExtensions
    {
        public static HtmlTag ValidationDiv(this HtmlHelper helper)
        {
            return new HtmlTag("div")
                .Id("validationSummary")
                .AddClass("alert")
                .AddClass("alert-danger")
                .AddClass("hidden");
        }
    }
}