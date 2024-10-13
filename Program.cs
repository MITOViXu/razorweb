using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static System.Console;
namespace CS43
{
  public partial class Program
  {
    public static void Main(string[] args)
    {
      // migration: code => database
      // webdb

      var dbContext = new WebContext();
      
    }
  }
}