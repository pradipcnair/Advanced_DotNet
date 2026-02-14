namespace StaticConstuctor
{
    public class Program
    {
        public static void Main()
        {
            StaticConstructor instance1 = new StaticConstructor();
            instance1.DisplayValue();
        }
    }
    public class StaticConstructor
    {
        public static int Value { get; set; }
        static StaticConstructor()
        {
            Value = 42;
            Console.WriteLine("Static constructor called.");
        }

        public void DisplayValue()
        {
            Console.WriteLine($"Value: {Value}");
        }
    }
}
