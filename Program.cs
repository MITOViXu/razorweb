using static System.Console;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace CS33
{

  // Depency Injection
  // Inverse Dependency
  // class ClassC
  // {
  //   public void ActionC() => Console.WriteLine("Action in ClassC");
  // }

  // class ClassB
  // {
  //   // Phụ thuộc của ClassB là ClassC
  //   ClassC c_dependency;

  //   public ClassB(ClassC classc) => c_dependency = classc;
  //   public void ActionB()
  //   {
  //     Console.WriteLine("Action in ClassB");
  //     c_dependency.ActionC();
  //   }
  // }

  // class ClassA
  // {
  //   // Phụ thuộc của ClassA là ClassB
  //   ClassB b_dependency;

  //   public ClassA(ClassB classb) => b_dependency = classb;
  //   public void ActionA()
  //   {
  //     Console.WriteLine("Action in ClassA");
  //     b_dependency.ActionB();
  //   }
  // }

  // Dependency inject
  interface IClassB
  {
    public void ActionB();
  }
  interface IClassC
  {
    public void ActionC();
  }

  class ClassC : IClassC
  {
    public ClassC() => Console.WriteLine("ClassC is created");
    public void ActionC() => Console.WriteLine("Action in ClassC");
  }

  class ClassB : IClassB
  {
    IClassC c_dependency;
    public ClassB(IClassC classc)
    {
      c_dependency = classc;
      Console.WriteLine("ClassB is created");
    }
    public void ActionB()
    {
      Console.WriteLine("Action in ClassB");
      c_dependency.ActionC();
    }
  }


  class Horn
  {
    int level = 0;
    public Horn(int level) => this.level = level;
    public void Beep()
    {
      WriteLine("Beep");
      Console.Beep();
      Console.Beep();
      WriteLine("Beep " + level);
    }
  }

  class Car
  {
    public Horn horn { get; set; }
    // Inject by initial Method
    public Car(Horn horn) => this.horn = horn;
    public void Beep()
    {
      horn.Beep();
    }
  }
  public interface IHorn
  {
    void Beep();
  }
  public class Car2
  {
    IHorn horn;
    public Car2(IHorn horn) => this.horn = horn;
    public void Beep() => this.horn.Beep();
  }
  public class LoudHorn : IHorn
  {
    public void Beep() => WriteLine("Còi kêu to lắm");
  }
  public class LightHorn : IHorn
  {
    public void Beep() => WriteLine("Còi kêu bé lắm");
  }
  public static class Program
  {
    public static void Main(string[] args)
    {
      // ClassC classC = new ClassC();
      // ClassB classB = new ClassB(classC);
      // ClassA classA = new ClassA(classB);
      // classA.ActionA();
      Console.OutputEncoding = Encoding.UTF8;
      Horn horn = new Horn(1);
      Car car = new Car(horn);
      car.horn = horn;
      car.Beep();

      // Dependecy Injection library
      // DI Container
      // Register and Get Service
      // Service Provider -> Get Service
      var service = new ServiceCollection();

      // Dang ky cac dich vu

      // var a = provider.GetService<TypeService>();
      service.AddSingleton<IClassC, ClassC>();

      var provider = service.BuildServiceProvider();
      // Service registration in Singleton type

      for (int i = 0; i < 5; i++)
      {
        IClassC c = provider.GetService<IClassC>();
        WriteLine(c.GetHashCode());
      }

      // Service registration in Transient
      service.AddTransient<IClassC, ClassC>();

      var provider2 = service.BuildServiceProvider();
      // Service registration in Singleton type

      for (int i = 0; i < 5; i++)
      {
        IClassC c = provider2.GetService<IClassC>();
        WriteLine(c.GetHashCode());
      }

      WriteLine();
      Car2 car2= new Car2(new LoudHorn());
      Car2 car3= new Car2(new LightHorn());
      car2.Beep();
      WriteLine();
      car3.Beep();
      WriteLine();
      service.AddSingleton<IHorn, LoudHorn>();
      IHorn horn1 = service.BuildServiceProvider().GetService<IHorn>();
      WriteLine("Afer using provider");
      horn1.Beep();
      WriteLine();
      WriteLine();
    }
  }
}