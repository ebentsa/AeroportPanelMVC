using System.Collections.Generic;
using System.Web.Mvc;

namespace AeroportWeb.ExtentionMethods
{
    public static class HtmlButtonExtension
    {

        public static MvcHtmlString Button(this HtmlHelper helper,
            string innerHtml,
            object htmlAttributes)
        {
            return Button(helper, innerHtml,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper,
            string innerHtml,
            IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button")
            {
                InnerHtml = innerHtml
            };
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
    public static class ImageHelper

    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}