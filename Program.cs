using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace CAB301
{
    class Program
    {
        MemberCollection memberCollection = new MemberCollection();
        BinarySearchTree movieList = new BinarySearchTree();
        static void Main(string[] args)
        {

            MovieCollection movieCollection = new MovieCollection(); // Initliase The class
            MemberCollection memberCollection = new MemberCollection(); // initliases memberCollection Class
            BinarySearchTree movieList = new BinarySearchTree();

            TestCode();

            //MainMenu(movieCollection, memberCollection);
            
        }

        /*Main Menu 
         * 
         */
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
                MenuItem(num, movieCollection, memberCollection);
            }
            else { Console.WriteLine("Please enter a valid Number"); }

        }
        /* Menu Item Selections
         * Sub Menus
         */
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
                Do(mainMenuSelection, num, movieCollection, memberCollection);
            }
            else { Console.WriteLine("Please enter a valid Number"); }
        }
        /* Menu Do action
         */
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
                            // TODO: needs more work
                            while (repeatMenu == true)
                            {
                                movieCollection.addMovie();
                                Console.WriteLine("----------------------------");



                            }
                            break;
                        case 2: // Remove a movie DVD
                            movieCollection.TestMovies();
                            movieCollection.removeMovie();
                            Console.WriteLine("----------------------------");
                            
                            Console.WriteLine("Please Make a selection (1, or 0 to return to main menu):");
                            break;
                        case 3: // Add a new member

                            memberCollection.register();
                            //memberCollection.printAllMembersInfo();

                            // add some testing code to see if member was created successfully

                            break;
                        case 4:
                            Console.WriteLine("Staff Menu Option 4");
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
                        case 1: // Add what to do
                            Console.WriteLine("Current Movies:");
                            movieCollection.TestMovies();
                            movieCollection.displayAllMovies();
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
       
        /* Staff Login Page
         */
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
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Login failed. Please try again.");
                    succesful = false;
                }
            }
        }

        /* Member Login Page
         */
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

        /* Testing code 
         * Build  Add movies and members
         */
        public static void TestCode()
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


            newMovie1.create("Star Wars Episode IV: A New Hope", "Harrison Ford", "George Lucas", "125", "Sci-Fi", "M", "1977");
            newMovie2.create("Star Wars Episode V: Empire Strikes Back", "Harrison Ford", "George Lucas", "127", "Sci-Fi", "M", "1980");
            newMovie3.create("Star Wars Episode VI: Return of the Jedi", "Harrison Ford", "George Lucas", "136", "Sci-Fi", "M", "1983");
            newMovie4.create("Star Wars Episode I: The Phantom Menace", "Ewan McGreggor", "George Lucas", "133", "Sci-Fi", "M", "1999");
            newMovie5.create("Star Wars Episode II: Attack of the Clones", "Ewan McGreggor", "George Lucas", "142", "Sci-Fi", "M", "2002");
            newMovie6.create("Star Wars Episode III: Revenge of the Sith", "Ewan McGreggor", "George Lucas", "140", "Sci-Fi", "M", "2005");
            newMovie7.create("Star Wars Episode VII: The Force Awakens", "Daisy Ridley", "J.J. Abrams", "135", "Sci-Fi", "M", "2015");
            newMovie8.create("Star Wars Episode VIII: The Last Jedi", "Daisy Ridley", "Rian Johnson", "152", "Sci-Fi", "M", "2017");
            newMovie9.create("Star Wars Episode IX: The Rise of Skywalker", "Daisy Ridley", "J.J. Abrams", "142", "Sci-Fi", "M", "2019");

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
            Console.WriteLine("In Order: ");
            movieList.InOrderTraversal();
            Console.WriteLine("Pre Order: ");
            movieList.PreOrderTraversal();

            // Test Deletion
            Console.WriteLine("Delete Movie Test: ");
            movieList.Remove(newMovie7);
            movieList.Remove(newMovie4);
            movieList.Remove(newMovie5);
            movieList.Remove(newMovie6);
            movieList.Remove(newMovie7);
            movieList.PreOrderTraversal();

            Console.WriteLine("The current Height of the tree is: " + movieList.Height());

            Console.WriteLine("Enter Movie Name: ");
            Movie chosen = new Movie();
            chosen = movieList.FindMovie(Console.ReadLine());

            Console.WriteLine("The Chosen Movie is: " );


        }
    }

}
