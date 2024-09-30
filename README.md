# Nuget and Library 🎇🎆🎟🎞🛒🎭

## Create library C# class

### Create folder name Utils and run following commands

```
mkdir Utils
dotnet new classlib
```

![alt text](/assets/utils.jpg)

Utils\MyLib.cs

```
namespace Mtoan.Utils
{

  public static class CovertMoneyToText
  {
    ///
    /// Chuyển phần nguyên của số thành chữ
    ///
    /// Số double cần chuyển thành chữ
    /// Chuỗi kết quả chuyển từ số
    public static string NumberToText(double inputNumber, bool suffix = true)
    {
      string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
      string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
      bool isNegative = false;

      // -12345678.3445435 => "-12345678"
      string sNumber = inputNumber.ToString("#");
      double number = Convert.ToDouble(sNumber);
      if (number < 0)
      {
        number = -number;
        sNumber = number.ToString();
        isNegative = true;
      }


      int ones, tens, hundreds;

      int positionDigit = sNumber.Length;   // last -> first

      string result = " ";


      if (positionDigit == 0)
        result = unitNumbers[0] + result;
      else
      {
        // 0:       ###
        // 1: nghìn ###,###
        // 2: triệu ###,###,###
        // 3: tỷ    ###,###,###,###
        int placeValue = 0;

        while (positionDigit > 0)
        {
          // Check last 3 digits remain ### (hundreds tens ones)
          tens = hundreds = -1;
          ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
          positionDigit--;
          if (positionDigit > 0)
          {
            tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
            positionDigit--;
            if (positionDigit > 0)
            {
              hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
              positionDigit--;
            }
          }

          if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
            result = placeValues[placeValue] + result;

          placeValue++;
          if (placeValue > 3) placeValue = 1;

          if ((ones == 1) && (tens > 1))
            result = "một " + result;
          else
          {
            if ((ones == 5) && (tens > 0))
              result = "lăm " + result;
            else if (ones > 0)
              result = unitNumbers[ones] + " " + result;
          }
          if (tens < 0)
            break;
          else
          {
            if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
            if (tens == 1) result = "mười " + result;
            if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
          }
          if (hundreds < 0) break;
          else
          {
            if ((hundreds > 0) || (tens > 0) || (ones > 0))
              result = unitNumbers[hundreds] + " trăm " + result;
          }
          result = " " + result;
        }
      }
      result = result.Trim();
      if (isNegative) result = "Âm " + result;
      return result + (suffix ? " đồng chẵn" : "");
    }
  }
}
```

MyLib.csproj

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <PackageId>Mtoan.Utils</PackageId>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <Authors>Mtoan</Authors>
  </PropertyGroup>

</Project>

```

Program.cs

```
using System.Text;
using Newtonsoft.Json;
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
using Mtoan.Utils;

namespace CS29
{

  class Program
  {
    // dotnet add package Newtonsoft.Json --version 13.0.3
    // dotnet add package packageName

    // Use this when we downloading any packages and have an error
    // dotnet restore

    // dotnet add projectname.csproj library.csproj
    // dotnet add D:\razorweb\razorweb.csproj reference D:\razorweb\Utils\Utils.csproj

    class Product
    {
      public string Name { get; set; }
      public DateTime Expiry { get; set; }
      public string[] Sizes { get; set; }
    }
    class Movie
    {
      public string Name { get; set; }
      public string[] Genres { get; set; }
      public DateTime ReleaseDate { get; set; }

    }
    static void Main(string[] args)
    {
      OutputEncoding = Encoding.UTF8;
      Product product = new Product();
      product.Name = "Apple";
      product.Expiry = new DateTime(2008, 12, 28);
      product.Sizes = new string[] { "Small" };

      string json = JsonConvert.SerializeObject(product);
      // {
      //   "Name": "Apple",
      //   "Expiry": "2008-12-28T00:00:00",
      //   "Sizes": [
      //     "Small"
      //   ]
      // }
      string json2 = @"{
                        'Name': 'Bad Boys',
                        'ReleaseDate': '1995-4-7T00:00:00',
                        'Genres': [
                          'Action',
                          'Comedy'
                        ]
                      }";
      Movie m = JsonConvert.DeserializeObject<Movie>(json2);
      Product product2 = JsonConvert.DeserializeObject<Product>(json);
      string name = m.Name;
      WriteLine();
      WriteLine(json);
      WriteLine();
      WriteLine("Name get from json convert: " + name);
      WriteLine();
      Write("Product after get from json convert 2: " + product2.Name + " : " + product2.Expiry.ToString("") + " : ");
      foreach (var i in product.Sizes)
      {
        Write("" + i.ToString());
      }
      WriteLine();
      WriteLine();

      double a = 09001509;
      var kq = CovertMoneyToText.NumberToText(a);
      WriteLine("Final convert: "+kq);
      WriteLine(kq);
      WriteLine();
    }
  }
}
```

razorweb.csproj

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="Utils\Utils.csproj" />
    <ProjectReference Include="..\Utils\Utils.csproj" />
  </ItemGroup>

</Project>

```
