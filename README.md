# Inheritance in c#🐨🐽
```
using System;
namespace CS13
{
  class Program
  {
    // Inheritance
    /*
      A inherits B 
      A - basic class, father class
      B - child class

      class B : A {}
    */

    class Animal
    {
      public int Legs { get; set; }
      public float Weight { get; set; }
      public Animal(){
        Console.WriteLine("Khoi tao Animal");
      }
      public Animal(string abc){
        Console.WriteLine("Khoi tao Animal (2)");
      }
      public void ShowLegs()
      {
      
        Console.WriteLine($"Legs : {Legs}");
      }
    }

    class Cat : Animal
    {
      public string Food;
      public Cat() : base()
      
      {
        Console.WriteLine("Khoi tao Cat");
        this.Legs = 4;
        this.Food = "Mouse";
      }
      public Cat(string abc) : base(abc)
      
      {
        Console.WriteLine($"Khoi tao Cat (2) : {abc}");
        this.Legs = 4;
        this.Food = "Mouse";
      }
      public void Eat()
      {
        Console.WriteLine(Food);
      }
      public new void ShowLegs(){
        Console.WriteLine($@"Loai meo co so chan la : {Legs}");
      }
      public void ShowInfo(){
        // execute base class is Animal
        base.ShowLegs();
        ShowLegs();
      }
    }

    static public void Space()
    {
      Console.WriteLine("");
      Console.WriteLine("");
    }

    static void Main(string[] args)
    {
      Space();

      Cat c = new Cat("MEo");
      Console.WriteLine(c.Food);
      c.ShowInfo();

      Space();
    }
  }
}
```
