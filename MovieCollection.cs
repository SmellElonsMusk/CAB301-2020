using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    // This entire class needs to be written as a binary search tree
    class MovieCollection
    {
        private List<Movie> movieCollection;

        public void createCollection()
        {
            movieCollection = new List<Movie>();
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
            this.movieCollection.Add(newMovie);

           

            // testing Code
            Console.WriteLine("The Movie has been created: " + this.movieCollection.ToString());
            
        }

        public void removeMovie()
        {
            Console.WriteLine("--------Remove DVD----------");
        }
    }
}
