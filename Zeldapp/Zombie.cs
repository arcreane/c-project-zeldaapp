using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Zombie : Monster
    {
        public Zombie(string name, string type)
        {

            this.name = name;
            this.type = type;

            
                    health = 10;
                    attack = 5;
                    armor = 5;
                   
            

        }
    }
    
    

}
