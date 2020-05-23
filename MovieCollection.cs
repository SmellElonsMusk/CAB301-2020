using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /* TreeNode Class
    * 
    */
    class TreeNode
    {
        private Movie data;
        private TreeNode rightNode;
        private TreeNode leftNode;

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
            if (String.CompareOrdinal(movie.getTitle(), data.getTitle()) <= 0)
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
        public void TraverseInOrder()
        {
            if (leftNode != null)
            {
                leftNode.TraverseInOrder();

            }

            if (rightNode != null)
            {
                rightNode.TraverseInOrder();
            }

            Console.WriteLine(data.ToString());
        }

        /* Searches Tree
         * Root->Left->Right Nodes recursively of each subtree 
         */
        public void PreOrderTraversal()
        {
            Console.WriteLine(data.ToString());

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
            Console.WriteLine(data);
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

        /* Find a movie in the array based on title
         */
        public Movie FindMovie(String title)
        {
            if (root.Data().getTitle() == title)
            {
                return root.Data();
            }
            else
            {
                return null;
            }

        } // Needs To be fixed

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
                root.TraverseInOrder();
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


        public void addMovie()
        {
            // Input Paramaters
            String param1, param2, param3, param4, param5, param6, param7;

            Console.WriteLine("----------Add DVD-----------");
            Console.Write("Title:"); param1 = Console.ReadLine();
            Console.Write("Starring:"); param2 = Console.ReadLine();
            Console.Write("Director:"); param3 = Console.ReadLine();
            Console.Write("Duration:"); param4 = Console.ReadLine();
            Console.Write("Genre:"); param5 = Console.ReadLine();
            Console.Write("Classification:"); param6 = Console.ReadLine();
            Console.Write("Release Date:"); param7 = Console.ReadLine();
            Movie newMovie = new Movie();
            newMovie.create(param1, param2, param3, param4, param5, param6, param7);
            //this.movieCollection.Add(newMovie);

            binaryTree.Add(newMovie);

            binaryTree.Find(newMovie).PrintInfo();


            // testing Code
            //Console.WriteLine("The Movie has been created: " + this.movieCollection.ToString());

        }

        public void removeMovie()
        {
            Console.WriteLine("--------Remove DVD----------");
            
            // TODO: Display List of Movie Names to remove
            binaryTree.PostOrderTraversal();
            //binaryTree.PreOrderTraversal();

            Console.WriteLine("Enter the Movie Title: ");
            string input = Console.ReadLine();
            if (binaryTree.FindMovie(input).getTitle() == input)
            {
                Movie movie = new Movie();
                movie = (binaryTree.FindMovie(input));
                binaryTree.Remove(movie);
            }

            //Movie thisMovie = new Movie();
            //binaryTree.Remove(thisMovie);  // Deletes the movie
        } // Needs to be fixed

        public void displayAllMovies()
        {
            binaryTree.PostOrderTraversal();
        }

        public void listTopTen()
        {

        }

        // Adds 30 Movies to the List
        public void TestMovies()
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

            newMovie1.create("Star Wars Episode IV: A New Hope", "Harrison Ford", "George Lucas", "125", "Sci-Fi", "M", "1977");
            newMovie2.create("Star Wars Episode V: Empire Strikes Back", "Harrison Ford", "George Lucas", "127", "Sci-Fi", "M", "1980");
            newMovie3.create("Star Wars Episode VI: Return of the Jedi", "Harrison Ford", "George Lucas", "136", "Sci-Fi", "M", "1983");
            newMovie4.create("Star Wars Episode I: The Phantom Menace", "Ewan McGreggor", "George Lucas", "133", "Sci-Fi", "M", "1999");
            newMovie5.create("Star Wars Episode II: Attack of the Clones", "Ewan McGreggor", "George Lucas", "142", "Sci-Fi", "M", "2002");
            newMovie6.create("Star Wars Episode III: Revenge of the Sith", "Ewan McGreggor", "George Lucas", "140", "Sci-Fi", "M", "2005");
            newMovie7.create("Star Wars Episode VII: The Force Awakens", "Daisy Ridley", "J.J. Abrams", "135", "Sci-Fi", "M", "2015");
            newMovie8.create("Star Wars Episode VIII: The Last Jedi", "Daisy Ridley", "Rian Johnson", "152", "Sci-Fi", "M", "2017");
            newMovie9.create("Star Wars Episode IX: The Rise of Skywalker", "Daisy Ridley", "J.J. Abrams", "142", "Sci-Fi", "M", "2019");


            binaryTree.Add(newMovie1);
            binaryTree.Add(newMovie2);
            binaryTree.Add(newMovie3);
            binaryTree.Add(newMovie4);
            binaryTree.Add(newMovie5);
            binaryTree.Add(newMovie6);
            binaryTree.Add(newMovie7);
            binaryTree.Add(newMovie8);
            binaryTree.Add(newMovie9);

        }
    }
}

