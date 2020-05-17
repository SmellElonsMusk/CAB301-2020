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

        public void add(Member member) { 
            memberCollection[size] = member;
            this.size += 1;
        }
    }
}
