#pragma checksum "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcb61134abab61480479637046899b18fda5cdba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_boke_Index), @"mvc.1.0.view", @"/Views/boke/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/boke/Index.cshtml", typeof(AspNetCore.Views_boke_Index))]
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
#line 1 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\_ViewImports.cshtml"
using bokeSite;

#line default
#line hidden
#line 2 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\_ViewImports.cshtml"
using bokeSite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcb61134abab61480479637046899b18fda5cdba", @"/Views/boke/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f3b26e58758fde957a91a518ee95654bf4268e", @"/Views/_ViewImports.cshtml")]
    public class Views_boke_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
  
    Layout = null;
    var userInfo = ViewBag.userInfo as userinfo;
    var userWenZhangType = ViewBag.userWenZhangType as List<userwenzhangleixingkuozhan>;

#line default
#line hidden
            BeginContext(169, 31, true);
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(200, 455, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5303b31a45024a12a8046ea22be873fc", async() => {
                BeginContext(206, 72, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>");
                EndContext();
                BeginContext(279, 16, false);
#line 14 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
      Write(userInfo.nicheng);

#line default
#line hidden
                EndContext();
                BeginContext(295, 353, true);
                WriteLiteral(@"</title>

    <link href=""lib/bootstrap/dist/css/bootstrap.css"" rel=""stylesheet"" />

    <style type=""text/css"">
        #wenzhanglistUl {
            list-style-type: none;
        }
        #wenzhanglistUl li:hover {
            background: #eee;
            cursor: pointer;
        }
        #firstContainer{

        }
    </style>
");
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
            BeginContext(655, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(657, 1868, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cbf142314624d458d2f79ac3552aad7", async() => {
                BeginContext(663, 358, true);
                WriteLiteral(@"
    <div id=""firstContainer"" class=""container1"">
        <div class=""row"">
            <div class=""col-xs-offset-1 col-xs-10"">
                <nav class=""navbar navbar-default"" role=""navigation"">
                    <div class=""container-fluid"">
                        <div class=""navbar-header"">
                            <a class=""navbar-brand""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1021, "\"", 1047, 2);
                WriteAttributeValue("", 1028, "/", 1028, 1, true);
#line 38 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
WriteAttributeValue("", 1029, userInfo.username, 1029, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1048, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1050, 16, false);
#line 38 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                                                          Write(userInfo.nicheng);

#line default
#line hidden
                EndContext();
                BeginContext(1066, 244, true);
                WriteLiteral(" 的博客</a>\r\n                        </div>\r\n                        <div>\r\n                            <ul id=\"headListForType\" class=\"nav navbar-nav\">\r\n                                <li class=\"\"><a needhref=\"/boke/wenzhanglist\">全部文章</a></li>\r\n");
                EndContext();
#line 43 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                  
                                    foreach (var item in userWenZhangType)
                                    {
                                        var tmp = item.leixingming + "(" + item.count + ")";

#line default
#line hidden
                BeginContext(1555, 52, true);
                WriteLiteral("                                        <li class=\"\"");
                EndContext();
                BeginWriteAttribute("leixing", " leixing=\"", 1607, "\"", 1625, 1);
#line 47 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
WriteAttributeValue("", 1617, item.id, 1617, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1626, 3, true);
                WriteLiteral("><a");
                EndContext();
                BeginWriteAttribute("needhref", " needhref=\"", 1629, "\"", 1675, 2);
                WriteAttributeValue("", 1640, "/boke/wenzhanglist?leixing=", 1640, 27, true);
#line 47 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
WriteAttributeValue("", 1667, item.id, 1667, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1676, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1678, 3, false);
#line 47 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                                                                                                     Write(tmp);

#line default
#line hidden
                EndContext();
                BeginContext(1681, 11, true);
                WriteLiteral("</a></li>\r\n");
                EndContext();
#line 48 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                    }
                                

#line default
#line hidden
                BeginContext(1766, 644, true);
                WriteLiteral(@"                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-offset-1 col-xs-10"">

                <div>
                    <ul id=""wenzhanglistUl"" class=""col-xs-12""></ul>
                </div>
            </div>
        </div>
    </div>
    <script src=""lib/jquery/dist/jquery.js""></script>
    <script src=""lib/bootstrap/dist/js/bootstrap.js""></script>
    <script src=""js/boke/index.js""></script>
    <script>
        $(function () {
        var bokeIndex = new BokeIndex('");
                EndContext();
                BeginContext(2411, 17, false);
#line 70 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                  Write(userInfo.username);

#line default
#line hidden
                EndContext();
                BeginContext(2428, 42, true);
                WriteLiteral("\');\r\n            bokeIndex.ChoiceLeixing(\'");
                EndContext();
                BeginContext(2471, 15, false);
#line 71 "D:\代码项目文件夹\MYsite\test\bokeSite\Views\boke\Index.cshtml"
                                Write(ViewBag.leixing);

#line default
#line hidden
                EndContext();
                BeginContext(2486, 32, true);
                WriteLiteral("\');\r\n        })\r\n    </script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2525, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
