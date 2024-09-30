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