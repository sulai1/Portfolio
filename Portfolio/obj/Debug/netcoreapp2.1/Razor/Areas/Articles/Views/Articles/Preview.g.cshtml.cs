#pragma checksum "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2a5c138cda3f993d0f5f3c8cb70cb0415a47642"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Articles_Views_Articles_Preview), @"mvc.1.0.view", @"/Areas/Articles/Views/Articles/Preview.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Articles/Views/Articles/Preview.cshtml", typeof(AspNetCore.Areas_Articles_Views_Articles_Preview))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\_ViewImports.cshtml"
using Portfolio.Areas.Articles;

#line default
#line hidden
#line 2 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\_ViewImports.cshtml"
using Portfolio.Areas.Articles.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2a5c138cda3f993d0f5f3c8cb70cb0415a47642", @"/Areas/Articles/Views/Articles/Preview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"306c43694970d59a4863eacb99501916a8966794", @"/Areas/Articles/Views/_ViewImports.cshtml")]
    public class Areas_Articles_Views_Articles_Preview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Portfolio.Areas.Articles.Models.Article>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffe53ea52f2446bea623ac0cf819f47e", async() => {
                BeginContext(54, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(60, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d25f00fadd14acf8f96be8417ae6017", async() => {
                    BeginContext(114, 6, true);
                    WriteLiteral("\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(129, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(138, 910, true);
            WriteLiteral(@"

<div class=""container-fluid"">
    <div class=""row flex-sm-row-reverse"">
        <div class=""col-3 flex-sm-column-reverse"">
            <div class=""affix "" id=""sidebar"">
                <div class=""row"">
                    <div class=""col"">
                        <h3>
                            Overview
                        </h3>
                    </div>
                    <div class=""col"">
                        <button class=""btn btn-primary active"" type=""button"" data-toggle=""collapse"" data-target=""#overview"" aria-expanded=""true"" aria-controls=""collapse"">
                            <span class=""glyphicon glyphicon-menu-up"" aria-hidden=""true"" id=""icon""></span>
                        </button>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col"">
                    </div>
                </div>
");
            EndContext();
#line 27 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 if (Model.Sections != null)
                {

#line default
#line hidden
            BeginContext(1113, 107, true);
            WriteLiteral("                    <div class=\"collapse\" id=\"overview\">\r\n                        <ul class=\"list-group\">\r\n");
            EndContext();
#line 31 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                             foreach (var item in Model.Sections)
                            {

#line default
#line hidden
            BeginContext(1318, 62, true);
            WriteLiteral("                                <li class=\"list-group-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1380, "\"", 1399, 2);
            WriteAttributeValue("", 1387, "#", 1387, 1, true);
#line 33 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
WriteAttributeValue("", 1388, item.Title, 1388, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1400, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1402, 10, false);
#line 33 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1412, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 34 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                            }

#line default
#line hidden
            BeginContext(1454, 59, true);
            WriteLiteral("                        </ul>\r\n                    </div>\r\n");
            EndContext();
#line 37 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                }

#line default
#line hidden
            BeginContext(1532, 81, true);
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"col-9\">\r\n            <h2>");
            EndContext();
            BeginContext(1614, 11, false);
#line 41 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1625, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 42 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
             if (@Model.Sections != null)
            {
                

#line default
#line hidden
#line 44 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 foreach (var item in @Model.Sections)
                {


#line default
#line hidden
            BeginContext(1767, 70, true);
            WriteLiteral("                    <h3 class=\"smooth-goto\">\r\n                        ");
            EndContext();
            BeginContext(1838, 10, false);
#line 48 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                   Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1848, 126, true);
            WriteLiteral("\r\n                        <button class=\"btn btn-primary\" type=\"button\" expanded=\"false\" data-toggle=\"collapse\" data-target=\"#");
            EndContext();
            BeginContext(1975, 10, false);
#line 49 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                                                                       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1985, 112, true);
            WriteLiteral("\"></button>\r\n                    </h3>\r\n                    <hr />\r\n                    <div class=\"collapse in\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2097, "\"", 2113, 1);
#line 52 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
WriteAttributeValue("", 2102, item.Title, 2102, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2114, 151, true);
            WriteLiteral(">\r\n                        <div class=\"breadcrumb\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col\">\r\n");
            EndContext();
#line 56 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                     if (@item.Content != null)
                                    {
                                        

#line default
#line hidden
            BeginContext(2410, 23, false);
#line 58 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                   Write(Html.Raw(@item.Content));

#line default
#line hidden
            EndContext();
#line 58 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(2555, 93, true);
            WriteLiteral("                                        <p class=\"alert-danger\">To Do! Missing Content.</p>\r\n");
            EndContext();
#line 63 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                    }

#line default
#line hidden
            BeginContext(2687, 89, true);
            WriteLiteral("\r\n                                    <hr />\r\n                                    <div>\r\n");
            EndContext();
#line 67 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                         if (@item.Example != null)
                                        {

#line default
#line hidden
            BeginContext(2888, 130, true);
            WriteLiteral("                                            <h4>Example</h4>\r\n                                            <pre><code class=\"html\">");
            EndContext();
            BeginContext(3019, 12, false);
#line 70 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                               Write(item.Example);

#line default
#line hidden
            EndContext();
            BeginContext(3031, 15, true);
            WriteLiteral("</code></pre>\r\n");
            EndContext();
            BeginContext(3091, 23, false);
#line 71 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                       Write(Html.Raw(@item.Example));

#line default
#line hidden
            EndContext();
#line 71 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                    
                                        }

#line default
#line hidden
            BeginContext(3159, 180, true);
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 78 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                }

#line default
#line hidden
#line 78 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(3373, 1709, true);
            WriteLiteral(@"        </div>
    </div>
</div>
<script>
    // Select all links with hashes
    $('a[href*=""#""]')
        // Remove links that don't actually link to anything
        .not('[href=""#""]')
        .not('[href=""#0""]')
        .click(function (event) {
            // On-page links
            if (
                location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
                &&
                location.hostname == this.hostname
            ) {
                // Figure out element to scroll to
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                // Does a scroll target exist?
                if (target.length) {
                    // Only prevent default if animation is actually gonna happen
                    event.preventDefault();
                    $('html, body').animate({
                        scrollTop: target.offset().top - $('.navbar').outerHeight(true)
");
            WriteLiteral(@"                    }, 1000, function () {
                        // Callback after animation
                        // Must change focus!
                        var $target = $(target);
                        $target.focus();
                        if ($target.is("":focus"")) { // Checking if the target was focused
                            return false;
                        } else {
                            $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                            $target.focus(); // Set focus again
                        };
                    });
                }
            }
        });
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Portfolio.Areas.Articles.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
