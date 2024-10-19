# Introducing and initial Razor page 🎍🎪🎢🎭🧶

## Using TagHelper

```cs
@page
@* If we access /Dichvu without name after, the Dichvu route will find the index for default *@
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
<h1>Trang dich vu mac dinh</h1>
<a asp-page="Dichvu1">Dich vu 1</a> <br />
<a asp-page="Dichvu2">Dich vu 2</a>
```

## Program.cs

Some notes about initial Urls.

```cs
service.AddRazorPages().AddRazorPagesOptions(option =>
{
    // Change Razor site storage directory
    option.RootDirectory = "/Pages";
    // Change site address to anohter name
    option.Conventions.AddPageRoute("/FirstPage", "trangdau.html");
});
service.Configure<RouteOptions>(route =>
{
    route.LowercaseUrls = true;
});
```

## Using functions

```cs
@page
@* If we access /Dichvu without name after, the Dichvu route will find the index for default *@
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
<h1>@this.title</h1>
<a asp-page="Dichvu1">Dich vu 1</a> <br />
<a asp-page="Dichvu2">Dich vu 2</a>
<br />
<a asp-page="/Sanphammoi" asp-area="Product">Cac san pham moi</a>
@functions{
  string title {set;get;} = "Day la trang mtoan dau tien";
}
```

## Using ViewData

```cs
@{
  ViewData["data"] = "Đây là trang razor page đầu tiên";
}
<h1>@ViewData["data"]</h1>
```
