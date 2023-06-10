namespace Homework
{
    public abstract class Car
    {
        protected ushort maxSpeed; // в км/ч
        protected static ushort distance = 1000; // в метрах
        protected char icon;

        public void Drive()
        {
            Random random = new Random();
            ushort currentDistance = 0;
            ushort currentSpeed = 0;
            ushort time = 0;
            
            while (currentDistance < distance)
            {
                Thread.Sleep(1000);
                Console.Clear();

                if (currentSpeed < this.maxSpeed)
                {
                    currentSpeed += (ushort)random.Next(0, maxSpeed / 10);
                }

                if (currentSpeed >= this.maxSpeed)
                {
                    currentSpeed = (ushort)random.Next(maxSpeed - 3, maxSpeed + 8);
                }

                currentDistance += (ushort)(currentSpeed * 1000 / 3600);
                time++;

                Console.Write("START ");
                for (int i = 0; i < 100; ++i)
                {
                    if (i == currentDistance / 10)
                    {
                        Console.Write(icon);
                    }
                    Console.Write("_");
                }
                Console.Write(" FINISH");

                Console.Write($" | SPEED: {currentSpeed} km/h");
                Console.Write($" | DISTANCE: {currentDistance} m");
            }
            Console.WriteLine($" | TIME: {time} s\n");
        }
    }

    public class LadaPriora : Car
    {
        public LadaPriora(ushort speed, char icon) 
        {
            this.maxSpeed = speed;
            this.icon = icon;
        }
    }

    public class BugattiChiron : Car
    {
        public BugattiChiron(ushort speed, char icon)
        {
            this.maxSpeed = speed;
            this.icon = icon;
        }
    }

    public class TeslaModel3 : Car
    {
        public TeslaModel3(ushort speed, char icon)
        {
            this.maxSpeed = speed;
            this.icon = icon;
        }
    }



    internal class Program
    {
        static void Main()
        {
            Car[] cars =
                {
                    new LadaPriora(180, 'P'),
                    new BugattiChiron(350, 'B'),
                    new TeslaModel3(220, 'T')
                };
            
            foreach (Car car in cars)
            {
                Console.Clear();
                Console.WriteLine("\n");

                car.Drive();
            }
        }
    }
}