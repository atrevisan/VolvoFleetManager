using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoFleetManager.Presentation;

namespace VolvoFleetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            InputProcessor processor = new InputProcessor();
            while (true)
            {
                Console.WriteLine("Enter one of the following options:");
                Console.WriteLine("1) Insert a new vehicle");
                Console.WriteLine("2) Edit an existing vehicle");
                Console.WriteLine("3) Delete an existing vehicle");
                Console.WriteLine("4) List all vehicles");
                Console.WriteLine("5) Find a vehicle by chassisID");
                Console.WriteLine("6) Exit");

                string input = Console.ReadLine();

                int result = 0;
                bool success = Int32.TryParse(input, out result);

                if (!success)
                    Console.WriteLine("Invalid input");
                else if (result == 6)
                    break;
                else
                    processor.ProcessInput(result);


            }
        }
    }
}
