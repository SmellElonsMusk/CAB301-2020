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

        // Adds the data to the Node
        public TreeNode(Movie movie)
        {
            this.data = movie;
        }

        // Right Child Node
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        // Left Child Node
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }


        /*
         * Adds the node to an empty spot in the tree
         * 
         * == 0 : The same title.
         * > 0  : First title preeceeds second.
         * < )  : First title comes After first.
         * 
         */
        public void add(Movie movie)
        {
            if (String.Compare(movie.getTitle(), data.getTitle()) <= 0)
            {
                if (rightNode == null) // If Node does not exist, create
                {
                    rightNode = new TreeNode(movie);
                }
                else // If Right Node Exists
                {
                    rightNode.add(movie);
                }

            }
            else
            {
                if (leftNode == null) // If Node does not exist, create
                {
                    leftNode = new TreeNode(movie);
                }
                else // If Left Node Exists
                {
                    leftNode.add(movie);
                }
            }
        }

        /*
         * Finds the node storing the data
         * 
         */
        public TreeNode Find(Movie movie) // While loop - can be changed to recursive if statement
        {
            TreeNode currentNode = this;

            while (currentNode != null)
            {
                if (movie == currentNode.data) // If the title matches the current Node
                {
                    return currentNode;
                }
                else if (String.Compare(movie.getTitle(), currentNode.data.getTitle()) > 0) // If the Title appears after current
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

        public void PrintInfo()
        {
            Console.WriteLine(data.ToString());
        }




    }

    class BinarySearchTree
    {
        private TreeNode root;

        /*
         * Create the root Node
         */
        public TreeNode Root
        {
            get { return root; }
        }

        /*
         * Find the desireed Node
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

        public void add(Movie movie)
        {
            if (root != null) // adds new movie to tree
            {
                root.add(movie);
            }
            else // Creates new root and adds moive as root
            {
                root = new TreeNode(movie);
            }
        }

        public void InOrderTraversal()
        {
            if (root != null)
            {

            }
        }
    }


    // This entire class needs to be written as a binary search tree
    class MovieCollection
    {
        BinarySearchTree binaryTree = new BinarySearchTree();
        public void createCollection()
        {

        }

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
            newMovie.add(param1, param2, param3, param4, param5, param6, param7);
            //this.movieCollection.Add(newMovie);

            binaryTree.add(newMovie);

            binaryTree.Find(newMovie).PrintInfo();


            // testing Code
            //Console.WriteLine("The Movie has been created: " + this.movieCollection.ToString());

        }

        public void removeMovie()
        {
            Console.WriteLine("--------Remove DVD----------");
        }

        public void displayAllMovies()
        {
            
        }

        public void listTopTen()
        {

        }
    }

   
}
