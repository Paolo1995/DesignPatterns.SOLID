using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <summary>
// Dependency Inversion Principle
// states that high-level modules/classes should not depend on low-level modules/classes.
// Both should depend upon abstractions. Secondly, abstractions should not depend upon details
// </summary>
namespace DesignPatterns.SOLID
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        //public DateTime DAteOfBirth;
    }

    //low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent,Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        //bad idea - because that one violate Dependency Inversion Principle
        //public List<(Person, Relationship, Person)> Relations => relations;


        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var item in relations.Where(
                         x =>
                             x.Item1.Name == name &&
                             x.Item2 == Relationship.Parent
                     ))
            {
                yield return item.Item3;
            }
        }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Research
    {
        //bad idea - because that one violate Dependency Inversion Principle
        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var item in relations.Where(
        //                 x => 
        //                     x.Item1.Name == "John" && 
        //                     x.Item2 == Relationship.Parent
        //                     ))
        //    {
        //        Console.WriteLine($"John has a child called {item.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (var person in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {person.Name}.");
            }
        }

        public static void CallingMethod()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
