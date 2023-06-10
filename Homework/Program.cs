namespace Homework
{
    public abstract class Car
    {
        protected static ushort distance = 1000; // в метрах

        protected ushort maxSpeed; // в км/ч
        protected ushort acceleration; // в км/с
        protected char icon;

        public ushort currentDistance = 0;
        private ushort currentSpeed = 0;
        private ushort time = 0;
        Random random = new Random();

        public void Drive()
        {     
            if (currentDistance < distance)
            {
                if (currentSpeed < this.maxSpeed)
                {
                    currentSpeed += (ushort)random.Next(acceleration - 3, acceleration + 2);
                }

                if (currentSpeed >= this.maxSpeed)
                {
                    currentSpeed = (ushort)random.Next(maxSpeed - 3, maxSpeed + 8);
                }

                currentDistance += (ushort)(currentSpeed * 1000 / 3600);
                time++;
            }

            Console.Write("START ");
            for (int i = 0; i < 100; ++i)
            {
                if (i == currentDistance / 10)
                {
                    Console.Write(icon);
                }
                else
                {
                    Console.Write("_");
                }
            }
            Console.Write(" FINISH");

            Console.Write($" | SPEED: {currentSpeed} km/h");
            Console.Write($" | DISTANCE: {currentDistance} m");
            Console.WriteLine($" | TIME: {time} s\n");
        }
    }

    public class LadaPriora : Car
    {
        public LadaPriora(ushort maxSpeed, char icon, ushort acceleration) 
        {
            this.maxSpeed = maxSpeed;
            this.icon = icon;
            this.acceleration = acceleration;
        }
    }

    public class BugattiChiron : Car
    {
        public BugattiChiron(ushort maxSpeed, char icon, ushort acceleration)
        {
            this.maxSpeed = maxSpeed;
            this.icon = icon;
            this.acceleration = acceleration;
        }
    }

    public class TeslaModel3 : Car
    {
        public TeslaModel3(ushort maxSpeed, char icon, ushort acceleration)
        {
            this.maxSpeed = maxSpeed;
            this.icon = icon;
            this.acceleration = acceleration;
        }
    }



    internal class Program
    {
        static void Main()
        {
            Car[] cars =
                {
                    new LadaPriora(180, 'P', 12),
                    new BugattiChiron(350, 'B', 50),
                    new TeslaModel3(220, 'T', 30)
                };

            while (cars[0].currentDistance < 1000)
            {
                Thread.Sleep(1000);
                Console.Clear();
                foreach (Car car in cars)
                {
                    car.Drive();
                }
            }
        }
    }
}