using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Management
{
    public class Group
    {
        public String name;
        public String course;
        public int minAge;
        public int maxAge;
        public int maxAmounOfChildren;
        public int amounOfChildren;
        

        public Group(String name, String course, int minAge, int maxAge, int maxAmounOfChildren)
        {
            this.name = name;
            this.course = course;
            this.minAge = minAge;
            this.maxAge = minAge;
            this.maxAmounOfChildren = maxAmounOfChildren;
            
        }
    }
}
