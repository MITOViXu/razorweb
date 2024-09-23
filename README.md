# Event, create event with delegate and EventHandler 👀🦿🦾🎆🧨

```
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS22
{
  /*
    publisher - event broadcast
    subscriber - event receive
  */
  // publisher
  public delegate void SuKienNhapSo(int X);

  // EVENT

  class Dulieunhap : EventArgs
  {
    public int data { get; set; }
    public Dulieunhap(int data) => this.data = data;
  }
  class UserInput
  {
    public event EventHandler sukiennhapso2; // ~ delegate coi KIEU(object? sender, EventArgs arrgs)
    public event SuKienNhapSo suKienNhapSo;
    public void Input()
    {
      do
      {
        string s = ReadLine();
        int i = Int32.Parse(s);
        // suKienNhapSo?.Invoke(i);
        sukiennhapso2.Invoke(this, new Dulieunhap(i));
      } while (true);
    }
  }
  class Square
  {
    public void Sub(UserInput input)
    {
      input.sukiennhapso2 += Square2;
    }
    public void Square2(object sender, EventArgs args)
    {
      Dulieunhap dulieunhap = (Dulieunhap)args;
      int i = dulieunhap.data;
      WriteLine($"Binh phuong cua {i} la {i * i}");
    }
  }
  class SquareRoot
  {
    public void Sub(UserInput input)
    {
      input.sukiennhapso2 += Square;
    }
    public void Square(object sender, EventArgs args)
    {
      Dulieunhap dulieunhap = (Dulieunhap)args;
      int i = dulieunhap.data;
      WriteLine($"Can bac 2 cua {i} la {Sqrt(i)}");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      CancelKeyPress += (sender, e) =>
      {
        WriteLine("Thoat ung dung");
      };
      // publisher
      UserInput userInput = new UserInput();


      // lambda
      userInput.sukiennhapso2 += (sender, e) =>
      {
        Dulieunhap dulieunhap = (Dulieunhap)e;
        WriteLine("Ban vua nhap so : " + dulieunhap.data);
      };

      // subcriber
      SquareRoot squareRoot = new SquareRoot();
      squareRoot.Sub(userInput);


      Square binhphuong = new Square();
      binhphuong.Sub(userInput);
      userInput.Input();


    }
  }
}



```
