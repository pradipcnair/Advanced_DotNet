namespace RecordsInCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person1 = new Person("Alice", 30);
            var person2 = person1 with { Name = "Kumaran"};
            var person3 = new Person("Alice", 30);
            Console.WriteLine(person1); // Output: Person { Name = Alice, Age = 30 }
            Console.WriteLine(person2); // Output: Person { Name = Alice, Age = 30 }
            Console.WriteLine(person1 == person3); // Output: True


            List<Person> peoples = new ()
            {
                new Person("Alice", 30),
                new Employee("Bob", 40, 50000),
                new Employee("Charlie", 25, 100000)
            };
            
            foreach (var person in peoples)
            {
                Console.WriteLine(person);
            }
            
        }
    }

    public record Person(string Name, int Age);
    public record Employee(string Name, int Age, float Salary) : Person(Name, Age);
}
