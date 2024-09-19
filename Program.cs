namespace CS02
{
  class Program
  {
    static void Main(string[] args)
    {
      float a, b;
      string sinput;
      Console.WriteLine("Nhap a va b: ");
      sinput = Console.ReadLine();
      a = float.Parse(sinput);
      sinput = Console.ReadLine();
      b = Convert.ToSingle(sinput);
      Console.WriteLine("So a: {0}, b: {0}", a, b);
      
    }
  }
}