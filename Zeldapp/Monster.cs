using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Monster
    {

        private int health;
        private int attack;
        private int armor;


        private Monster(int _health, int _attack, int _armor)
        {
            health = _health;
            attack = _attack;
            armor = _armor;

        }
    } 
}
