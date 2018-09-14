using System;

namespace FactoryCodeingExercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        

        public override string ToString()
        {
            return $"ID = {Id}; Name = {Name}";
        }
    }

    public class PersonFactory
    {
        private static int id = 0;
        public Person CreatePerson(string name)
        {
            return new Person { Id = id++, Name = name };
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            var person = new PersonFactory();
            var pf = person.CreatePerson("Pushkar");
            Console.WriteLine(pf.ToString());
            pf = person.CreatePerson("Maithili");
            Console.WriteLine(pf.ToString());
        }
    }
}
