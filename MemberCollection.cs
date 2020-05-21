using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAB301
{
    class MemberCollection
    {
        private Member[] memberCollection = new Member[1];
        private int size = 0;


        /* Registers a new member and adds it to the current array
         */
        public void register()
        {
            // Create new member object
            Member newMember = new Member();

            // Get user input

            string firstName;
            string lastName;
            string homeAddress;
            int phoneNumber;
            int password;

            // Testing Code
            //Console.WriteLine("Array Size: " + memberCollection.Length);

            Console.WriteLine("---------Add Member---------");
            Console.Write("First Name: "); firstName = Console.ReadLine();
            Console.Write("Last Name: "); lastName = Console.ReadLine();
            Console.Write("Home Address: "); homeAddress = Console.ReadLine();
            Console.Write("Phone Number: "); phoneNumber = int.Parse(Console.ReadLine());
            Console.Write("Password (4 Digit number): "); password = int.Parse(Console.ReadLine());

            newMember.register(firstName, lastName, homeAddress, phoneNumber, password);
            memberCollection[size] = newMember;
            size += 1;
            Array.Resize<Member>(ref memberCollection, memberCollection.Length + 1);
            newMember.printinfo();
            // Testing code
            //Console.WriteLine("Array Size: " + memberCollection.Length);
        }

        /*
         * Finds the registered members phone number
         * Required*
         */
        public void contactNum(Member member)
        {
            member.getNumber();

        }

        /* 
         * Prints all the current stored members info
         * Testing only -- broken
         */

        public void printAllMembersInfo()
        {
            foreach (Member m in memberCollection)
            {
                m.printinfo();
            }
        }


    }
}
