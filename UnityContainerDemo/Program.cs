using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Unity;
//using Microsoft.Practices.Unity;

namespace UnityContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Manually Object Creation and Injection
            //Driver driver = new Driver(new BMW());
            //driver.RunCar();

            IUnityContainer container = new UnityContainer();
            //Register
            container.RegisterType<ICar, BMW>();// Map ICar with BMW
            //Resolves dependencies and returns the Driver object 
            Driver drv = container.Resolve<Driver>();
            drv.RunCar();

            Console.ReadLine();
        }
    }
    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }
    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
