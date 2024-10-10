# Using SqlCommand to query data and update SQL server 🎄🎋🎆🧨🎉🎃

```cs
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
      command.CommandText = @"SELECT TOP (100) *
                              FROM Danhmuc
                              Where DanhmucID >= @DanhmucId";
      // command.ExecuteReader(); - Used for return value with multiple line
      // command.ExecuteScalar(); - Used for return only 1 value
      // command.ExecuteNonQuery(); - Used for Insert, Update, Delete.
      var parameters = command.CreateParameter();
      parameters.ParameterName = "@DanhmucId";
      parameters.Value = 6;
      command.Parameters.Add(parameters);

      var data = command.ExecuteReader();

      while (data.Read())
      {
        WriteLine($"{data["TenDanhMuc"],30}, {data["DanhmucID"],30}");
      }
      var sqlReader = command.ExecuteReader();
      if (sqlReader.HasRows)
        while (sqlReader.Read())
        {
          var id = sqlReader.GetInt32(0);
          var ten = sqlReader["TenDanhMuc"];
        }
      connection.Close();
      WriteLine(connection.State);
    }
  }
}
```
