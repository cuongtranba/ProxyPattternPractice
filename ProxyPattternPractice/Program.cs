using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattternPractice
{
    //https://en.wikipedia.org/wiki/Proxy_pattern
    class Program
    {
        static void Main(string[] args)
        {
            // proxy 
            var driver1 = new Driver(16);
            ICar car1 = new ProxyCar(driver1);
            car1.DriveCar();

            var driver2 = new Driver(18);
            ICar car2 = new ProxyCar(driver2);
            car2.DriveCar();

            var image1 = new ProxyImage("image file 1");
            var image2 = new ProxyImage("image file 2");

            image1.DisplayImage(); // loading necessary
            image1.DisplayImage(); // loading unnecessary
            image2.DisplayImage(); // loading necessary
            image2.DisplayImage(); // loading unnecessary
            image1.DisplayImage(); // loading unnecessary
        }
    }

    public interface ICar
    {
        void DriveCar();
    }

    // real object
    public class Car : ICar
    {
        public void DriveCar()
        {
            Console.WriteLine("car has been driven!");
        }
    }

    //proxy object
    public class ProxyCar : ICar
    {
        private ICar realCar;
        private Driver driver;

        public ProxyCar(Driver driver)
        {
            this.driver = driver;
            realCar = new Car();
        }

        public void DriveCar()
        {
            if (driver.Age <= 16)
            {
                Console.WriteLine("sorry, the driver is too young to drive.");
            }
            else
            {
                realCar.DriveCar();
            }
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            this.Age = age;
        }
    }
}
