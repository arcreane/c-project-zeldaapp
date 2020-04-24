using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeldapp
{
    class Zombie : Monster
    {
        public Zombie(string _name, int _currentHP, int _maxHP, int _attack, int _armor) : base(_name, _currentHP, _maxHP, _attack, _armor)
        {
        }
    }
}
