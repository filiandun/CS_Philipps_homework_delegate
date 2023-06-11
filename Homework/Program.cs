namespace Homework
{
    public delegate void DriveDelegate();

    public abstract class Car
    {
        public static event DriveDelegate OnDriveDelegate;

        protected static ushort distance = 1000; // общая дистанция в метрах

        protected ushort maxSpeed; // максимальная скорость в км/ч
        protected ushort acceleration; // ускорение в км/с
        protected char icon; // иконка

        public ushort currentDistance = 0; // текущее положение на дистанции в м
        private ushort currentSpeed = 0; // текущая скорост в км/ч
        private ushort time = 0; // потраченное время

        Random random = new Random();

        public void Start()
        {
            int readyOrNot = random.Next(0, 2);
            if (readyOrNot == 0)
            {
                this.Drive();
            }
            else
            {
                Console.WriteLine($"Авто {this.icon} не может участвовать в гонке.");
            }
        }

        public void Drive()
        {     
            if (this.currentDistance < distance)
            {
                if (this.currentSpeed < this.maxSpeed)
                {
                    this.currentSpeed += (ushort)random.Next(this.acceleration - 3, this.acceleration + 2);
                }

                if (this.currentSpeed >= this.maxSpeed)
                {
                    this.currentSpeed = (ushort)this.random.Next(this.maxSpeed - 3, this.maxSpeed + 8);
                }

                this.currentDistance += (ushort)(this.currentSpeed * 1000 / 3600);
                this.time++;
            }

            Console.Write("START ");
            for (int i = 0; i < 100; ++i)
            {
                if (i == this.currentDistance / 10)
                {
                    Console.Write(this.icon);
                }
                else
                {
                    Console.Write("_");
                }
            }
            Console.Write(" FINISH");

            Console.Write($" | SPEED: {this.currentSpeed} km/h");
            Console.Write($" | DISTANCE: {this.currentDistance} m");
            Console.WriteLine($" | TIME: {this.time} s\n");
        }

        public void Finish()
        {
            if (this.currentDistance >= distance)
            {
                OnDriveDelegate += this.Finish;

                Console.Write("START ");
                for (int i = 0; i < 100; ++i)
                {
                    if (i == this.currentDistance / 10)
                    {
                        Console.Write(this.icon);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.Write(" FINISH");

                Console.Write($" | MAXSPEED: {this.maxSpeed} km/h");
                Console.WriteLine($" | TIME: {this.time} s\n");
            }

            OnDriveDelegate();
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

            DriveDelegate driveDelegate = null;

            driveDelegate = cars[0].Drive;
            driveDelegate += cars[1].Drive;
            driveDelegate += cars[2].Drive;

            while (cars[0].currentDistance < 1000)
            {
                Thread.Sleep(1000);
                Console.Clear();

                driveDelegate();
            }

            // Ничего мне непонятно, хрень какую-то сделал
        }
    }
}