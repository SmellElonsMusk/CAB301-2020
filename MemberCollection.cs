using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    class MemberCollection
    {
       private Member[] memberCollection;
        private int size = 0; 

        public void create()
        {
            this.memberCollection = new Member[1];
        }

        public void add() {

            // Input Paramaters
            String param1, param2, param3;
            int param4, param5;

            Console.WriteLine("---------Add Member---------");
            Console.Write("First Name: "); param1 = Console.ReadLine();
            Console.Write("Last Name: "); param2 = Console.ReadLine();
            Console.Write("Home Address: "); param3 = Console.ReadLine();
            Console.Write("Phone Number: "); param4 = int.Parse(Console.ReadLine());
            Console.Write("Password (4 Digit number): "); param5 = int.Parse(Console.ReadLine());
            Member newMember = new Member();
            newMember.register(param1, param2, param3, param4, param5);

            memberCollection[size] = newMember;
            
        }
    }
}
