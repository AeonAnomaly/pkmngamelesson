using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Input
    {        
        public static bool checkInput(int lowerBound, int upperBound, string input, out int output)
        {                        
            bool test = int.TryParse(input, out output);
            if (!test)
            {
                return false;
            }
            if (output < lowerBound)
            {
                return false;
            }
            if (output >= upperBound)
            {
                return false;
            }
            return true;
        }

        public enum PokemonNames { Bulbasaur = 1, Charmander, Squirtle, Rattata, Pidgey, Spearow, Nidoran, Caterpie, Weedle, Pikachu };
        
    }

}
