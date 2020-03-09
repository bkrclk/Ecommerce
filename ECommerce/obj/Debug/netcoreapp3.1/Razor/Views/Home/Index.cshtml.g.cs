#pragma checksum "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2265cea523e1bf7ca54460890c51dd7933886662"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\_ViewImports.cshtml"
using ECommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\_ViewImports.cshtml"
using ECommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2265cea523e1bf7ca54460890c51dd7933886662", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec470632cb3b1b75499bc0cdcc8d1831e35eecad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECommerce.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function SelectProduct(event) {

        var sData = {
            productId: event
        };
        $.ajax({

            url: ""/Home/ViewProduct"",
            data: sData,
            type: ""GET"",
            dataType: ""json"",
            cache: false,
            success: function (result) {


                $(""#labelId"").text(result.id); 
                $(""#labelName"").text(result.productName); 
                $(""#labelDescription"").text(result.description); 
                $(""#labelPrice"").text(result.price);
                $('#viewImg').attr('src',result.image);

            },
            error: function (jqXHR, textStatus) {
                alert(""Hata meydana geldi."");
            }
        });


         $(""#MyModal"").modal(""toggle"");
    }
    
</script>

");
            WriteLiteral("\r\n<div class=\"album py-5 bg-light\">\r\n    <div class=\"container\">\r\n\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 55 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {
                var img = item.Image;


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <div class=\"card mb-4 shadow-sm\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1819, "\"", 1829, 1);
#nullable restore
#line 61 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 1825, img, 1825, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" class=\"img-responsive\" />\r\n                        <div class=\"card-body\">\r\n                            <p class=\"card-text font-weight-bold text-length\">");
#nullable restore
#line 63 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
                                                                         Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            <p class=""card-text"">This is a wider card with supporting</p>
                            <div class=""d-flex justify-content-between align-items-center"">
                                <div class=""btn-group"">
                                    <button id=""viewBtn"" type=""button"" class=""btn btn-sm btn-outline-secondary""");
            BeginWriteAttribute("onclick", " onclick=\"", 2373, "\"", 2406, 3);
            WriteAttributeValue("", 2383, "SelectProduct(", 2383, 14, true);
#nullable restore
#line 67 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 2397, item.Id, 2397, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2405, ")", 2405, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">Detail</button>
                                    <button type=""button"" class=""btn btn-sm btn-outline-secondary"">Add to Card</button>
                                </div>
                                <small class=""text-muted"">100</small>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 75 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </div>
    </div>
</div>
<footer class=""text-muted"">
    <div class=""container"">
        <p class=""float-right"">
            <a href=""#"">Back to top</a>
        </p>
        <p>Album example is © Bootstrap, but please download and customize it for yourself!</p>
        <p>New to Bootstrap? <a href=""https://getbootstrap.com/"">Visit the homepage</a> or read our <a href=""/docs/4.4/getting-started/introduction/"">getting started guide</a>.</p>
    </div>
</footer>

<div class=""modal fade product_view"" id=""MyModal"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <a href=""#"" data-dismiss=""modal"" class=""class pull-right""><span class=""glyphicon glyphicon-remove""></span></a>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-4"">
                        <img id=""viewImg""");
            BeginWriteAttribute("src", " src=\"", 3758, "\"", 3764, 0);
            EndWriteAttribute();
            WriteLiteral(@" width=""100%"" class=""img-responsive"">
                    </div>
                    <div class=""col-md-8"">
                        <label>Product Id:</label>
                        <label id=""labelId""></label>
                        <br />
                        <label>Product Name:</label>
                        <label id=""labelName""></label>
                        <br />
                        <label id=""labelDescription""></label>
                        <label id=""labelPrice""></label>
                        <br />




                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECommerce.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591