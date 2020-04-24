using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Monster
    {

        public string name;
        public int currentHP;
        public int maxHP;
        public int attack;
        public int armor;


        public Monster(string _name, int _currentHP, int _maxHP, int _attack, int _armor)
        {
            name = _name;
            currentHP = _currentHP;
            maxHP = _maxHP;
            attack = _attack;
            armor = _armor;

        }
    } 
}
