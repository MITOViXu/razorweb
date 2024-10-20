# Layout in Razor page 🎍🎪🎢🎭🧶

```cs
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/razorweb.styles.css" asp-append-version="true" />
  <title>Privacy</title>
</head>
<body>
  <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark  bg-dark  border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand" asp-area="" asp-page="/Index">Mtoan</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-lg-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-light font-monospace" asp-area="" asp-page="/Index">Trang chủ</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-light" asp-area="" asp-page="/Privacy">Học HTML</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" asp-area="" asp-page="/Privacy">Gửi bài</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-light" asp-area="" asp-page="/Post1">Bai viet 1</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-light" asp-area="" asp-page="/Post2">Bài viết 2</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
  <div>
    @RenderBody()
  </div>
  <div class="bg-success">Footer</div>
  <script src="~/lib/jquery/dist/jquery.min.js"></script>
  <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
  <script src="~/js/site.js" asp-append-version="true"></script>

</body>
</html>
```
