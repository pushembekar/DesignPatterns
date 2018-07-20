using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    public enum RelationShip
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationShipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low level 
    public class RelationShips : IRelationShipBrowser
    {
        private List<(Person, RelationShip, Person)> relations = new List<(Person, RelationShip, Person)>();

        public void AddPersonAndChild (Person parent, Person child)
        {
            relations.Add((parent, RelationShip.Parent, child));
            relations.Add((child, RelationShip.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                        x.Item2 == RelationShip.Parent
                ))
            {
                yield return r.Item3;
            }
        }

        // public List<(Person, RelationShip, Person)> Relations => relations;
    }


    class Program
    {
        //public Program(RelationShips relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach(var r in relations.Where(
        //        x => x.Item1.Name == "John" &&
        //                x.Item2 == RelationShip.Parent
        //        ))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Program(IRelationShipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new RelationShips();
            relationships.AddPersonAndChild(parent, child1);
            relationships.AddPersonAndChild(parent, child2);

            var p = new Program(relationships);
        }
    }
}
