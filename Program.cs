using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CAB301
{
    /// <summary>
    /// CAB301: Assignment 1.
    /// </summary>
    /// @author: Waldo Fouche, n9950095
    /// @date: 2020
    class Program
    {
        /* Intialises Member and Movie collection classes
         * 
         */
        MemberCollection memberCollection = new MemberCollection();
        BinarySearchTree movieList = new BinarySearchTree();
        private static string userName;

        /// <summary>
        /// Main Program that runs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            MovieCollection movieCollection = new MovieCollection(); // Initliase The class
            MemberCollection memberCollection = new MemberCollection(); // initliases memberCollection Class
            //BinarySearchTree movieList = new BinarySearchTree();

            // Adds 3 Members to the program
            memberCollection.registerMembers();

            // Adds 15 Movies to the BST
            movieCollection.AddMovies();
            MainMenu(movieCollection, memberCollection);

        }

        /* Main Menu 
         * 
         */ // Finished
        public static void MainMenu(MovieCollection movieCollection, MemberCollection memberCollection)
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

            // Check if input is a number 1
            int num;
            bool result = int.TryParse(input, out num);
            if (result)
            {
                Console.Clear();
                if (num == 1)
                {
                    staffLogin();
                    MenuItem(num, movieCollection, memberCollection);
                }
                else if (num == 2)
                {
                    memberLogin(memberCollection);
                    MenuItem(num, movieCollection, memberCollection);
                }
            }
            else
            {
                Console.Clear();
               
                Console.WriteLine("Please enter a valid Number \n");
                MainMenu(movieCollection, memberCollection);

            }

        }

        /* Menu Item Selections
         * Sub Menus
         */ // Finished
        public static void MenuItem(int mainMenuSelection, MovieCollection movieCollection, MemberCollection memberCollection)
        {
            if (mainMenuSelection == 0)
            {
                Environment.Exit(0);
            }
            else
            {

                switch (mainMenuSelection)
                {

                    case 1:
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
                Do(mainMenuSelection, num, movieCollection, memberCollection);
            }
            else { Console.WriteLine("Please enter a valid Number"); }
        }

        /* Menu Do action
         */ // NOT Finished -> add member features and display top 10 Movies
        public static void Do(int menu, int selection, MovieCollection movieCollection, MemberCollection memberCollection)
        {


            bool repeatMenu = true;


            switch (menu)
            {
                case 1: // Staff Menu

                    if (selection == 0)
                    {
                        MainMenu(movieCollection, memberCollection);
                    }

                    switch (selection)
                    {
                        case 1: // Add a new movie DVD
                            while (repeatMenu)
                            {
                                movieCollection.addMovie();
                                Console.Clear();
                                Console.WriteLine("----------Add DVD-----------");
                                Console.WriteLine("1. Add Another Movie ");
                                Console.WriteLine("----------------------------");

                                Console.WriteLine("Please make a selection (1, or 0 to return to previous menu): ");

                                if (Console.ReadLine() == "1")
                                {
                                    repeatMenu = true;
                                }
                                else
                                {
                                    repeatMenu = false;
                                    Console.Clear();
                                    MenuItem(1, movieCollection, memberCollection);
                                }


                            }
                            break;
                        case 2: // Remove a movie DVD
                            while (repeatMenu)
                            {
                                movieCollection.removeMovie();
                                
                                Console.WriteLine("--------Remove DVD----------");
                                Console.WriteLine("1. Remove Another Movie ");
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("Please Make a selection (1, or 0 to return to main menu):");

                                if (Console.ReadLine() == "1")
                                {
                                    repeatMenu = true;
                                }
                                else
                                {
                                    repeatMenu = false;
                                    Console.Clear();
                                    MenuItem(1, movieCollection, memberCollection);
                                }
                            }

                            break;
                        case 3: // Add a new member
                            while (repeatMenu)
                            {
                                memberCollection.register();

                                Console.Clear();
                                Console.WriteLine("---------Add Member---------");
                                Console.WriteLine("1. Add Another Member ");
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("Please make a selection (1, or 0 to return to previous menu): ");

                                if (Console.ReadLine() == "1")
                                {
                                    repeatMenu = true;
                                }
                                else
                                {
                                    repeatMenu = false;
                                    Console.Clear();
                                    MenuItem(1, movieCollection, memberCollection);
                                }
                            }
                            break;
                        case 4: // Find Member's Phone Number
                            while (repeatMenu)
                            {
                                memberCollection.FindMember();

                                Console.WriteLine("--------Find Member---------");
                                Console.WriteLine("1. Find Another Member ");
                                Console.WriteLine("----------------------------");
                                Console.WriteLine("Please make a selection (1, or 0 to return to previous menu): ");

                                if (Console.ReadLine() == "1")
                                {
                                    repeatMenu = true;
                                }
                                else
                                {
                                    repeatMenu = false;
                                    Console.Clear();
                                    MenuItem(1, movieCollection, memberCollection);
                                }
                            }
                            break;

                    }
                    break;

                case 2: // Member Menu
                    if (selection == 0)
                    {
                        MainMenu(movieCollection, memberCollection);
                    }
                    switch (selection)
                    {
                        case 1: // List DVD's                            
                            Console.WriteLine("--------Current Movies------");
                            movieCollection.displayAllMovies();
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Please press 0 to return to previous menu: ");

                            if (Console.ReadLine() == "0")
                            {
                                Console.Clear();
                                MenuItem(2, movieCollection, memberCollection);
                            }
                            break;
                        case 2: // Borrow a DVD
                            movieCollection.displayAllMovies();

                            Console.WriteLine("---------Borrow Movie-----------");
                            Console.Write("Enter movie title: "); string title = Console.ReadLine();
                            memberCollection.BorrowMovie(memberCollection.FindMember(userName), movieCollection.findMovie(title));
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Please press 0 to return to previous menu: ");

                            if (Console.ReadLine() == "0")
                            {
                                Console.Clear();
                                MenuItem(2, movieCollection, memberCollection);
                            }

                            break;
                        case 3: // Return a DVD

                            Console.WriteLine("--------Return Movie--------");
                            memberCollection.ListHeld(memberCollection.FindMember(userName));
                            Console.Write("Enter movie title: "); title = Console.ReadLine();
                            memberCollection.ReturnMovie(memberCollection.FindMember(userName), movieCollection.findMovie(title));
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Please press 0 to return to previous menu: ");

                            if (Console.ReadLine() == "0")
                            {
                                Console.Clear();
                                MenuItem(2, movieCollection, memberCollection);
                            }
                            break;
                        case 4: // List Current Borrowed DVD's
                            Console.WriteLine("-------Currently Held-------");

                            memberCollection.ListHeld(memberCollection.FindMember(userName));

                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Please press 0 to return to previous menu: ");

                            if (Console.ReadLine() == "0")
                            {
                                Console.Clear();
                                MenuItem(2, movieCollection, memberCollection);
                            }

                            break;
                        case 5: // Display Top 10 Most Borrowed DVD's
                            Console.WriteLine("-----------Top 10------------");
                            movieCollection.TopTen();

                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Please press 0 to return to previous menu: ");

                            if (Console.ReadLine() == "0")
                            {
                                Console.Clear();
                                MenuItem(2, movieCollection, memberCollection);
                            }
                            break;
                    }
                    break;
            }
        }

        /* Staff Login Page
         */ // Finished
        public static void staffLogin()
        {
            bool succesful = false;
            string input1;
            string input2;
            Console.WriteLine("----------Staff Login-----------");
            while (!succesful)
            {

                Console.Write("Enter Username: "); input1 = Console.ReadLine();
                Console.Write("Enter Password: "); input2 = Console.ReadLine();
                if (input1 == "staff" && input2 == "today123")
                {
                    succesful = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("----------Staff Login-----------");
                    Console.WriteLine("Login failed. Please try again.");


                }
            }
        }

        /* Member Login Page
         */ // Finished
        public static void memberLogin(MemberCollection memberCollection)
        {

            // Probably need to add a method that checks if the member list has any members
            // check if the username exits, then if not throw an error. If member exists must 
            // use correct password - if not keep looping

            bool succesful = false;
            string input1;
            string input2;
            string[] usernames = new string[10];
            int[] passwords = new int[10];

            for (int i = 0; i < memberCollection.GetSize(); i++)
            {
                Member member = memberCollection.returnArray()[i];
                usernames[i] = member.getUsername();
                passwords[i] = member.getPassword();
            }


            Console.WriteLine("---------Member Login-----------");
            while (!succesful)

            {
                Console.Write("Enter Username: "); userName = Console.ReadLine();
                Console.Write("Enter Password: "); input2 = Console.ReadLine();


                if (usernames.Contains(userName) && passwords.Contains(Int32.Parse(input2)))
                {

                    succesful = true;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Login failed. Please try again.");
                    Console.WriteLine("---------Member Login-----------");

                    succesful = false;
                }
            }
        }

        // ---------------------------------------------------------------------

        /*  Testing code used to test member and BST without using main menu
         * 
         */


        /* Testing code 
         * Build  Add movies and members without using menu
         */
        public static void TestCodeMovie()
        {


            Movie newMovie1 = new Movie();
            Movie newMovie2 = new Movie();
            Movie newMovie3 = new Movie();
            Movie newMovie4 = new Movie();
            Movie newMovie5 = new Movie();
            Movie newMovie6 = new Movie();
            Movie newMovie7 = new Movie();
            Movie newMovie8 = new Movie();
            Movie newMovie9 = new Movie();
            Movie newMovie10 = new Movie();


            // Test Alphabetical Sorting

            //newMovie1.create("A", "Harrison Ford", "George Lucas", "125", "Sci-Fi", "M", "1977");
            //newMovie2.create("B", "Harrison Ford", "George Lucas", "127", "Sci-Fi", "M", "1980");
            //newMovie3.create("C", "Harrison Ford", "George Lucas", "136", "Sci-Fi", "M", "1983");
            //newMovie4.create("D", "Ewan McGreggor", "George Lucas", "133", "Sci-Fi", "M", "1999");
            //newMovie5.create("E", "Ewan McGreggor", "George Lucas", "142", "Sci-Fi", "M", "2002");
            //newMovie6.create("F", "Ewan McGreggor", "George Lucas", "140", "Sci-Fi", "M", "2005");
            //newMovie7.create("G", "Daisy Ridley", "J.J. Abrams", "135", "Sci-Fi", "M", "2015");
            //newMovie8.create("H", "Daisy Ridley", "Rian Johnson", "152", "Sci-Fi", "M", "2017");
            //newMovie9.create("I", "Daisy Ridley", "J.J. Abrams", "142", "Sci-Fi", "M", "2019");


            newMovie1.create("Star Wars Episode IV: A New Hope", "Harrison Ford", "George Lucas", "125", Genre.SciFi, Classification.M, "1977", 2);
            newMovie2.create("Star Wars Episode V: Empire Strikes Back", "Harrison Ford", "George Lucas", "127", Genre.SciFi, Classification.M, "1980", 3);
            newMovie3.create("Star Wars Episode VI: Return of the Jedi", "Harrison Ford", "George Lucas", "136", Genre.SciFi, Classification.M, "1983", 5);
            newMovie4.create("Star Wars Episode I: The Phantom Menace", "Ewan McGreggor", "George Lucas", "133", Genre.SciFi, Classification.M, "1999", 2);
            newMovie5.create("Star Wars Episode II: Attack of the Clones", "Ewan McGreggor", "George Lucas", "142", Genre.SciFi, Classification.M, "2002", 1);
            newMovie6.create("Star Wars Episode III: Revenge of the Sith", "Ewan McGreggor", "George Lucas", "140", Genre.SciFi, Classification.M, "2005", 4);
            newMovie7.create("Star Wars Episode VII: The Force Awakens", "Daisy Ridley", "J.J. Abrams", "135", Genre.SciFi, Classification.M, "2015", 2);
            newMovie8.create("Star Wars Episode VIII: The Last Jedi", "Daisy Ridley", "Rian Johnson", "152", Genre.SciFi, Classification.M, "2017", 2);
            newMovie9.create("Star Wars Episode IX: The Rise of Skywalker", "Daisy Ridley", "J.J. Abrams", "142", Genre.SciFi, Classification.M, "2019", 1);

            BinarySearchTree movieList = new BinarySearchTree();

            movieList.Add(newMovie1);
            movieList.Add(newMovie2);
            movieList.Add(newMovie3);
            movieList.Add(newMovie4);
            movieList.Add(newMovie5);
            movieList.Add(newMovie6);
            movieList.Add(newMovie7);
            movieList.Add(newMovie8);
            movieList.Add(newMovie9);

            // Test Height:
            Console.WriteLine("The current Height of the tree is: " + movieList.Height());


            // Test Sorting
            Console.WriteLine("InOrder: ");
            movieList.InOrderTraversal();
            Console.WriteLine("PreOrder: ");
            movieList.PreOrderTraversal();
            Console.WriteLine("PostOrder: ");
            movieList.PostOrderTraversal();

            // Test Deletion
            Console.WriteLine("Delete Movie Test: ");
            movieList.Remove(newMovie7);
            movieList.Remove(newMovie4);
            movieList.Remove(newMovie5);
            movieList.Remove(newMovie6);
            movieList.Remove(newMovie7);
            movieList.PreOrderTraversal();

            Console.WriteLine("The current Height of the tree is: " + movieList.Height());

            // Console.WriteLine("Enter Movie Name: ");
            //Movie chosen = new Movie();
            //chosen = movieList.FindMovie(Console.ReadLine());

            //Console.WriteLine("The Chosen Movie is: " );


        }

        /* Testing code 
         * Build  Add movies and members
         */
        public static void TestCodeMember(MemberCollection memberCollection)
        {
            //MemberCollection memberCollection = new MemberCollection();
            //memberCollection.registerTest();

            Console.WriteLine("Username and Password Test: ");
            for (int i = 0; i < memberCollection.GetSize(); i++)
            {
                Console.Write("Username :"); Console.WriteLine(memberCollection.returnMember(i).getUsername());
                Console.Write("Password :"); Console.WriteLine(memberCollection.returnMember(i).getPassword());

            }
        }
    }

}
