using EF5MySQLNetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF5MySQLNetCoreDemo
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly ModelContext _context;

        protected ModelContext Context => _context;

        public ConsoleApplication(ModelContext context)
        {
            _context = context;
        }

        public void Run()
        {
            var count = Context.Cars.Count();
            Console.WriteLine($"{count} car(s) found");
            if (count == 0)
            {
                Console.WriteLine("Do you want to add some cars (y/n)");

                var key = Console.ReadLine().ToLower();

                if (key == "y")
                {
                    List<Car> cars = new List<Car>();

                    cars.Add(new Car { Manufacturer = "Nissan", Model = "Pathfinder", Year = 2008 });
                    cars.Add(new Car { Manufacturer = "Honda", Model = "Civic", Year = 2013 });
                    cars.Add(new Car { Manufacturer = "Volkswagen", Model = "Golf", Year = 2012 });

                    Context.Cars.AddRange(cars);
                    Context.SaveChanges();

                    Console.WriteLine("3 cars were added");

                    PrintCars(Context.Cars.ToList());
                }
            }
            else
            {
                PrintCars(Context.Cars.ToList());
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void PrintCars(IList<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Year} {car.Manufacturer} {car.Model}");
            }
        }
    }
}
