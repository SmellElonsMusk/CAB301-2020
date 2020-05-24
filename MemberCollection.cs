using System;
using System.Collections;
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
         */ // Finsihed -> Works
        public void register()
        {
            // Create new member object
            Member newMember = new Member();

            string firstName;
            string lastName;
            string homeAddress;
            int phoneNumber;
            int password;

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

        }

        /* Finds the registered members phone number
         * 
         * Required*
         */ // Needs to be Fixed
        public void FindMember()
        {
            string firstName;
            string lastName;
            Console.WriteLine("--------Find Member---------");
            Console.Write("First Name: "); firstName = Console.ReadLine();
            Console.Write("Last Name: "); lastName = Console.ReadLine();
            Console.WriteLine("----------------------------");
            foreach (Member member in memberCollection)
            {
                if (member.getFirst() == firstName && member.getLast() == lastName)
                {
                    Console.Clear();
                    Console.WriteLine(firstName + " " + lastName + "'s phone number is: " + member.getNumber());
                    Console.WriteLine("----------------------------");
                    break;
                }
            }
        }

        /*  Prints all the current stored members info
         * 
         * Testing only -- broken
         */
        public void printAllMembersInfo()
        {
            foreach (Member m in memberCollection)
            {
                m.printinfo();
            }
        }


        public void registerTest()
        {
            // Loops Through as members are registered

            Member newMember1 = new Member();
            newMember1.register("Ella", "Truelove", "10 Silver St", 0415123094, 1234);
            memberCollection[size] = newMember1;
            size += 1;
            Array.Resize<Member>(ref memberCollection, memberCollection.Length + 1);
            //newMember1.printinfo();

            Member newMember2 = new Member();
            newMember2.register("James", "Bond", "12 Redbank Rd", 0415123094, 4321);
            memberCollection[size] = newMember2;
            size += 1;
            Array.Resize<Member>(ref memberCollection, memberCollection.Length + 1);
            //newMember2.printinfo();

            Member newMember3 = new Member();
            newMember3.register("Beckie", "Lin", "12 Brisbane Rd", 0415123094, 4321);
            memberCollection[size] = newMember3;
            size += 1;
            Array.Resize<Member>(ref memberCollection, memberCollection.Length + 1);
            //newMember3.printinfo();

            //Console.WriteLine(memberCollection.Length);



        }

        public int GetSize()
        {
            return size;
        }

        public Member returnMember(int i)
        {
            return memberCollection[i];
        }

        public Member[] returnArray()
        {
            return memberCollection;
        }
    }
}
