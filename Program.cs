using System.Text;
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace Dp
{
  class Program
  {

    static void Main(string[] args)
    {
      int maxn = 102;
      int n, m;
      int[,] a = new int[maxn, maxn];
      int[,] f = new int[maxn, maxn];
      n = int.Parse(ReadLine());
      m = int.Parse(ReadLine());

      // Input matrix a[n,m]
      for (int i = 1; i <= n; i++)
      {
        for (int j = 1; j <= m; j++)
        {
          a[i, j] = int.Parse(ReadLine());
        }
      }

      // Initialize boundary values for f
      for (int i = 0; i <= m; i++)
      {
        f[0, i] = f[n + 1, i] = -100000000;
      }

      // Initialize the first column of f with the values of a, as no previous values exist
      for (int i = 1; i <= n; i++)
      {
        f[i, 1] = a[i, 1];
      }

      // Dynamic programming to compute maximum path sum
      for (int j = 2; j <= m; j++)
      {
        for (int i = 1; i <= n; i++)
        {
          f[i, j] = Max(f[i - 1, j - 1], Max(f[i, j - 1], f[i + 1, j - 1])) + a[i, j];
        }
      }

      // Find the maximum value in the last column (f[i,m])
      int ans = -100000000;
      for (int i = 1; i <= n; i++)
      {
        ans = Max(ans, f[i, m]);
      }
      WriteLine("\n Final result: "+ans);
    }
  }
}