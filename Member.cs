using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CAB301
{
    class Member
    {
        // Member Data
        private string firstName;
        private string lastName;
        private string homeAddress;
        private int phoneNumber;
        private string username;
        private int password;

        private Movie[] moviesBorrowed;
        private int numMovies;

        // Creates Member
        public void register(string firstName, string lastName, string homeAddress, int phoneNumber, int password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.homeAddress = homeAddress;
            this.phoneNumber = phoneNumber;
            this.username = lastName + firstName;
            this.password = password;
            this.numMovies = 0;
            this.moviesBorrowed = new Movie[1];
        }

        public string getName()
        {
            return firstName + lastName;
        }
         
        public string getFirst()
        {
            return firstName;
        }

        public string getLast()
        {
            return lastName;
        }

        public int getNumber()
        {
            return phoneNumber;
        }

        public string getAddress()
        {
            return homeAddress;
        }

        public int getPhoneNumber()
        {
            return phoneNumber;
        }

        public string getUsername()
        {
            return username;
        }

        public int getPassword()
        {
            return password;
        }

        public void borrowMovie(Movie movie) // Finished
        {

            this.moviesBorrowed[numMovies] = movie;
            Array.Resize<Movie>(ref moviesBorrowed, moviesBorrowed.Length + 1);
            numMovies = +1;
        }

        public void ReturnMovie(Movie movie) // 
        {
            int i = 0;
            for ( i = 0;  i < moviesBorrowed.Length; i++)
            {
                try
                {
                    if (movie.getTitle() == moviesBorrowed[i].getTitle())
                    {
                        moviesBorrowed[i] = null;

                    }
                }
                catch
                {

                }
                
            }
            i++;
            
        }

        public void currentlyHeld() // needs work
        {
            if (moviesBorrowed.Length == 1)
            {
                Console.WriteLine("This user currently has no borrowed Movies");
            }
            else
            {
               

                foreach (Movie movie in moviesBorrowed)
                {

                    if (movie == null)
                    {

                    }
                    else movie.PrintInfo();                   
                    
                }
            }

        }



        public void printinfo()
        {
            Console.WriteLine("The following user was created:");
            Console.WriteLine("Name     : " + firstName);
            Console.WriteLine("Lastname : " + lastName);
            Console.WriteLine("Username : " + username);
            Console.WriteLine("Password : " + password);
            Console.WriteLine("");

        }
    }
}
