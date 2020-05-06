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

        //
        public void register(string firstName, string lastName, string homeAddress, int phoneNumber) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.homeAddress = homeAddress;
            this.phoneNumber = phoneNumber;
        }      

        public string getName()
        {
            return firstName;
        }

        public int getNumber()
        {
            return phoneNumber;
        }

    }
}
