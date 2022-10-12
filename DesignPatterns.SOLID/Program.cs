using System.Diagnostics;
using System.Formats.Asn1;
using DesignPatterns.SOLID;



// Single Responsibility Principle
Console.WriteLine();
Console.WriteLine("/////////////////////////////////////////////////");
Console.WriteLine("//////   Single Responsibility Principle  //////");
Console.WriteLine("///////////////////////////////////////////////");
var j = new Journal();
j.AddEntry("I am happy today");
j.AddEntry("I ate a bug");
Console.WriteLine(j);

var p = new Persistence();
var fileName = @"D:\Files\journal.txt";
p.SaveToFile(j, fileName);
Process.Start("notepad.exe", fileName);
// Single Responsibility Principle

//Open Close Principle
Console.WriteLine();
Console.WriteLine("/////////////////////////////////////////////////");
Console.WriteLine("//////         Open Close Principle       //////");
Console.WriteLine("///////////////////////////////////////////////");
var apple = new Product("Apple", Color.Green, Size.Small);
var tree = new Product("Tree", Color.Green, Size.Large);
var house = new Product("House", Color.Blue, Size.Large);

Product[] products = { apple, tree, house };

var pf = new ProductFilter();
Console.WriteLine("Green products (old):");
foreach (var product in pf.FilterByColor(products, Color.Green)!)
{
    Console.WriteLine($" - {product.Name} is green");
}

var bf = new BetterFilter();
Console.WriteLine("Green products (new):");
foreach (var product in bf.Filter(products,new ColorSpecification(Color.Green)))
{
    Console.WriteLine($" - {product.Name} is green");
}

Console.WriteLine("Large blue items");
foreach (var product in bf.Filter(
             products,
             new AndSpecification<Product>(
                 new ColorSpecification(Color.Blue),
                 new SizeSpecification(Size.Large)
                 )))
{
    Console.WriteLine($" - {product.Name} is big and blue");
}
//Open Close Principle


//Liskov Substitution Principle
Console.WriteLine();
Console.WriteLine("/////////////////////////////////////////////////");
Console.WriteLine("//////    Liskov Substitution Principle   //////");
Console.WriteLine("///////////////////////////////////////////////");

var rc = new Rectangle(2, 3);
Console.WriteLine($"{rc} has area {LSP.Area(rc)}");

Rectangle sq = new Square
{
    Width = 4
};
Console.WriteLine($"{sq} has area {LSP.Area(sq)}");

//Liskov Substitution Principle


//Interface Segregation Principle
Console.WriteLine();
Console.WriteLine("/////////////////////////////////////////////////");
Console.WriteLine("//////   Interface Segregation Principle  //////");
Console.WriteLine("///////////////////////////////////////////////");

// Everything it is in ISP class

//Interface Segregation Principle

//Dependency Inversion Principle
Console.WriteLine();
Console.WriteLine("/////////////////////////////////////////////////");
Console.WriteLine("//////   Dependency Inversion Principle   //////");
Console.WriteLine("///////////////////////////////////////////////");



//Dependency Inversion Principle