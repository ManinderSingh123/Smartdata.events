#pragma checksum "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27085ff6a7fe9f3b306908b9498cd9e92157b2ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_RedmapEvent), @"mvc.1.0.view", @"/Views/Events/RedmapEvent.cshtml")]
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
#line 3 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
using Kendo.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27085ff6a7fe9f3b306908b9498cd9e92157b2ca", @"/Views/Events/RedmapEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"225d88f9e52db3079e16f32eff0ce9f4135016b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_RedmapEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Redmap.Events.DTO.EventsDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "20", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "30", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-4 col-lg-3"">
            <div class=""box-header"">
                <i class=""fa fa-search"" aria-hidden=""true""></i>
                Search
                <i class=""fa fa-caret-down"" aria-hidden=""true""></i>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca6423", async() => {
                WriteLiteral("\r\n                <div class=\"search-filter\">\r\n                    <div class=\"form-group\">\r\n                        <label>Category</label>\r\n                        ");
#nullable restore
#line 19 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
                   Write(Html.DropDownList("CategoryId", ViewBag.MasterCategories as SelectList, "Choose category", new { id = "CategoryId", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                    <div class=""form-group"">
                        <label>Message</label>
                        <textarea class=""form-control"" name=""Message""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label>Summary</label>
                        <textarea class=""form-control"" name=""Summary""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label>Source</label>
                        <input type=""text"" class=""form-control"" name=""Source"">
                    </div>
                    <div class=""form-group"">
                        <label>Server Detail</label>
                        <input type=""text"" class=""form-control"" name=""ServerDetail"">
                    </div>
                    <div class=""form-group"">
                        <label>Event Code</label>
                        <input type=""text"" class=""form-control"" name=""Er");
                WriteLiteral(@"rorCode"">
                    </div>
                    <div class=""form-group"">
                        <label>Event Timestamp</label>
                        <input type=""text"" placeholder=""Select date range"" class=""form-control"" name=""CreatedDate"">
                    </div>
                    <div class=""form-group"">
                        <label>Attachment Name</label>
                        <input type=""text"" class=""form-control"" name=""Attachment"">
                    </div>
                    <div class=""form-btn"">
                        <button type=""button"" class=""btn-cancel"">
                            <i class=""fa fa-times""
                               aria-hidden=""true""></i>Clear
                        </button>
                        <button type=""button"" class=""btn-save"" id=""Searchbtn"">
                            <i class=""fa fa-search""
                               aria-hidden=""true""></i>Search
                        </button>
                    </div>
       ");
                WriteLiteral("         </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""box-header"">
                <i class=""fa fa-search"" aria-hidden=""true""></i>
                Stream
                <i class=""fa fa-caret-down"" aria-hidden=""true""></i>
            </div>
            <div class=""setting-box"">
                <div class=""system-setting"">
                    <h4>
                        System
                        <a href=""javascript:viid(0)"" data-toggle=""modal"" data-target=""#modalconfiguration"">
                            <i class=""fa fa-cog"" aria-hidden=""true""></i>
                        </a>
                    </h4>

                </div>
                <div class=""responsive-grid"">

                </div>
            </div>
        </div>
        <div class=""col-md-8 col-lg-9"">

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca11418", async() => {
                WriteLiteral("\r\n                    <input type=\"submit\" class=\"k-button download\" data-format=\"xlsx\" data-title=\"Title1\" value=\"Export to XLSX\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
AddHtmlAttributeValue("", 3667, Url.Action("ExportEvents", "Events"), 3667, 37, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 87 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
            Write(Html.Kendo().Grid<Redmap.Events.DTO.EventsDto>()
            .Name("grid")          
            .Columns(columns =>
            {
                columns.Command(command => command.Custom("ViewDetails").Click("showDetails")).Width(130);
                columns.Bound(p => p.Category).Title("Category").Width(105);
                columns.Bound(p => p.Message).Title("Message").Width(105);
                columns.Bound(p => p.Summary).Title("Summary").Width(130);
                columns.Bound(p => p.Serverdetail).Title("ServerDetail").Width(130);
                columns.Bound(p => p.Source).Title("Source").Width(105);
                columns.Bound(p => p.Errorcode).Title("Event Code").Width(150);
                columns.Bound(p => p.CreatedDate).Title("Time Stamp").Width(150);
                columns.Bound(p => p.Attachment).Title("Attachment").Width(150);

            })
            .ToolBar(toolbar =>
            {
                toolbar.Search();
                //toolbar.Excel();
            })
            .ColumnMenu(col=>col.Filterable(false))
            .Height(700)
            .Editable(editable => editable.Mode(GridEditMode.InCell))
            .Pageable()
            .Sortable()
            .Navigatable()
            .Resizable(r=>r.Columns(true))
            .Reorderable(r => r.Columns(true))
            .Groupable(g=>g.ShowFooter(false))
            .Filterable()
            .Scrollable()
            //.Events(events => events.DataBound("onDataBound"))
            .DataSource(dataSource => dataSource
                .Ajax()
                .Batch(true)
                .PageSize(20)
                .AutoSync(true)
                .ServerOperation(true)
                .Events(events => events.Error("error_handler"))
                .Model(model =>
                {
                    model.Id(p => p.EventId);
                })

              .Group(group=>group.Add("Category", typeof(string), ListSortDirection.Descending))
            .Read("EventsBinding", "Events")
            )
        );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


        </div>
    </div>


    <div class=""modal stylish fade"" id=""modalconfiguration"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog modal-sm"" role=""document"">
            <div class=""modal-content"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
                <div class=""modal-header"">
                    <div class=""toggle-stich"">
                        <button type=""button"" id=""switchbtn"" class=""btn btn-sm btn-toggle mb-0"" data-toggle=""button"" aria-pressed=""false"" autocomplete=""off"">
                            <div class=""handle""></div>
                        </button>
                    </div>
                </div>
                <div class=""modal-body"">

                    <div class=""content-box"">
                        <div class=""container"">
                        ");
            WriteLiteral(@"    <div class=""row"">
                                <div class=""col-md-12"">

                                    <div class=""form-group"">
                                        <label>Interval</label>
                                        <select class=""form-control""");
            BeginWriteAttribute("name", " name=\"", 7285, "\"", 7292, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"Interval\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca17438", async() => {
                WriteLiteral("1 Minutes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca18645", async() => {
                WriteLiteral("5 Minutes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca20163", async() => {
                WriteLiteral("10 Minutes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca21371", async() => {
                WriteLiteral("20 Minutes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27085ff6a7fe9f3b306908b9498cd9e92157b2ca22579", async() => {
                WriteLiteral("30 Minutes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </select>
                                    </div>
                                    <div class=""form-group"">
                                        <label>Category</label>
                                       
                                        ");
#nullable restore
#line 175 "D:\ManinderSingh\Redmap.Events\Centralization\Redmap.Events\Views\Events\RedmapEvent.cshtml"
                                   Write(Html.ListBoxFor(m => m.GetMastercategories, this.ViewBag.MultiSelectCategories as SelectList, new { id = "categories",multiple="multiple", @class = "form-control input-md" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                    </div>

                                    <div class=""form-group"">
                                        <label>Server Detail</label>
                                        <input type=""text"" class=""form-control"" id=""Stream_Server"">
                                    </div>


                                </div>

                            </div>
                        </div>



                    </div>
                </div>
                <div class=""modal-footer"">
                    <div class=""text-center"">
                        <button type=""button"" id=""SaveConfiguration"" class=""btn-save"">Save</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""modal stylish fade"" id=""modalDetail"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content""");
            WriteLiteral(@">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
                <div id=""modelbody"">

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Redmap.Events.DTO.EventsDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
