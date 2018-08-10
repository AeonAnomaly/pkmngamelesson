using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public static class Items
    {
        public static void Potion(Trainer trainerUsingItem)
        {
            if (trainerUsingItem.activePokemon.hp == 100)
            {
                trainerUsingItem.activePokemon.hp += 20;
                if (trainerUsingItem.activePokemon.hp > 100)
                {
                    trainerUsingItem.activePokemon.hp = 100;
                }
                Display.UpdatePokemonHp(trainerUsingItem);
                Console.WriteLine(trainerUsingItem.trainerName + " used a potion on " + trainerUsingItem.activePokemon.name);
            }
            else
            {
                Console.WriteLine(trainerUsingItem.activePokemon.name + "'s HP is already full!");
            }
            
        }

        public static void Antidote(Trainer trainerUsingItem)
        {
            if (trainerUsingItem.activePokemon.isPoisoned)
            {

            }
        }
    }
}
