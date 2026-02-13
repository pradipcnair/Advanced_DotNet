using System.Reflection;

namespace ReflectionDemo { 

    public class Program {
        public static void Main(string[] args)
        {
            // Get all nested types of the Exercise class. Note that we have not initialized the class yet
            Type[] exerciseType = typeof(Exercise).GetNestedTypes();
            // Loop through each nested type and print its name and methods
            foreach (var type in exerciseType)
            {
                // Print the name of the sub class inside the Exercise class
                Console.WriteLine(new string ('-',20));
                Console.WriteLine($"Class: {type.Name}");
                
                // Create an instance of the sub class using reflection
                object instance = Activator.CreateInstance(type);

                // Get all methods of the sub class and print their names and invoke them
                MethodInfo[] exerciseMethods = type.GetMethods();

                // Loop through each method and print its name and invoke it
                foreach (var method in exerciseMethods)
                {
                    // Skip the methods that are inherited from the Exercise class
                    if (method.IsSpecialName) continue;

                    // Skip the methods that are inherited from the Object class
                    if (new[] { "GetType", "ToString", "Equals", "GetHashCode" }.Contains(method.Name)) continue;

                    // Print the name of the method
                    Console.WriteLine(method.Name);

                    try
                    {
                        // Invoke the method and print its return value
                        Console.WriteLine(method.Invoke(instance, new Object[] { }));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error invoking method {method.Name}: {ex.Message}");
                    }
                }
                Console.WriteLine(new string('=', 30));
            }
        }
        public class Exercise
        {
            public virtual string Greet() => "Hello, World!";
            public virtual string Role() => "The Role in the Game";
            
            public virtual string Strength() => "The Strength Required";
            
            public class Player: Exercise
            {
                public override string Greet()
                {
                    return "Welcome, Player!";
                }
                public override string Role()
                {
                    return "The Player's Role in the Game";
                }
                public override string Strength()
                {
                    return "The Player's Strength Required";
                }
            }

            public class Manager: Exercise
            {
                public override string Greet()
                {
                    return "Welcome, Manager!";
                }
                public override string Role()
                {
                    return "The Manager's Role in the Game";
                }
                public override string Strength()
                {
                    return "The Manager's Strength Required";
                }
            }
        }
     }
}