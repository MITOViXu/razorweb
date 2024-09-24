using System.Text;
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS28
{
  class Product
  {
    public int ID { get; set; }
    public double Price { get; set; }
    public string Name { get; set; }
    public void Save(Stream stream)
    {
      // int -> 4 bytes
      var bytes_id = BitConverter.GetBytes(ID);
      // stream.Write(bytes_id, _Start__Position, _Amount_of_bytes);
      stream.Write(bytes_id, 0, 4);

      // int -> 8 bytes
      var bytes_price = BitConverter.GetBytes(Price);
      stream.Write(bytes_price, 0, 8);

      // string
      var bytes_name = Encoding.UTF8.GetBytes(Name);
      var bytes_length = BitConverter.GetBytes(bytes_name.Length);
      stream.Write(bytes_length, 0, 4);
      stream.Write(bytes_name, 0, bytes_name.Length);


    }
    public void Restore(Stream stream)
    {

    }
  }
  class Program
  {
    static void Main(string[] args)
    {

      // Drive info
      // Directory - Folder 
      // WORKING WITH FOLDER AND DIRECTORY
      DriveInfo[] allDrives = DriveInfo.GetDrives();

      foreach (DriveInfo d in allDrives)
      {
        WriteLine("Drive {0}", d.Name);
        WriteLine("  Drive type: {0}", d.DriveType);
        if (d.IsReady == true)
        {
          WriteLine("  Volume label: {0}", d.VolumeLabel);
          WriteLine("  File system: {0}", d.DriveFormat);
          WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
          WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);
          WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
        }
      }
      // Create folder
      string path = "ABC";
      if (Directory.Exists(path)) WriteLine("Ton tai thu muc: " + path);
      else
      {
        WriteLine("Khong ton tai thu muc");
        Directory.CreateDirectory(path);
      }
      // Find all files
      string filepath = "obj";
      var files = Directory.GetFiles(filepath);
      foreach (var file in files)
      {
        WriteLine(file);
      }
      WriteLine("-----");
      // Get directory
      string folderpath = "obj";
      var folders = Directory.GetDirectories(filepath);
      foreach (var file in folders)
      {
        WriteLine(file);
      }
      // list all directories
      var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      String[] file2s = System.IO.Directory.GetFiles(directory_mydoc);
      String[] directories = System.IO.Directory.GetDirectories(directory_mydoc);

      foreach (var file in file2s)
      {
        Console.WriteLine(file);
      }

      foreach (var directory in directories)
      {
        Console.WriteLine(directory);
      }

      // WORKING DIRECTORY
      WriteLine();
      WriteLine("--- WORKING DIRECTORY -- ");
      WriteLine();

      WriteLine(Path.DirectorySeparatorChar);
      var path3 = Path.Combine("Dir1", "Dir2", "Hello.txt");
      WriteLine();
      WriteLine(path3);
      // change extension
      var path4 = Path.ChangeExtension(path3, "md");

      WriteLine();
      WriteLine(path4);
      WriteLine();

      // WORKING WITH FILE, DELETE, COPY AND READ.
      string filename2 = "abc.txt";
      string content = "Xin chao cac ban ";
      File.WriteAllText(filename2, content);
      File.AppendAllText(filename2, "den voi C#");

      WriteLine("Noi dung cua file: " + File.ReadAllText(filename2));
      WriteLine();

      // WORKING WITH STREAM AND FILESTREAM
      using var stream = new FileStream(path: "123.txt", FileMode.Open);

      Product product = new Product()
      {
        ID = 1,
        Name = "Iphone",
        Price = 100
      };
      product.Save(stream);

    }
  }
}