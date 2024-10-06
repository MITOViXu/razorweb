# Dependencies injection and ServiceCollection 🎇🎆🎟🎞🛒🎭

## Inverse dependency 🥽🥼🕶👓

```
using static System.Console;
using System.IO;
namespace CS33
{

  // Depency Injection
  // Inverse Dependency
  class ClassC
  {
    public void ActionC() => Console.WriteLine("Action in ClassC");
  }

  class ClassB
  {
    // Phụ thuộc của ClassB là ClassC
    ClassC c_dependency;

    public ClassB(ClassC classc) => c_dependency = classc;
    public void ActionB()
    {
      Console.WriteLine("Action in ClassB");
      c_dependency.ActionC();
    }
  }

  class ClassA
  {
    // Phụ thuộc của ClassA là ClassB
    ClassB b_dependency;

    public ClassA(ClassB classb) => b_dependency = classb;
    public void ActionA()
    {
      Console.WriteLine("Action in ClassA");
      b_dependency.ActionB();
    }
  }
  public static class Program
  {
    public static void Main(string[] args)
    {
      ClassC classC = new ClassC();
      ClassB classB = new ClassB(classC);
      ClassA classA = new ClassA(classB);
      classA.ActionA();
    }
  }
}
```
![alt text](/assets/inverse.jpg)

## DI 
Install package
```
dotnet add package Microsoft.Extensions.DependencyInjection
```

