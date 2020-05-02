using System;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("-----------Main Menu------------");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please Make a selection (1-2, or 0 to exit):");

            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                Console.WriteLine("---------Staff Menu----------");
                Console.WriteLine("1. Add a new movie DVD");
                Console.WriteLine("2. Remove a movie DVD");

                Console.WriteLine("Please Make a selection (1-2, or 0 to exit):");
                Console.ReadLine();
            }
            else if (input == 2)
            {
                Console.WriteLine("--------Member Menu---------");

                Console.WriteLine("Please Make a selection (1-2, or 0 to exit):");
                Console.ReadLine();
            }
            else Environment.Exit(0);
        }
    }
}
