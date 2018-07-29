
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            // init var                   
            Trainer playerTrainer = new Trainer("", true);
            Trainer aiTrainer = new Trainer("Youngster Joey");

            //init Pokemon available in pool to choose from
            pokemon[] pokemons = new pokemon[10];
            pokemons[0] = new pokemon(100, "Bulbasaur", element.elements.grass,2);
            pokemons[1] = new pokemon(100, "Charmander", element.elements.fire,2);
            pokemons[2] = new pokemon(100, "Squirtle", element.elements.water,2);
            pokemons[3] = new pokemon(100, "Rattata", element.elements.normal,3);
            pokemons[4] = new pokemon(100, "Pidgey", element.elements.flying,2);
            pokemons[5] = new pokemon(100, "Spearow", element.elements.flying,2);
            pokemons[6] = new pokemon(100, "Nidoran", element.elements.poison,1);
            pokemons[7] = new pokemon(100, "Caterpie", element.elements.bug,1);
            pokemons[8] = new pokemon(100, "Weedle", element.elements.bug,1);
            pokemons[9] = new pokemon(100, "Pikachu", element.elements.electric,3);
                       
            Display.AskTrainerName(ref playerTrainer);      //Ask for, and set, Player trainer name
            playerTrainer.setParty(pokemons);               //Display selection of Pokemon, and have Player select party from pool
            aiTrainer.setParty(pokemons);                   //Creates a random party from remaining in pool for an ai Trainer
          
            Battle.SwitchActions(playerTrainer, aiTrainer, false);
            aiTrainer.activePokemon = aiTrainer.partyofPokemon[0];
            
            Display.TrainerChallenge(aiTrainer.trainerName, aiTrainer.activePokemon, playerTrainer.activePokemon);
            Battle.NewBattle(playerTrainer, aiTrainer);            
        }
    }
}
