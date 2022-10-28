using FizzBuzz.Service;
using System;
using System.Linq;

namespace FizzBuzz
{
    class FizzBuzz
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============Fizz Buzz ==============");

            int start = GetInput("start");

            int end = GetInput("end");

            while (start >= end)
            {
                Console.WriteLine($"Start({start}) value should be less then End({end}) vlaue");

                start = GetInput("start");

                end = GetInput("end");
            }

            var results = new FizzBuzzGame().Run(start, end);

            Console.WriteLine("Fizz Buzz list: ");
            Console.WriteLine("---------------");
            foreach (var item in results)
            {
                Console.WriteLine($"{item}");
            }
            
        }


        private static int GetInput(string type)
        {
            Console.WriteLine($"Enter {type} value: ");

            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"Enter {type}: ");
                input = Console.ReadLine();
            }


            if (int.TryParse(input, out int number))
            {
                return number;
            }

            Console.WriteLine("Please enter a valid number");

            return GetInput(type);
        }
    }
}
