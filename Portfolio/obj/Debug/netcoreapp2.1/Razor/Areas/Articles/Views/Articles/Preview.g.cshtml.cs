#pragma checksum "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9b97ad3622c184a872f271aa384b0e877a20f3c"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9b97ad3622c184a872f271aa384b0e877a20f3c", @"/Areas/Articles/Views/Articles/Preview.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "becbd212c7c648e28a0ebb6034d41429", async() => {
                BeginContext(54, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(60, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c462738207f4297a11250f30bbc1cea", async() => {
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
            BeginContext(138, 1134, true);
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
                    <div class=""col-auto"">
                        <button class=""btn btn-sm btn-outline-primary"" 
                                type=""button"" data-toggle=""collapse"" 
                                data-target=""#overview"" 
                                aria-expanded=""true"" 
                                aria-controls=""collapse"">
                            <span class=""menu__icon menu__icon--close fa fa-angle-up"" aria-hidden=""true"" id=""icon"">
                            </span>
                            <span class=""menu__icon menu__icon--open fa fa-angle-down"" aria-hidden=""true"" id=""icon"">
              ");
            WriteLiteral("              </span>\r\n                        </button>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 30 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 if (Model.Sections != null)
                {

#line default
#line hidden
            BeginContext(1337, 112, true);
            WriteLiteral("                    <div class=\"collapse show\" id=\"overview\">\r\n                        <ul class=\"list-group\">\r\n");
            EndContext();
#line 34 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                             foreach (var item in Model.Sections)
                            {

#line default
#line hidden
            BeginContext(1547, 62, true);
            WriteLiteral("                                <li class=\"list-group-item\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1609, "\"", 1628, 2);
            WriteAttributeValue("", 1616, "#", 1616, 1, true);
#line 36 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
WriteAttributeValue("", 1617, item.Title, 1617, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1629, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1631, 10, false);
#line 36 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                              Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1641, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 37 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                            }

#line default
#line hidden
            BeginContext(1683, 59, true);
            WriteLiteral("                        </ul>\r\n                    </div>\r\n");
            EndContext();
#line 40 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                }

#line default
#line hidden
            BeginContext(1761, 81, true);
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"col-9\">\r\n            <h2>");
            EndContext();
            BeginContext(1843, 11, false);
#line 44 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1854, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 45 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
             if (@Model.Sections != null)
            {
                

#line default
#line hidden
#line 47 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 foreach (var item in @Model.Sections)
                {


#line default
#line hidden
            BeginContext(1996, 70, true);
            WriteLiteral("                    <h3 class=\"smooth-goto\">\r\n                        ");
            EndContext();
            BeginContext(2067, 10, false);
#line 51 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                   Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2077, 138, true);
            WriteLiteral("\r\n\r\n                        <button class=\"float-right btn btn-sm btn-outline-primary\" type=\"button\" data-toggle=\"collapse\" data-target=\"#");
            EndContext();
            BeginContext(2216, 10, false);
#line 53 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                                                                                 Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2226, 504, true);
            WriteLiteral(@""" aria-expanded=""true"" aria-controls=""collapse"">
                            <span class=""menu__icon menu__icon--close fa fa-angle-up"" aria-hidden=""true"" id=""icon"">
                            </span>
                            <span class=""menu__icon menu__icon--open fa fa-angle-down"" aria-hidden=""true"" id=""icon"">
                            </span>
                        </button>
                    </h3>
                    <hr />
                    <div class=""collapse collapse show""");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2730, "\"", 2746, 1);
#line 61 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
WriteAttributeValue("", 2735, item.Title, 2735, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2747, 151, true);
            WriteLiteral(">\r\n                        <div class=\"breadcrumb\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col\">\r\n");
            EndContext();
#line 65 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                     if (@item.Content != null)
                                    {
                                        

#line default
#line hidden
            BeginContext(3043, 23, false);
#line 67 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                   Write(Html.Raw(@item.Content));

#line default
#line hidden
            EndContext();
#line 67 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3188, 93, true);
            WriteLiteral("                                        <p class=\"alert-danger\">To Do! Missing Content.</p>\r\n");
            EndContext();
#line 72 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                    }

#line default
#line hidden
            BeginContext(3320, 89, true);
            WriteLiteral("\r\n                                    <hr />\r\n                                    <div>\r\n");
            EndContext();
#line 76 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                         if (@item.Example != null)
                                        {

#line default
#line hidden
            BeginContext(3521, 130, true);
            WriteLiteral("                                            <h4>Example</h4>\r\n                                            <pre><code class=\"html\">");
            EndContext();
            BeginContext(3652, 12, false);
#line 79 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                               Write(item.Example);

#line default
#line hidden
            EndContext();
            BeginContext(3664, 15, true);
            WriteLiteral("</code></pre>\r\n");
            EndContext();
            BeginContext(3724, 23, false);
#line 80 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                       Write(Html.Raw(@item.Example));

#line default
#line hidden
            EndContext();
#line 80 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                                                                    
                                        }

#line default
#line hidden
            BeginContext(3792, 180, true);
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 87 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                }

#line default
#line hidden
#line 87 "C:\Users\sulai\source\repos\Portfolio\Portfolio\Areas\Articles\Views\Articles\Preview.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(4006, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
