using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /* Enum for Red/Black Tree
     */
    enum Colour
    {
        Red,
        Black
    }

    /* TreeNode Class
    * 
    */
    class TreeNode
    {
        private Movie data;
        private TreeNode rightNode;
        private TreeNode leftNode;

        private TreeNode parentNode;
        public Colour colour;

        public Movie Data()
        {
            return data;
        }

        /* Adds the data to the Node
         */
        public TreeNode(Movie movie)
        {
            this.data = movie;
        }

        /* Assigns TreeNode Colour
         */
        public TreeNode(Colour colour)
        {
            this.colour = colour;
        } // Red/black

        /* Assigns TreeNode Colour & Movie
         */
        public TreeNode(Colour colour, Movie movie)
        {
            this.colour = colour;
            this.data = movie;
        } // Red Black

        /* Right Child Node
         */
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        /* Left Child Node
        */
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        /* Rotate Node Left
         */ // unfinished -> autoballance tree
        public void leftRotate(TreeNode node)
        {
            TreeNode otherNode = node.rightNode; // Set TreeNode
            node.rightNode = otherNode.leftNode; // swap the left and right sides
        }

        /* Rotate Node Right
         */ // unfinished -> autoballance tree
        public void rotateRight(TreeNode node)
        {

        }

        /* Adds new node down the tree when it finds an empty spot
         * 
         * == 0 : The same title.
         * > 0  : First title preeceeds second.
         * < )  : First title comes After first.
         * 
         */
        public void Add(Movie movie)
        {
            // If the new movies title comes after the current title -> insert to the right node
            if (String.CompareOrdinal(movie.getTitle(), data.getTitle()) >= 0)
            {

                if (rightNode == null)
                {
                    rightNode = new TreeNode(movie); // If the right node exists -> repeat the loop 
                }
                else // If Right Node Exists
                {
                    rightNode.Add(movie);
                }

            }
            else // If the new movies title comes before the current title -> insert to the left node
            {
                if (leftNode == null) // If Node does not exist, create
                {
                    leftNode = new TreeNode(movie);
                }
                else // If Left Node Exists
                {
                    leftNode.Add(movie); // If the left node exists -> repeat the loop
                }
            }
        }

        /* Finds the node storing the data
         * 
         * 
         */
        public TreeNode Find(Movie movie)
        {
            TreeNode currentNode = this;

            while (currentNode != null)
            {
                if (movie == currentNode.data) // If the title matches the current Node
                {
                    return currentNode;
                }
                else if (String.CompareOrdinal(movie.getTitle(), currentNode.data.getTitle()) > 0) // If the Title appears after current
                {
                    currentNode = currentNode.rightNode;
                }
                else // If the Title appears before current 
                {
                    currentNode = currentNode.leftNode;
                }


            }
            return null; // if the node does not exist

        }

        /* Finds the node storing the movie
         * 
         * 
         */
        public TreeNode FindMovie1(string title)
        {
            TreeNode currentNode = this;

            while (currentNode != null)
            {
                if (currentNode.data.getTitle() == title) // If the title matches the current Node
                {
                    return this;
                }
                else if (String.CompareOrdinal(title, currentNode.data.getTitle()) > 0) // If the Title appears after current
                {
                    currentNode = currentNode.rightNode;
                }
                else // If the Title appears before current 
                {
                    currentNode = currentNode.leftNode;
                }


            }
            return null; // if the node does not exist

        } // doesn't work

        public TreeNode Search(string title, TreeNode node)
        {
            if (node != null)
            {
                if (node.data.getTitle().Equals(title))
                {
                    return node;
                }
                else
                {
                    TreeNode nextNode = Search(title, node.leftNode); // Goes to the left node of current
                    if (nextNode == null)
                    {
                        nextNode = Search(title, node.rightNode); // Goes to the right node of current
                    }
                    return nextNode;
                }
            }
            else
            {
                return null;
            }

        }



        /* Checks the height of the current tree -- Needs to be re written a bit
         * -> Number of levels 
         */
        public int Height()
        {
            //return 1 when leaf node is found
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1; //found a leaf node
            }

            int left = 0;
            int right = 0;

            //recursively go through each branch
            if (this.leftNode != null)
                left = this.leftNode.Height();
            if (this.rightNode != null)
                right = this.rightNode.Height();

            //return the greater height of the branch
            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }

        }

        /* Searches the Tree In Order
         * Left->Root->Right Nodes recursively of each subtree 
         * Sorted Alphabetically
         */
        public void InOrderTraverse()
        {
            if (leftNode != null)
            {
                leftNode.InOrderTraverse();

            }
            Console.WriteLine(data.getTitle());
            if (rightNode != null)
            {
                rightNode.InOrderTraverse();
            }


        }

        /* Searches Tree
         * Root->Left->Right Nodes recursively of each subtree 
         */
        public void PreOrderTraversal()
        {
            Console.WriteLine(data);

            if (leftNode != null)
            {
                leftNode.PreOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PreOrderTraversal();
            }
        }

        /* Searches the tree 
         *  left -> right-> root
         */
        public void PostOrderTraversal()
        {
            if (leftNode != null)
            {
                leftNode.PostOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PostOrderTraversal();
            }

            Console.WriteLine(data.getTitle());


        }

        /* Prints the movie info to the screen
         */
        public void PrintInfo()
        {
            Console.WriteLine(data.ToString());
        }
    }

    /* Binary Search Tree Main Class
     */
    class BinarySearchTree
    {
        private TreeNode root;

        /* Create the root Node
         * 
         */
        public TreeNode Root
        {
            get { return root; }
        }

        /* Find the desireed Node
         * 
         */
        public TreeNode Find(Movie movie)
        {
            if (root != null)
            {
                return root.Find(movie);
            }
            else
            {
                return null;
            }
        }

        /* Find the desired Movie based on title
         * 
         */
        public TreeNode FindMovie(string title)
        {
            if (root != null)
            {

                return root.Search(title, root);


            }
            else
            {
                return null;
            }
        }

        /* Adds a new Node
         */
        public void Add(Movie movie)
        {
            if (root != null) // adds new movie to tree
            {
                root.Add(movie);
            }
            else // Creates new root and adds moive as root
            {
                root = new TreeNode(movie);
            }
        }

        /* Removes the selected node and adjusts the tree
         * 
         * 
         */
        public void Remove(Movie movie)
        {
            TreeNode thisNode = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            // Test to see if tree is Empty
            if (thisNode == null)
            {
                return; // Nothing to delete
            }
            // Find the node where the movie is stored
            // Keeps Looping until it is fond
            while (thisNode != null && thisNode.Data() != movie)
            {
                parent = thisNode;

                // Title comes before -> check the left child node
                if (String.Compare(movie.getTitle(), thisNode.Data().getTitle()) > 0)
                {
                    thisNode = thisNode.LeftNode;
                    isLeftChild = true;
                }
                else // Title comes after -> check the right child node
                {
                    thisNode = thisNode.RightNode;
                    isLeftChild = false;
                }
            }

            if (thisNode == null) // Return if not found
            {
                return;
            }

            // The node is a leaf node -> no children
            if (thisNode.RightNode == null && thisNode.LeftNode == null)
            {
                if (thisNode == null)
                {
                    root = null; // Deletes the data
                }
                else // The node is a child -> deletes child node
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = null; // Deletes data
                    }
                    else
                    {
                        parent.RightNode = null; // Deletes data
                    }
                }

            }
            else if (thisNode.RightNode == null) // Current node only has a left child
            {
                if (thisNode == root)
                {
                    root = thisNode.LeftNode;
                }
                else
                {
                    // Checks which child node it is
                    if (isLeftChild)
                    {
                        parent.LeftNode = thisNode.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = thisNode.RightNode;
                    }
                }

            }
            else if (thisNode.LeftNode == null) // Current node only has a right child
            {
                if (thisNode == root)
                {
                    root = thisNode.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = thisNode.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = thisNode.RightNode;
                    }
                }
            }
            else // Current node has both left and right child
            {
                TreeNode succesor = GetSuccesor(thisNode);

                if (thisNode == root)
                {
                    root = succesor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = succesor;
                }
                else
                {
                    parent.RightNode = succesor;
                }

            }


        }

        /* Gets the succesor of the current treenode
         */
        private TreeNode GetSuccesor(TreeNode node)
        {
            TreeNode parent = node;
            TreeNode succesor = node;
            TreeNode thisNode = node.RightNode;

            while (thisNode != null)
            {
                parent = succesor;
                succesor = thisNode;
                thisNode = thisNode.LeftNode;
            }

            if (succesor != node.RightNode)
            {
                parent.LeftNode = succesor.RightNode;
                succesor.RightNode = node.RightNode;
            }
            succesor.LeftNode = node.LeftNode;

            return succesor;
        }

        /* Returns the height of the tree
         */
        public int Height()
        {
            if (root == null)
            {
                return 0;
            }

            return root.Height();
        }

        /* Traverse the tree in order of nodes
         */
        public void InOrderTraversal()
        {
            if (root != null)
            {
                root.InOrderTraverse();
            }
        }

        /* Traverse the tree in order Root->left->right
         */
        public void PreOrderTraversal()
        {
            if (root != null)
            {
                root.PreOrderTraversal();
            }
        }

        /* Searches the tree 
         *  left -> right-> root
         */
        public void PostOrderTraversal()
        {
            if (root != null)
            {
                root.PostOrderTraversal();
            }
        }
    }

    /* Main Movie Collection class -> Stores and sorts movies
     * 
     * 
     */
    class MovieCollection
    {
        BinarySearchTree binaryTree = new BinarySearchTree();

        /* Adds Movie to BST and checks if  it already exists
         */
        public void addMovie() // Finished 
        {
            // Input Paramaters
            string param1, param2, param3, param4, param7;
            int param5, param6, param8;

            Console.WriteLine("----------Add DVD-----------");
            Console.Write("Enter Title:"); param1 = Console.ReadLine();

            // Checks if the current title already exists
            string title = "";
            try // attempts to find title
            {
                title = binaryTree.FindMovie(param1).Data().getTitle();
            }
            catch (NullReferenceException )  // if the result is null, exception is thrown and caught
            {
                // Does nothing
            }

            // If the title exists, add more copies
            if (title == param1)
            {
                Console.Write("Enter the Number of Copies:"); param8 = Int32.Parse(Console.ReadLine());

                binaryTree.FindMovie(param1).Data().AddCopies(param8);


            }
            else // Continue adding more params
            {
                Console.Write("Enter the Starring Actor(s):"); param2 = Console.ReadLine();
                Console.Write("Enter the Director(s):"); param3 = Console.ReadLine();
                Console.Write("Enter the Duration(mins):"); param4 = Console.ReadLine();

                // Select a Genre from the Enum List
                Console.WriteLine("Select the Genre:");
                int num = 1;
                foreach (string str in Enum.GetNames(typeof(Genre)))
                {

                    Console.WriteLine(num + ". " + str);
                    num += 1;
                }

                // Checks if the selection is a valid int
                bool isNum = Int32.TryParse(Console.ReadLine(), out param5);

                // Checks if input is a number
                while (!isNum)
                {
                    Console.WriteLine("Please enter a vailid number: ");
                    param5 = Int32.Parse(Console.ReadLine());

                    if (param5 < Enum.GetNames(typeof(Genre)).Length) // checks if the value is within range
                    {
                        isNum = true;
                    }
                }

                // Assigns Genre
                Genre thisGenre = Genre.Other;
                int sel = 0;
                foreach (Genre genre in Enum.GetValues(typeof(Genre)))
                {

                    sel += 1;

                    if (sel == param5)
                    {

                        thisGenre = genre;



                    }
                }


                // Select a Classification from the Enum List
                Console.WriteLine("Select the Classification:");
                num = 1;
                foreach (string str in Enum.GetNames(typeof(Classification)))
                {
                    Console.WriteLine(num + ". " + str);
                    num += 1;
                }

                // Checks if the selection is a valid int
                isNum = Int32.TryParse(Console.ReadLine(), out param6);

                // Checks if input is a number
                while (!isNum)
                {
                    Console.WriteLine("Please enter a vailid number: ");
                    param6 = Int32.Parse(Console.ReadLine());

                    if (param6 < Enum.GetNames(typeof(Classification)).Length) // checks if the value is within range
                    {
                        isNum = true;
                    }
                }

                // Assigns Classification
                Classification thisClassification = Classification.G;
                int sel2 = 0;
                foreach (Classification classification in Enum.GetValues(typeof(Classification)))
                {

                    sel2 += 1;

                    if (sel2 == param5)
                    {
                        thisClassification = classification;
                    }
                }

                // Adds String Params
                Console.Write("Enter the Release Date:"); param7 = Console.ReadLine();
                Console.Write("Enter the Number of Copies:"); param8 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------");

                // Creates new movie and adds to BST
                Movie newMovie = new Movie();
                newMovie.create(param1, param2, param3, param4, thisGenre, thisClassification, param7, param8);
                binaryTree.Add(newMovie);
            }
        }

        /* Removes Movie from BST by title
         */
        public void removeMovie() // Finished 
        {
            Console.WriteLine("--------Remove DVD----------");

            // Lists Current Movies
            binaryTree.InOrderTraversal();
            Console.WriteLine("----------------------------");
            // Gets user input for title
            Console.WriteLine("Enter the Movie Title: ");
            string input = Console.ReadLine();

            // Checks if the title exists
            bool success = false;
            while (!success)
            {
                try
                {
                    binaryTree.FindMovie(input).Data();
                    success = true;
                }
                catch (NullReferenceException ) // Title not found. Repeats the process
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("The Movie: " + input + " does not exist.");
                    Console.Write("Please enter a valid title: ");
                    input = Console.ReadLine();
                }
            }

            // Once the movie is found, deletes the movie
            Console.WriteLine("The Movie: " + binaryTree.FindMovie(input).Data().getTitle() + " has been deleted.");
            Console.WriteLine("----------------------------");
            binaryTree.Remove(binaryTree.FindMovie(input).Data());
            
        }

        public Movie findMovie(string title)
        {
            try
            {
                return binaryTree.FindMovie(title).Data();
            } catch (NullReferenceException )
            {
                // do nothing
            }
            return null;
        }

        /* Prints all current Movie Titles to the Console
         */
        public void displayAllMovies() // Finished 
        {
            binaryTree.InOrderTraversal();
        }

        /* Lists Top 10 Most Rented Movies
         */
        public void listTopTen() // NOT finsihed -> Needs to be implmented 
        {


        } 

        /* Adds 15 Movies to the List
         */
        public void AddMovies() // Finished 
        {

            // Creates movie objects
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
            Movie newMovie11 = new Movie();
            Movie newMovie12 = new Movie();
            Movie newMovie13 = new Movie();
            Movie newMovie14 = new Movie();
            Movie newMovie15 = new Movie();

            // Adds details to movie objects
            newMovie1.create("Star Wars Episode IV: A New Hope", "Harrison Ford", "George Lucas", "125", Genre.SciFi, Classification.M, "1977", 2);
            newMovie2.create("Star Wars Episode V: Empire Strikes Back", "Harrison Ford", "George Lucas", "127", Genre.SciFi, Classification.M, "1980", 3);
            newMovie3.create("Star Wars Episode VI: Return of the Jedi", "Harrison Ford", "George Lucas", "136", Genre.SciFi, Classification.M, "1983", 5);
            newMovie4.create("Star Wars Episode I: The Phantom Menace", "Ewan McGreggor", "George Lucas", "133", Genre.SciFi, Classification.M, "1999", 2);
            newMovie5.create("Star Wars Episode II: Attack of the Clones", "Ewan McGreggor", "George Lucas", "142", Genre.SciFi, Classification.M, "2002", 1);
            newMovie6.create("Star Wars Episode III: Revenge of the Sith", "Ewan McGreggor", "George Lucas", "140", Genre.SciFi, Classification.M, "2005", 4);
            newMovie7.create("Star Wars Episode VII: The Force Awakens", "Daisy Ridley", "J.J. Abrams", "135", Genre.SciFi, Classification.M, "2015", 2);
            newMovie8.create("Star Wars Episode VIII: The Last Jedi", "Daisy Ridley", "Rian Johnson", "152", Genre.SciFi, Classification.M, "2017", 2);
            newMovie9.create("Star Wars Episode IX: The Rise of Skywalker", "Daisy Ridley", "J.J. Abrams", "142", Genre.SciFi, Classification.M, "2019", 1);
            newMovie10.create("Iron Man", "Robert Downey Jr.", "Jon Favereau", "126", Genre.Action, Classification.M, "2008", 4);
            newMovie11.create("Thor: Ragnarok", "Chris Hemsworth", "Taika Waititi", "130", Genre.Action, Classification.M, "2017", 2);
            newMovie12.create("Avengers", "Chris Hemsworth", "Joss Whedon", "142", Genre.Action, Classification.M, "2012", 4);
            newMovie13.create("Avengers: Age of Ultron", "Chris Evans, Robert Downey J.r", "Joss Whedon", "141", Genre.Action, Classification.M, "2015", 2);
            newMovie14.create("Avengers: Infinity War", "Chris Hemsworth, Robert Downey J.r", "Joe Russo, Anthoiny Russo", "149", Genre.Action, Classification.M, "2018", 3);
            newMovie15.create("Avegers: End Game", "Chris Hemsworth, Robert Downey J.r", "Joe Russo, Anthoiny Russo", "181", Genre.Action, Classification.M, "", 2);

            // Adds movies to the BSS
            binaryTree.Add(newMovie1);
            binaryTree.Add(newMovie2);
            binaryTree.Add(newMovie3);
            binaryTree.Add(newMovie4);
            binaryTree.Add(newMovie5);
            binaryTree.Add(newMovie6);
            binaryTree.Add(newMovie7);
            binaryTree.Add(newMovie8);
            binaryTree.Add(newMovie9);
            binaryTree.Add(newMovie10);
            binaryTree.Add(newMovie11);
            binaryTree.Add(newMovie12);
            binaryTree.Add(newMovie13);
            binaryTree.Add(newMovie14);
            binaryTree.Add(newMovie15);

        } 

    }
}

