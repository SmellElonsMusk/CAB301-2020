using System;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("-----------Main Menu------------");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please Make a selection (1-2, or 0 to exit):");

            // Read Console Input
            string input = Console.ReadLine();

            // Check if input is a number 
            int num;
            bool result = int.TryParse(input, out num);
            if (result)
            {
                Console.Clear();
                MenuItem(num);
            } else { Console.WriteLine("Please enter a valid Number");}

        }

        public static void MenuItem(int mainMenuSelection)
        {
            switch(mainMenuSelection)
            {
                case 1:
                    Console.WriteLine("---------Staff Menu----------");
                    Console.WriteLine("1. Add a new movie DVD");
                    Console.WriteLine("2. Remove a movie DVD");
                    Console.WriteLine("3. Register a new Member");
                    Console.WriteLine("4. Find a registered member's phone number");
                    Console.WriteLine("0. Return to main menu");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Please Make a selection (1-4, or 0 to return to main menu):");
                    break;

                case 2:
                    Console.WriteLine("--------Member Menu---------");
                    Console.WriteLine("1. Display all movies");
                    Console.WriteLine("2. Borrow a movie DVD");
                    Console.WriteLine("3. Return a movie DVD");
                    Console.WriteLine("4. List current borrowed movie DVD's");
                    Console.WriteLine("5. Display top 10 most popular movies");
                    Console.WriteLine("0. Return to main menu");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Please Make a selection (1-2, or 0 to return to main menu):");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;

            }

            string input = Console.ReadLine();
            // Check if input is a number 
            int num;
            bool result = int.TryParse(input, out num);
            if (result)
            {
                Console.Clear();
                Do(mainMenuSelection, num);
            }
            else { Console.WriteLine("Please enter a valid Number"); }
        }

        public static void Do(int menu, int selection)
        {
            switch (menu) 
            {
                case 1: // Staff Menu
                    switch (selection) 
                    {
                        case 1: // Add what to do
                            Console.WriteLine("Staff Menu Option 1");
                            break;
                        case 2:
                            Console.WriteLine("Staff Menu Option 2");
                            break;
                        case 3: // Add a new member
                            Console.WriteLine("Staff Menu Option 3");
                            break;
                        case 4:
                            Console.WriteLine("Staff Menu Option 4");
                            break;
                        case 5: MainMenu();
                            break;
                    }
                    break;

                case 2: // Member Menu
                    switch (selection) 
                    {
                        case 1: // Add what to do
                            Console.WriteLine("Member Menu Option 1");
                            break;
                        case 2:
                            Console.WriteLine("Member Menu Option 2");
                            break;
                        case 3:
                            Console.WriteLine("Member Menu Option 3");
                            break;
                        case 4:
                            Console.WriteLine("Member Menu Option 4");
                            break;
                        case 5:
                            Console.WriteLine("Member Menu Option 5");
                            break;
                        case 6: MainMenu();
                            break;
                    }
                    break;
            }
        }
    }
}
