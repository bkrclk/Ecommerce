#pragma checksum "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd159ddf64b0fd547f3115c82d7d69b63e765917"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd159ddf64b0fd547f3115c82d7d69b63e765917", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec470632cb3b1b75499bc0cdcc8d1831e35eecad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECommerce.Models.ProductModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("priceimg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/price.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pageup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/backtotop.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 2 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

    function AddProductView() {

        var productId = $(""#labelId"").text();
        var addViewinputCount = $(""#addViewinputCount"").val();
        AddProduct(productId, addViewinputCount);
    }

    function AddProduct(productId, count) {

        Swal.fire({
            title: 'Ürün sepete eklensin mi?',
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#28A745',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'İptal',


        }).then((result) => {
            if (result.value) {

                $('#MyModal').modal('hide');
                $('.asd').addClass = 'asd';

                var sData = { productId: productId, count: count };
                $.ajax({

                    url: ""/Home/AddToCard"",
                    data: sData,
                    type: ""GET"",
                    dataType: ""json"",
                    ca");
            WriteLiteral(@"che: false,
                    success: function (result) {
                        CartitemCount();
                        if (result.state === 1) {
                            Swal.fire(
                                'Sepete ekleme başarılı',
                                '',
                                'success'
                            )
                        } else if (result.state === 2) {
                            Swal.fire({
                                title: 'Ürün sepette zaten var sepeti güncellemek için yeni miktar giriniz.',
                                input: 'number',
                                inputAttributes: {
                                    autocapitalize: 'off'
                                },
                                showCancelButton: true,
                                confirmButtonText: 'Güncelle',
                                cancelButtonText: 'İptal',
                                showLoaderOnConfirm: true,
          ");
            WriteLiteral(@"                      preConfirm: (newCount) => {

                                    UpdateProduct(productId, newCount)
                                }
                            });
                        }
                        else {
                            Swal.fire(result.message, """", ""error"");
                        }
                    },
                    error: function (jqXHR, textStatus) {
                        alert(""Hata meydana geldi."");
                    }
                });
            }
        })
    }
    function SelectProduct(productId) {
        var sData = {
            productId: productId
        };
        $.ajax({

            url: ""/Home/ViewProduct"",
            data: sData,
            type: ""GET"",
            dataType: ""json"",
            cache: false,
            success: function (result) {

                $(""#labelId"").text(result.id);
                $(""#labelCode"").text(result.productCode);
                $(""#labelName""");
            WriteLiteral(@").text(result.productName);
                $(""#labelDescription"").text(result.description);
                $(""#labelPrice"").text(""$"" + result.price);
                $('#viewImg1').attr('href', result.image);
                $('#viewImg2').attr('src', result.image);
                $('#labelCategory').text(result.category);
                $('#labelStock').text(result.quantity);

            },
            error: function (jqXHR, textStatus) {
                alert(""Hata meydana geldi."");
            }
        });

        $(""#MyModal"").modal(""toggle"");
    }

    function CartitemCount() {
        $.post(""/Home/ItemControl"", function (result) {
            $(""#itemCount"").text(result);
        })
    }

    function UpdateProduct(productId, count) {

        var sData = { productId: productId, count: count };
        $.ajax({

            url: ""/Home/AddToCard"",
            data: sData,
            type: ""GET"",
            dataType: ""json"",
            cache: false,
       ");
            WriteLiteral(@"     success: function (result1) {
                var a = result1;
                if (count <= result1.product.quantity) {
                    CartitemCount();
                    Swal.fire(
                        'Güncelleme başarılı',
                        '',
                        'success'
                    )
                }
                else {
                    Swal.fire(
                        'Yetersiz stok! Son ' + result1.product.quantity + ' adet ürün kaldı',
                        '',
                        'error'
                    )
                }
            },
            error: function (jqXHR, textStatus) {
                alert(""Hata meydana geldi."");
            }
        });


    }

</script>


<div class=""album py-5 bg-light"">
    <div class=""container"">

        <div class=""row"">

");
#nullable restore
#line 160 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {
                var img = item.Image;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <div class=\"card mb-4 shadow-sm\">\r\n\r\n\r\n                        <img");
            BeginWriteAttribute("onclick", " onclick=\"", 5288, "\"", 5321, 3);
            WriteAttributeValue("", 5298, "SelectProduct(", 5298, 14, true);
#nullable restore
#line 167 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 5312, item.Id, 5312, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5320, ")", 5320, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 5322, "\"", 5332, 1);
#nullable restore
#line 167 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 5328, img, 5328, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" class=\"img-responsive indeximg\" />\r\n                        <div class=\"card-body\">\r\n                            <p class=\"card-text font-weight-bold text-length\">");
#nullable restore
#line 169 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
                                                                         Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text ikisatıryazi\">");
#nullable restore
#line 170 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
                                                         Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            <div class=""d-flex justify-content-between align-items-center"">
                                <div class=""btn-group"">
                                    <button id=""viewBtn"" type=""button"" class=""btn btn-sm btn-secondary""");
            BeginWriteAttribute("onclick", " onclick=\"", 5871, "\"", 5904, 3);
            WriteAttributeValue("", 5881, "SelectProduct(", 5881, 14, true);
#nullable restore
#line 173 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 5895, item.Id, 5895, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5903, ")", 5903, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Detail</button>\r\n\r\n                                    <button type=\"button\" class=\"btn btn-sm btn-success\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6013, "\"", 6045, 3);
            WriteAttributeValue("", 6023, "AddProduct(", 6023, 11, true);
#nullable restore
#line 175 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
WriteAttributeValue("", 6034, item.Id, 6034, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6042, ",1)", 6042, 3, true);
            EndWriteAttribute();
            WriteLiteral(">Add to Card</button>\r\n                                </div>\r\n                                <small class=\"instock btn btn-warning\"><i class=\"fas fa-cubes\"></i> 100</small>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cd159ddf64b0fd547f3115c82d7d69b63e76591713543", async() => {
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
            WriteLiteral("\r\n                                <small class=\"price\">₺");
#nullable restore
#line 179 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
                                                 Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 184 "C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n<footer class=\"text-muted\">\r\n    <div class=\"container\">\r\n        <p class=\"float-right\">\r\n            <a href=\"#\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cd159ddf64b0fd547f3115c82d7d69b63e76591715494", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
        </p>
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
                        <a id=""viewImg1"" href=""#"" class=""thumbnail"" data-toggle=""modal"" data-target=""#lightbox"">
                            <img id=""viewImg2""");
            BeginWriteAttribute("src", " src=\"", 7355, "\"", 7361, 0);
            EndWriteAttribute();
            WriteLiteral(@" width=""250"" height=""250"">
                        </a>

                    </div>
                    <div class=""col-md-8"">

                        <p style=""display:none""><label class=""headertext"" id=""labelId""></label></p>
                        <p><label class=""headertext"" id=""labelName""></label></p>
                        <p><label class=""headertext"" id=""labelCode""></label></p>
                        <p><label class=""headertext"" id=""labelPrice""></label></p>
                        <p><label class=""headertext"" id=""labelCategory""></label></p>


                        <div class=""row"">
                            <div class=""col-md-2"">
                                <input id=""addViewinputCount"" type=""number"" class=""form-control text-center "" value=""1"">
                            </div>
                            <div class=""col-md-4"" style=""margin-top:4px;"">
                                <button type=""button"" class=""btn btn-sm btn-success"" onclick=""AddProductView()"">Add to Card");
            WriteLiteral(@"</button>
                            </div>
                        </div>

                    </div>
                </div>

                <!-- Tab -->
                <div style=""padding:30px"">
                    <ul class=""nav nav-tabs"" role=""tablist"">
                        <li class=""nav-item"">
                            <a class=""nav-link active"" data-toggle=""tab"" href=""#home"">Description</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" data-toggle=""tab"" href=""#menu1"">İnfo</a>
                        </li>
                    </ul>

                    <div class=""tab-content textsize"">
                        <div id=""home"" class=""container tab-pane active"">
                            <span id=""labelDescription""></span>
                        </div>
                        <div id=""menu1"" class=""container tab-pane fade"">
                            <span>This Menu1 page description area.</span");
            WriteLiteral(@">
                        </div>

                    </div>
                </div>
                <!-- Tab End -->
            </div>
        </div>
    </div>
</div>
<!-- LightBox -->
<div id=""lightbox"" class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <button type=""button"" class=""close hidden"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
        <div class=""modal-content"">
            <div class=""modal-body"">
                <img");
            BeginWriteAttribute("src", " src=\"", 9961, "\"", 9967, 0);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 9968, "\"", 9974, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- LightBox End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECommerce.Models.ProductModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
