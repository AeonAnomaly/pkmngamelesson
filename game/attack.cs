using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class attack: element
    {
        public int damage { get; set; }
        public elements attackElement { get; set; }
        public string name { get; set; }
        public statusconditions attackStatus { get; set; }
        

        public attack(int dmg, elements ele, string attackName, statusconditions status)
        {
            damage = dmg;
            attackElement = ele;
            name = attackName;
            attackStatus = status;
        }        
    }
}
