# TagHelper and LabelTagHelper 🎍🎪🎢🎭🧶

## Using our own TagHelper

## MyListTagHelper.cs

```cs
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace XTLAB
{
  // thẻ sẽ là mylist
  [HtmlTargetElement("mylist")]
  public class MyListTagHelper : TagHelper
  {
    // Thuộc tính sẽ là list-title
    public string ListTitle { get; set; }

    // Thuộc tính sẽ là list-items
    public List<string> ListItems { set; get; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = "ul";    // ul sẽ thay cho myul
      output.TagMode = TagMode.StartTagAndEndTag;

      output.Attributes.SetAttribute("class", "list-group");
      output.PreElement.AppendHtml($"<h2>{ListTitle}</h2>");


      StringBuilder content = new StringBuilder();
      foreach (var item in ListItems)
      {
        content.Append($@"<li class=""list-group-item"">{item}</li>");
      }
      output.Content.SetHtmlContent(content.ToString());
    }

  }
}
```

## Index.cshtml

```cs
@page
@model IndexModel
@* Name of our Application *@
@addTagHelper *, razorweb
@{
    ViewData["Title"] = "Home page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
@*                        reference *@
<a asp-page="ViewProduct" asp-route-id="3">
    Xem san pham 3
</a>
<form action="">
    @* Using TagHelper  *@ @* RECOMMENDED*@
    @* Declare in .cs
        [DisplayName("Ten nguoi dung")]
        // In .cshtml is  <label asp-for="UserName"></label>
        public string UserName { get; set; } *@
    <label asp-for="UserName"></label>
    <input type="text" asp-for="UserName">
    <hr>
    @* Using HtmlHelper *@
    @Html.Label("UserName")
    @Html.TextBox("UserName")
</form>

@{
   var productlist = new List<String> {
        "Tên Sản phẩm 1",
        "Tên Sản phẩm 2",
        "Tên Sản phẩm 3"
     };
}
<mylist list-title="Danh sách sản phẩm" list-items="@productlist"></mylist>
```
