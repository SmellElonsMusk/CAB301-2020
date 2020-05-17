using System;
using System.Reflection.Metadata.Ecma335;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MovieCollection movieCollection = new MovieCollection(); // Initliase The class
            movieCollection.createCollection(); // Creates the list
            MainMenu(movieCollection);
        }

       



        public static void MainMenu(MovieCollection movieCollection)
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
                MenuItem(num, movieCollection);
            } else { Console.WriteLine("Please enter a valid Number");}

        }

        // Login Page

        public static void staffLogin()
        {
            bool succesful = false;
            string input1;
            string input2;

            while (succesful == false)
            {
                Console.Write("Enter Username: "); input1 = Console.ReadLine();
                Console.Write("Enter Password: "); input2 = Console.ReadLine();
                if (input1 == "staff" && input2 == "123")
                {
                    succesful = true;
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Login failed. Please try again.");
                    succesful = false;
                }
            }
        }

        public static void memberLogin()
        {

            // Probably need to add a method that checks if the member list has any members
            // check if the username exits, then if not throw an error. If member exists must 
            // use correct password - if not keep looping

            bool succesful = false;
            string input1;
            string input2;

            // Testing code for now
            while (succesful == false)
            {
                Console.Write("Enter Username: "); input1 = Console.ReadLine();
                Console.Write("Enter Password: "); input2 = Console.ReadLine();
                if (input1 == "member" && input2 == "123")
                {
                    succesful = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Login failed. Please try again.");
                    succesful = false;
                }
            }
        }


        public static void MenuItem(int mainMenuSelection, MovieCollection movieCollection)
        {
            if (mainMenuSelection == 0)
            {
                Environment.Exit(0);
            } else
            {

                switch (mainMenuSelection)
                {

                    case 1:
                        staffLogin();
                        Console.Clear();
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
                        memberLogin();
                        Console.Clear();
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
                }
            }
            

            string input = Console.ReadLine();
            // Check if input is a number 
            int num;
            bool result = int.TryParse(input, out num);
            if (result)
            {
                Console.Clear();
                Do(mainMenuSelection, num, movieCollection);
            }
            else { Console.WriteLine("Please enter a valid Number"); }
        }

        public static void Do(int menu, int selection, MovieCollection movieCollection)
        {
            bool repeatMenu = true;

            switch (menu) 
            {
                case 1: // Staff Menu

                    if (selection == 0)
                    {
                        MainMenu(movieCollection);
                    }

                    switch (selection) 
                    {
                        case 1: // Add a new movie DVD
                            // TODO: needs more work
                            while (repeatMenu == true) {
                                movieCollection.addMovie();
                                Console.WriteLine("----------------------------");
                                Console.Write("Do you want to add another? y/n: ");

                                if (Console.ReadLine() == "y")
                                {
                                    repeatMenu = true;
                                } 
                                
                                if (Console.ReadLine() == "n")
                                {
                                    repeatMenu = false;
                                }
                            }                         
                            break;
                        case 2: // Remove a movie DVD
                            movieCollection.removeMovie();
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("1. Add Another");
                            Console.WriteLine("Please Make a selection (1, or 0 to return to main menu):");
                            break;
                        case 3: // Add a new member
                            Console.WriteLine("Staff Menu Option 3");
                            break;
                        case 4:
                            Console.WriteLine("Staff Menu Option 4");
                            break;
                    }
                    break;

                case 2: // Member Menu
                    if (selection == 0)
                    {
                        MainMenu(movieCollection);
                    }
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
                    }
                    break;
            }
        }
    }
}
