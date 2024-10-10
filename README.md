# Using DataAdapter DataSet DataTable and SQL Server 🎄🎋🎆🧨🎉🎃

![alt text](/assets/architecture.jpg)

```cs
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using static System.Console;
namespace CS39
{
  public class Program
  {
    public static void ShowDataTable(DataTable table)
    {
      WriteLine("Ten cua bang" + table.TableName);
      foreach (DataColumn i in table.Columns)
      {
        WriteLine("Ten cot: " + i.ColumnName);
      }
      WriteLine();
      int numCol = table.Columns.Count;
      foreach (DataRow i in table.Rows)
      {
        Write("\nGia tri: ");
        for (int j = 0; j < numCol; j++)
        {
          if (j + 1 == numCol) Write(i[j]);
          else Write(i[j] + " - ");
        }
      }
      WriteLine();
    }
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

      var dataset = new DataSet();
      var table = new DataTable("MyTable");
      dataset.Tables.Add(table);

      table.Columns.Add("STT");
      table.Columns.Add("Hoten");
      table.Columns.Add("Tuoi");
      table.Columns.Add("NamSinh");

      table.Rows.Add(1, "Minh Toan", 21, 2003);
      table.Rows.Add(2, "Minh Toan 2", 21, 2003);
      table.Rows.Add(3, "Minh Toan 3", 21, 2003);
      table.Rows.Add(4, "Minh Toan 4", 21, 2003);

      ShowDataTable(table);

      var adapter = new SqlDataAdapter();
      adapter.TableMappings.Add("Table", "NhanVien");

      // We must call SelectCommand
      adapter.SelectCommand = new SqlCommand("select NhanviennID, Ten, Ho, Anh from NhanVien", connection);

      DataSet dataSet = new DataSet();
      adapter.Fill(dataSet);

      table = dataSet.Tables["NhanVien"];
      ShowDataTable(table);

      // var row = table.Rows.Add();
      // row["Ten"] = "Abc";
      // row["Ho"] = "Nguyen";

      // We must call InsertCommand
      adapter.InsertCommand = new SqlCommand("insert into NhanVien (Ho, Ten) values (@Ho, @Ten)", connection);
      adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NChar, 255, "Ho");
      adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NChar, 255, "Ten");
      // We must call DeleteCommand
      adapter.DeleteCommand = new SqlCommand("delete from NhanVien where NhanviennID = @NhanviennID", connection);
      var para = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
      para.SourceColumn = "NhanviennID";
      para.SourceVersion = DataRowVersion.Original;

      // Insert data, update data
      var row10 = table.Rows[10];
      row10.Delete();
      WriteLine();

      adapter.Update(dataSet);
      connection.Close();
      WriteLine(connection.State);
    }
  }
}
```
