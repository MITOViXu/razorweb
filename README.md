# Networking part 1: HttpClient

### uri and url

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

_Output_

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

### Host name

```cs
var hostname = Dns.GetHostName();
WriteLine("Host name: "+hostname);
WriteLine("Website's host name: "+uri.Host);
```

_Out put_

```
Host name: DESKTOP-B77AKP1
Website's host name: phimmoichill.com
```

### Ping

```cs
var ping = new Ping();
var pingReply = ping.Send("phimmoichill.com");
WriteLine(pingReply.Status);
if (pingReply.Status == IPStatus.Success) WriteLine(pingReply.RoundtripTime + "\n" + pingReply.Address);
```

_Out put_

```
Success
65
172.67.73.132
```

### IP

```cs
 var ip = Dns.GetHostEntry(uri.Host);
ip.AddressList.ToList().ForEach(i => WriteLine(i));
```

_Out put_

```
172.67.73.132
104.26.11.163
104.26.10.163
2606:4700:20::681a:aa3
2606:4700:20::681a:ba3
2606:4700:20::ac43:4984
```

## Using .Net for Query 🎇🧨🎄🎋🎍🧶
