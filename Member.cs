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

        //
        public void register(string firstName, string lastName, string homeAddress, int phoneNumber, int password) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.homeAddress = homeAddress;
            this.phoneNumber = phoneNumber;
            this.username = firstName + lastName;
            this.password = password;
        }      

        public string getName()
        {
            return firstName + lastName;
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

    }
}
