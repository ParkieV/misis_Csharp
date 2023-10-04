
namespace DynamicMassive
{
    class Person
    {
        private string name; private int age;
        public Person(string name, int age)
        {
            this.name = name; this.age = age;
        }

        public override string ToString()
        {
            return name + " " + age;
        }
    }

    class PersonList {
        private Person[] people;
        int count;
        public PersonList(int Capacity)
        {
            this.people = new Person[Capacity];
            count = 0;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return people[i];
            }
        }

        public Person this[int index]
        { 
            get 
            { 
                return people[index]; 
            } 
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            PersonList person = new PersonList(20);
            person.Add(new Person("Ann", 19)); person.Add(new Person("Ann", 19));
            for (int i = 0; i < person.Count; i++)
            {
                Console.WriteLine(person[i]);
            }
            Person person1 = new Person("Bob", 45);
            bool isBobHere = person.Contains(person[0]);
            Console.WriteLine(isBobHere);

            foreach (Person person2 in person)
                Console.WriteLine(person2);

        }
    }
}