#pragma checksum "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "553025a0471e96ea84bc530cc745eda8e7e9ceb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__EconomicCalendarWidget), @"mvc.1.0.view", @"/Views/Shared/_EconomicCalendarWidget.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_EconomicCalendarWidget.cshtml", typeof(AspNetCore.Views_Shared__EconomicCalendarWidget))]
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
#line 1 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\_ViewImports.cshtml"
using UI.Mvc;

#line default
#line hidden
#line 2 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\_ViewImports.cshtml"
using UI.Mvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"553025a0471e96ea84bc530cc745eda8e7e9ceb8", @"/Views/Shared/_EconomicCalendarWidget.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86620aa07adc1c54ed9ec2839082c8883e9d18d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__EconomicCalendarWidget : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Common.Model.EconomicCalendar.Response.ResEconomicWidget>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/Flags/blank.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(99, 187, true);
            WriteLiteral("\r\n<div class=\"box\">\r\n    <div class=\"box-header with-border\">\r\n        <div class=\"pull-left\"><h5><b>Ekonomide Bugün</b></h5></div><div class=\"pull-right\">\r\n        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 12 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
     if (Model.Count != 0)
    {

#line default
#line hidden
            BeginContext(319, 549, true);
            WriteLiteral(@"<!-- /.box-header -->
        <div class=""box-body "">
            <div class=""slimScrollAdd"" style=""height:350px"">
                <div class=""table-responsive"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th rowspan=1>Ülke</th>
                                <th rowspan=1>Önem</th>
                                <th rowspan=3>Konu</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 26 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(957, 88, true);
            WriteLiteral("                                <tr>\r\n                                    <th colspan=1>");
            EndContext();
            BeginContext(1045, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "553025a0471e96ea84bc530cc745eda8e7e9ceb85437", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 29 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
AddHtmlAttributeValue("", 1055, item.CountryName, 1055, 17, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1112, "ceFlags", 1112, 7, true);
#line 29 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
AddHtmlAttributeValue(" ", 1119, item.CountryFlagCode, 1120, 21, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1143, 59, true);
            WriteLiteral("</th>\r\n                                    <th colspan=1>\r\n");
            EndContext();
#line 31 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
                                         for (int i = 1; i <= item.Important; i++)
                                        {

#line default
#line hidden
            BeginContext(1329, 102, true);
            WriteLiteral("                                            <i style=\"font-size:17px\" class=\"fa fa-exclamation\"></i>\r\n");
            EndContext();
#line 34 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
                                        }

#line default
#line hidden
            BeginContext(1474, 93, true);
            WriteLiteral("                                    </th>\r\n                                    <th colspan=3>");
            EndContext();
            BeginContext(1568, 12, false);
#line 36 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
                                             Write(item.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(1580, 46, true);
            WriteLiteral("</th>\r\n                                </tr>\r\n");
            EndContext();
#line 38 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
                            }

#line default
#line hidden
            BeginContext(1657, 124, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
            BeginContext(1783, 29, true);
            WriteLiteral("        <!-- /.box-body -->\r\n");
            EndContext();
#line 46 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1836, 196, true);
            WriteLiteral("        <div style=\"text-align:center;\">\r\n            <div class=\"media-body\">\r\n                <p class=\"eco-widget\">Planlanmış Etkinlik Bulunmamaktadır.</p>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 54 "C:\Users\exorc\OneDrive\Masaüstü\Yeni klasör (2)\DovizApp\UI.Mvc\Views\Shared\_EconomicCalendarWidget.cshtml"
    }

#line default
#line hidden
            BeginContext(2039, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Common.Model.EconomicCalendar.Response.ResEconomicWidget>> Html { get; private set; }
    }
}
#pragma warning restore 1591
