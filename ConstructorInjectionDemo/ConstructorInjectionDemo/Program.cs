
using System;
namespace ConstructorInjectionDemo
{
    /// <summary>
    /// This application is an example of Constructor Injection to have 
    /// loose coupling.
    /// </summary>
    class Program
    {
        static void Main( string[] args )
        {
            int numberOfPassengers;
            string passengerInput;

            do
            {
                System.Console.Write( "Please enter number of passengers : " );
                passengerInput = Console.ReadLine();
                Console.WriteLine( "\n" );

            } while (!Int32.TryParse( passengerInput, out numberOfPassengers ));

            DecideVehicle( numberOfPassengers );

            Console.WriteLine( "\nPress any key to exit." );
            Console.ReadKey();

        }

        private static void DecideVehicle( int numberOfPassengers )
        {
            Driver driver;

            if (numberOfPassengers == 0)
            {
                Console.WriteLine( "Cannot go without a passenger." );
                return;
            }
            else if (numberOfPassengers == 1)
            {
                var avendator = new Avendator();
                driver = new Driver( avendator );
            }
            else if (numberOfPassengers > 1 && numberOfPassengers < 5)
            {
                var civic = new Civic();
                driver = new Driver( civic );
            }
            else if (numberOfPassengers > 5 && numberOfPassengers <= 8)
            {
                var sienna = new Sienna();
                driver = new Driver( sienna );
            }
            else
            {
                Console.WriteLine( "Too many passengers." );
                return;
            }
            driver.Drive( numberOfPassengers );
        }
    }

    class Driver
    {
        ICar _car;

        // Injecting ICar interface to constructor
        public Driver( ICar car )
        {
            _car = car;
        }

        public void Drive( int numberOfPassengers )
        {
            _car.Drive( numberOfPassengers );
        }
    }

    class Avendator : ICar
    {
        public void Drive( int numberOfPassengers )
        {
            Console.WriteLine( "Driving a an Lamborghini Avendator with {0} passeger.",
                                numberOfPassengers );
        }
    }

    class Civic : ICar
    {
        public void Drive( int numberOfPassengers )
        {
            Console.WriteLine( "Driving a an Honda Civic with {0} passegers.",
                    numberOfPassengers );
        }
    }

    class Sienna : ICar
    {
        public void Drive( int numberOfPassengers )
        {
            Console.WriteLine( "Driving a an Toyota Sienna with {0} passegers.",
                    numberOfPassengers );
        }
    }

    interface ICar
    {
        void Drive( int numberOfPassengers );
    }
}
