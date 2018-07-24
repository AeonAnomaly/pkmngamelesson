using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Trainer
    {
        public string trainerName;
        bool isPlayer;
        pokemon[] partyOfPokemon;
        public int Alive {get; set;}

        public Trainer(string name, pokemon[] party, bool playerCheck)        {
            trainerName = name;
            partyOfPokemon = party;
            isPlayer = playerCheck;
            Alive = party.Length;
            
        }

        public void Switch(ref pokemon currentPokemon, pokemon switchingPokemon)
        {                        
            currentPokemon = switchingPokemon;
            Display.SwitchedInPokemon(currentPokemon);
        }
    }
}
