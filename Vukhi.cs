namespace CS03
{
  class Vukhi
  {
    // DU LIEU
    public string name = "Sung chua nap dan";
    int dosatthuong = 0;

    public string Noisanxuat { set; get; }

    // THUOC TINH
    public int Satthuong
    {
      set
      {
        Console.WriteLine(value);
      }
      get
      {
        return 109;
      }
    }

    // Phuong thuc khoi tao
    public Vukhi()
    {
      Console.WriteLine("Khoi tao");

    }
    public Vukhi(string abc)
    {
      dosatthuong = 1;
      Console.WriteLine(abc);
    }

    // PHUONG THUC
    public void ThietLapDoSatThuong(int dosatthuong)
    {
      this.dosatthuong = dosatthuong;
      // Vukhi abc;
      // abc = this;

    }
    public void Tancong()
    {
      // Console.WriteLine(name);
      for (int i = 0; i < dosatthuong; i++)
      {
        Console.Write(" * ");
      }
      Console.WriteLine();
    }
  }
}