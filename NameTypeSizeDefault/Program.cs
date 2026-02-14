using System.Runtime.InteropServices;

namespace NameTypeSizeDefault
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine( nameof(Player));
            Console.WriteLine( typeof(Player));

            Player player = new Player();
            player.SetSpeed(0);

            Console.WriteLine( nameof(Player.IsGrounded) );
            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(float));
            Console.WriteLine(sizeof(long));
            Console.WriteLine(sizeof(bool));
            Console.WriteLine(sizeof(ushort));
            Console.WriteLine(Marshal.SizeOf(new Player()));

            Console.WriteLine( RoutePayment("visa") );
            Console.WriteLine( new Box<int>().GetDefault() );
            Console.WriteLine( new Box<bool>().GetDefault() );
            Console.WriteLine( new Box<float>().GetDefault() );
            Console.WriteLine( new Box<Player>().GetDefault() );
        }

        public static string RoutePayment(string cardtype)
        {
            return cardtype.ToUpper() switch
            {
                "VISA" => "visa-gateway.com",
                "MASTERCARD" => "mc-gateway.com",
                "AMEX" => "amex-gateway.com",
                _ => "Unsupported card type."
            };
        }
    }

    public class Box<T>
    {
        public T GetDefault() => default(T);
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Player
    {
        public int speed;
        public int health;

        //Example of expression-bodied member
        public bool IsGrounded() => speed == 0;

        public void setHealth(int healthToSet) => this.health = healthToSet;

        public void SetSpeed(int speedToSet)
        {
            if (speedToSet <= 0)
            {
                Console.WriteLine("Invalid value. " + nameof(speedToSet) + " must be positive.");
                return;
            }
            this.speed = speedToSet;
        }
    }
}