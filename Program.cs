using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using static System.Console;
namespace CS37
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      var stringBuilder = new SqlConnectionStringBuilder();
      stringBuilder["Data Source"] = "192.168.1.110, 1433";
      stringBuilder["Initial Catalog"] = "xtlab";
      stringBuilder["PWD"] = "Password123";
      stringBuilder["UID"] = "sa";

      // string sqlStringConnection = @"Data Source =  192.168.1.110, 1433; 
      //                                Initial Catalog = xtlab; 
      //                                PWD=Password123; 
      //                                UID=sa";

      var connection = new SqlConnection(stringBuilder.ToString());
      WriteLine(connection.State);
      connection.Open();
      WriteLine(connection.State);

      // auto free up resources
      using DbCommand command = new SqlCommand();
      command.Connection = connection;
      command.CommandText = "Select top(5) * from SANPHAM";
      var data = command.ExecuteReader();
      while (data.Read())
      {
        WriteLine($"{data["TenSanPham"],30}, {data["Gia"],30}");
      }

      connection.Close();
      WriteLine(connection.State);

    }
  }
}