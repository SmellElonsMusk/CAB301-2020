using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

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
        Movie[] movies;
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

        /* Searchs the tree for the node that contains the title
         * 
         */
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
            data.PrintInfo();
            if (rightNode != null)
            {
                rightNode.InOrderTraverse();
            }


        }

        public Movie ReturnMovie()
        {
            if (leftNode != null)
            {
                leftNode.ReturnMovie();

            }

            if (leftNode != null)
            {
                return data;
            }


            if (rightNode != null)
            {
                rightNode.ReturnMovie();

            }

            return null;
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

        /* Searches the Tree In Order
         * Left->Root->Right Nodes recursively of each subtree 
         * Sorted Alphabetically
         */
        public Movie MovieInOrderTraverse()
        {
            if (leftNode != null)
            {
                leftNode.MovieInOrderTraverse();

            }
            if (this != null)
            {
                return data;
            }
            
            if (rightNode != null)
            {
                rightNode.MovieInOrderTraverse();
            }
            return null; // if the traversal fails

        }





        /* Searches the tree sequentially and returns each node
         *  left -> root -> right
         */
        //public TreeNode TopTen()
        //{
        //    if (leftNode != null)
        //    {
        //        leftNode.InOrderTraverse();

        //    }
        //    else if (this != null)
        //    {
        //        return this;
        //    }

        //    else if (rightNode != null)
        //    {
        //        rightNode.InOrderTraverse();
        //    }

        //    return null; // if no more node's are found return null
        //} // doesnt work


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
         * left -> root -> right
         */
        public void InOrderTraversal()
        {
            if (root != null)
            {
                root.InOrderTraverse();
            }
        }

        public Movie MovieInOrderTraversal()
        {
            if (root != null)
            {
                //root.MovieInOrderTraverse();
                return root.Data();
            }

            return null; // if it fails
        }

        public Movie[] test()
        {
            int size = count(root);
            Movie[] movies = new Movie[size];
            int num = 0;

            while (num != size)
            {
                movies[num] = root.MovieInOrderTraverse();
                num += 1;

            }
            return movies;
        }



        /* Leaf count helper function 
         */
        public virtual int LeafCount
        {
            get
            {
                return getLeafCount(root);
            }


        }

        /* Counts the number of Leaf Nodes
         * 
         */
        public virtual int getLeafCount(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            } if (node.LeftNode == null && node.RightNode == null)
            {
                return 1;

            } else
            {
                return getLeafCount(node.LeftNode) + getLeafCount(node.RightNode);
            }
        }

        /* Counts the number of nodes in the BST
         */
        public int count(TreeNode node)
        {
            int c = 1;
            if (node == null)
            {
                return 0;
            }
            else
            {
                c += count(node.LeftNode);
                c += count(node.RightNode);
            }
            return c;
        }

        public void PreOrder(TreeNode node, Movie[] movies, int num)
        {
            
            if (node == null)
            {
                movies[num] = node.Data();
                num += 1;
            }
            PreOrder(root.LeftNode, movies, num);
            PreOrder(root.RightNode, movies, num);

            
        }

        // Bst to array

        public Movie[] toBSTArray()
        {

            int size = count(root);//; // Finds the # of nodes in the tree
            int num = 0;
            Movie[] movies = new Movie[size];

            while ( num <= size)
            {
                PreOrder(root, movies, num);
            }
            

            //MakeArray(root, 0, movies);
            return movies;
        }

        // Helper function
        public void MakeArray(TreeNode node, int i, Movie[] movies)
        {

            

            /* 
             * https://stackoverflow.com/questions/13870118/converting-bst-to-array
             * 
             */

            //if (node != null)
            //{
            //    movies[i] = root.Data(); // Assigns the Node data to the array
            //    i += 1;
            //    MakeArray(node.LeftNode, i, movies);
            //    MakeArray(node.RightNode, i, movies);

            //}

            //if (root.LeftNode != null)
            //{
            //    movies[i] = root.Data();
            //    i += 1;
            //    MakeArray(node.RightNode, i, movies);
            //}

            //if (root.RightNode != null)
            //{
            //    movies[i] = root.Data();
            //    i += 1;
            //    MakeArray(node.LeftNode, i, movies);
            //}


           
        }

        /* Traverse the tree in order 
         * Root->left->right
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

        /* Searches the tree for the top remted movie
         *  left -> root -> right
         */ // does nothing
        public void TopTen()
        {
            // Algorithm that finds max rented
            int MaxCount = 12; // needs to be added
            // Algorithm that searches based on the max

            //root.Search(MaxCount);
        }


        //public Movie [] preOrder (TreeNode node)
        //{
        //    //Movie[] movies = new Movies[]
        //    //if (root != null)
        //    //{
        //    //    return root
        //    //}
        //}





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
            catch (NullReferenceException)  // if the result is null, exception is thrown and caught
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
                catch (NullReferenceException) // Title not found. Repeats the process
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
            }
            catch (NullReferenceException)
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

        /*
         *  https://www.tutorialspoint.com/chash-program-to-perform-quick-sort-using-recursion
         * 
         */
        static public int Partition(Movie[] movies, int left, int right)
        {
            int pivot = movies[left].BorrowedCount(); // Creates a pivot point
            while (true)
            {
                while (movies[left].BorrowedCount() < pivot) // If the movies to the left of th
                {
                    left++;
                }
                while (movies[right].BorrowedCount() > pivot) //  
                {
                    right++;
                }
                if (left < right) //  
                {
                    Movie temp = movies[right]; // Creates a temp movie array
                    movies[right] = movies[left]; // shifts the movies around
                    movies[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public void QuickSort(Movie[] movies, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(movies, left, right);
                if (pivot > 1)
                {
                    QuickSort(movies, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(movies, pivot + 1, right);
                }
            }


        }

        public void TopTen()
        {
            //Movie[] TopTen = binaryTree.toBSTArray(); // Converts the Entire BST to an Array
            Movie[] TopTen = binaryTree.test(); // Converts the Entire BST to an Array
            int len = TopTen.Length; //TopTen.Length;

            //try
            //{
            //    QuickSort(TopTen, 0, len - 1);
            //}
            //catch
            //{

            // }


            for (int i = 0; i <= 10-1; i++)
            {
                try
                {

                    Console.WriteLine(TopTen[i].getTitle() + " Borrowed Count: " + TopTen[i].BorrowedCount());
                }
                catch
                {

                }

            }



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
            newMovie1.create("Star Wars Episode IV: A New Hope", "Harrison Ford", "George Lucas", "125", Genre.SciFi, Classification.M, "1977", 5);
            newMovie2.create("Star Wars Episode V: Empire Strikes Back", "Harrison Ford", "George Lucas", "127", Genre.SciFi, Classification.M, "1980", 3);
            newMovie3.create("Star Wars Episode VI: Return of the Jedi", "Harrison Ford", "George Lucas", "136", Genre.SciFi, Classification.M, "1983", 5);
            newMovie4.create("Star Wars Episode I: The Phantom Menace", "Ewan McGreggor", "George Lucas", "133", Genre.SciFi, Classification.M, "1999", 2);
            newMovie5.create("Star Wars Episode II: Attack of the Clones", "Ewan McGreggor", "George Lucas", "142", Genre.SciFi, Classification.M, "2002", 10);
            newMovie6.create("Star Wars Episode III: Revenge of the Sith", "Ewan McGreggor", "George Lucas", "140", Genre.SciFi, Classification.M, "2005", 4);
            newMovie7.create("Star Wars Episode VII: The Force Awakens", "Daisy Ridley", "J.J. Abrams", "135", Genre.SciFi, Classification.M, "2015", 2);
            newMovie8.create("Star Wars Episode VIII: The Last Jedi", "Daisy Ridley", "Rian Johnson", "152", Genre.SciFi, Classification.M, "2017", 2);
            newMovie9.create("Star Wars Episode IX: The Rise of Skywalker", "Daisy Ridley", "J.J. Abrams", "142", Genre.SciFi, Classification.M, "2019", 1);
            newMovie10.create("Iron Man", "Robert Downey Jr.", "Jon Favereau", "126", Genre.Action, Classification.M, "2008", 4);
            newMovie11.create("Thor: Ragnarok", "Chris Hemsworth", "Taika Waititi", "130", Genre.Action, Classification.M, "2017", 2);
            newMovie12.create("Avengers", "Chris Hemsworth", "Joss Whedon", "142", Genre.Action, Classification.M, "2012", 4);
            newMovie13.create("Avengers: Age of Ultron", "Chris Evans, Robert Downey J.r", "Joss Whedon", "141", Genre.Action, Classification.M, "2015", 12);
            newMovie14.create("Avengers: Infinity War", "Chris Hemsworth, Robert Downey J.r", "Joe Russo, Anthoiny Russo", "149", Genre.Action, Classification.M, "2018", 11);
            newMovie15.create("Avengers: End Game", "Chris Hemsworth, Robert Downey J.r", "Joe Russo, Anthoiny Russo", "181", Genre.Action, Classification.M, "", 13);





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

            // Rents movies for Top 10 List -- testing
            for (int i = 0; i < 12; i++)
            {
                newMovie15.borrow();
            }

            for (int i = 0; i < 10; i++)
            {
                newMovie14.borrow();
            }

            for (int i = 0; i < 9; i++)
            {
                newMovie13.borrow();
            }

            for (int i = 0; i < 9; i++)
            {
                newMovie5.borrow();
            }


            //newMovie1.borrow();
            //newMovie2.borrow();
            //newMovie3.borrow();
            //newMovie4.borrow();
            //newMovie5.borrow();
            //newMovie6.borrow();
            //newMovie7.borrow();
            //newMovie8.borrow();
            //newMovie9.borrow();
            //newMovie10.borrow();
            //newMovie11.borrow();
            //newMovie12.borrow();
            //newMovie13.borrow();
            //newMovie14.borrow();
            //newMovie15.borrow();





        }

    }



}

