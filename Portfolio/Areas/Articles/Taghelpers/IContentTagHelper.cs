using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Portfolio.Areas.Articles.Data;
using Portfolio.Areas.Articles.Models;

namespace Portfolio.Areas.Articles.Taghelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tag-name")]
    public class IContentTagHelper : TagHelper
    {
        public IContent Content{ get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            if(Content is TextContent)
            {
                var c = Content as TextContent;
                output.Content.SetHtmlContent($@"<p>{c.Text}</p>");
            }else if (Content is CodeContent)
            {
                var c = Content as CodeContent;
                output.TagName = "pre";
                output.Attributes.SetAttribute("class", "pre-scrollable");
                output.PreContent.SetHtmlContent("<code class=\""+c.Type+"\")");
                output.PostContent.SetHtmlContent("</code>");
                output.Content.SetHtmlContent($@"<p>{c.Text}</p>");
            }
            else
            {
                output.Content.SetHtmlContent(Content.ToString());
            }
        }
    }
}
