# Model Binding 🎍🎪🎢🎭🧶

## ContactRequest.cshtml.cs

```cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Console;
namespace razorweb.Pages
{
    public class ContactRequestModel : PageModel
    {
        // Default is post
        [BindProperty]
        public UserContact userContact { get; set; }
        private readonly ILogger<ContactRequestModel> _logger;
        public ContactRequestModel(ILogger<ContactRequestModel> logger)
        {
            _logger = logger;
            userContact = new UserContact();
            WriteLine("Init Contact...");
        }
        public int Tong(int a, int b)
        {
            return a + b;
        }
    }
}

```

## ContactRequest.cshtml

```cs
@page
@model ContactRequestModel
@{
  ViewData["Title"] = "LIEN HE";
}
<h1 class="display-4">Trang liên hệ</h1>
<p class="lead">Điền các thông tin liên hệ</p>
<hr>
<form method="post" class="bg-light p-2 m-2" asp-page="ContactRequest">
  @* The same as the name in Model *@

  @* <input name="UserId" /> *@
  @* Will working the same way *@
  <div class="mb-3">
    <label class="form-label" asp-for="userContact.UserID" ></label>
    <input class="form-control w-25" asp-for="@Model.userContact.UserID" />
    <span class="text-danger" asp-validation-for="userContact.UserID"></span>
  </div>
  <div class="mb-3">
    <label class="form-label" asp-for="userContact.Email" ></label>
    <input class="form-control w-25" asp-for="@Model.userContact.Email" />
    <span class="text-danger" asp-validation-for="userContact.Email"></span>
  </div>
  <div class="mb-3">
    <label class="form-label" asp-for="userContact.UserName" ></label>
    <input class="form-control w-25" asp-for="@Model.userContact.UserName" />
    <span class="text-danger" asp-validation-for="userContact.UserName"></span>
  </div>

  <button class="btn btn-danger" type="submit">Gui</button>
</form>
<div class="alert alert-danger">
  Welcome <span style="font-weight: bold;">@Model.userContact.UserID</span> to Website
</div>
@if(@Model.userContact != null){
<div class="alert alert">
  <p>Thông tin User</p>
  <ul>
    <li>UserID: @Model.userContact.UserID</li>
    <li>Email: @Model.userContact.Email</li>
    <li>USerName: @Model.userContact.UserName</li>
  </ul>
</div>
}
@section Scripts{
  <partial name="_ValidationScriptsPartial" />
}
```
