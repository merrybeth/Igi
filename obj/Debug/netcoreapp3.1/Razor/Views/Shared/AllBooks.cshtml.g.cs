#pragma checksum "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36e319615cd9407eeb97a51db5e652c927e93e85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AllBooks), @"mvc.1.0.view", @"/Views/Shared/AllBooks.cshtml")]
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
#nullable restore
#line 1 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36e319615cd9407eeb97a51db5e652c927e93e85", @"/Views/Shared/AllBooks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eff41647092edc7ecda8ef80749071d3709e51b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AllBooks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Book>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-lg-4\">\r\n    <img class=\"img-thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 69, "\"", 87, 1);
#nullable restore
#line 4 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml"
WriteAttributeValue("", 75, Model.Image, 75, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 88, "\"", 105, 1);
#nullable restore
#line 4 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml"
WriteAttributeValue("", 94, Model.Name, 94, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    <h2> Модель: ");
#nullable restore
#line 5 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml"
            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <p>");
#nullable restore
#line 6 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml"
  Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Цена: ");
#nullable restore
#line 7 "D:\Univercity\3cours\5sem\igi\Shop\Shop\Views\Shared\AllBooks.cshtml"
        Write(Model.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><a class=\"btn btn-warning\" href=\"#\">Подробнее</a></p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Book> Html { get; private set; }
    }
}
#pragma warning restore 1591