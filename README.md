# Networking part 1: HttpClient

## uri and url

```cs
string url = "https://phimmoichill.com/xem/deadpool-va-wolverine-a1-tap-full-pm118754";
var uri = new Uri(url);
var uriType = typeof(Uri);
uriType.GetProperties().ToList().ForEach(p =>
{
  WriteLine($"{p.Name,15} {p.GetValue(uri)}");
});
WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
```

**Output**

```

   AbsolutePath /xem/deadpool-va-wolverine-a1-tap-full-pm118754
    AbsoluteUri https://phimmoichill.com/xem/deadpool-va-wolverine-a1-tap-full-pm118754
      LocalPath /xem/deadpool-va-wolverine-a1-tap-full-pm118754
      Authority phimmoichill.com
   HostNameType Dns
  IsDefaultPort True
         IsFile False
     IsLoopback False
   PathAndQuery /xem/deadpool-va-wolverine-a1-tap-full-pm118754
       Segments System.String[]
          IsUnc False
           Host phimmoichill.com
           Port 443
          Query
       Fragment
         Scheme https
 OriginalString https://phimmoichill.com/xem/deadpool-va-wolverine-a1-tap-full-pm118754
    DnsSafeHost phimmoichill.com
        IdnHost phimmoichill.com
  IsAbsoluteUri True
    UserEscaped False
       UserInfo



Segments: /, xem/, deadpool-va-wolverine-a1-tap-full-pm118754
```
