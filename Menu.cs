using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace CAB301
{
    class Menu
    {
        private int input;

        public int Main()
        {
            
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("-----------Main Menu------------");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please Make a selection (1-2, or 0 to exit):");

            this.input = int.Parse(Console.ReadLine());

            return input;
        }

        public int staff()
        {
            Console.WriteLine("---------Staff Menu----------");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Return to main menu");

            Console.WriteLine("Please Make a selection (1-4, or 0 to return to main menu):");
            this.input = int.Parse(Console.ReadLine());
            return input;
        }

        public int member()
        {
            Console.WriteLine("--------Member Menu---------");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movie DVD's");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");

            Console.WriteLine("Please Make a selection (1-2, or 0 to return to main menu):");
            this.input = int.Parse(Console.ReadLine());
            return input;
        }

        public int getInput()
        {
            return this.input;
        }
    }
        
}
