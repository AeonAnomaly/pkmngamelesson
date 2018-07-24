
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomAttack = new Random();
            Random randomPokemon = new Random();
            bool playerInputTest;
            int playerInput;
            int playerAttack;
            int pokemonSelection;
            string playerNameInput;
            pokemon[] playerParty = new pokemon[3];
            pokemon[] aiParty = new pokemon[3];

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
            pokemons[9] = new pokemon(100, "Pikachu", element.elements.electric, 3);
            
            
            do
            {
                Console.Clear();
                Display.AskTrainerName();
                playerNameInput = Console.ReadLine();                    
            } while (playerNameInput.Length == 0);

            Trainer playerTrainer = new Trainer(playerNameInput, playerParty, true);
            Trainer aiTrainer = new Trainer("Youngster Joey", aiParty, false);

            Display.GreetingName(playerTrainer);

            for (int i = 0; i < 3; i++)
            {                
                do
                {
                    Console.Clear();
                    Display.PartySelection(pokemons, playerParty);
                    playerInputTest = Display.checkInput(1, pokemons.Length + 1, Console.ReadLine(), out playerInput);
                } while (playerInputTest == false);

                playerParty[i] = pokemons[(playerInput - 1 )];

                while (pokemons[playerInput - 1].isAvailable == false)
                {
                    Console.WriteLine(pokemons[playerInput - 1].name + " is already selected, please select another.");
                    do
                    {                        
                        playerInputTest = Display.checkInput(1, pokemons.Length + 1, Console.ReadLine(), out playerInput);
                    } while (playerInputTest == false);
                    playerParty[i] = pokemons[(playerInput - 1)];
                }
                Console.WriteLine("You have selected " + playerParty[i].name); Console.ReadLine();
                playerParty[i].isAvailable = false;
                Console.Clear();
            }
           
            for (int i = 0; i < 3; i++)
            {
                aiParty[i] = pokemons[randomPokemon.Next(pokemons.Length)];
                while(aiParty[i].isAvailable == false)
                {
                    aiParty[i] = pokemons[randomPokemon.Next(pokemons.Length)];
                }
                aiParty[i].isAvailable = false;
            }

            
            pokemon playerActivePokemon = playerParty[0];
            pokemon aiActivePokemon = aiParty[0];

            Display.TrainerChallenge("Youngster Joey", aiActivePokemon, playerActivePokemon);

            while (true)
            {                
                do
                {
                    Console.Clear();
                    Display.PokemonCombatantsHP(playerActivePokemon, aiActivePokemon);
                    Display.BattleActions();
                    playerInputTest = Display.checkInput(1, 3, Console.ReadLine(), out playerInput);
                } while (playerInputTest == false);

                if(playerInput == 1)
                {
                    do
                    {
                        Console.Clear();
                        Display.PokemonCombatantsHP(playerActivePokemon, aiActivePokemon);
                        Display.MovesSelection(playerActivePokemon);
                        playerInputTest = Display.checkInput(1, playerActivePokemon.GetNumAttacks() + 1, Console.ReadLine(), out playerAttack);
                    } while (playerInputTest == false);
                   
                    
                    playerActivePokemon.PerformAttack(aiActivePokemon, (playerAttack -1 ));
                    aiActivePokemon.PerformAttack(playerActivePokemon, randomAttack.Next(aiActivePokemon.GetNumAttacks()));
                }
                if(playerInput == 2)
                {                    
                    do
                    {
                        Console.Clear();
                        Display.PokemonCombatantsHP(playerActivePokemon, aiActivePokemon);
                        Display.PokemonSwitchSelection(playerParty);
                        playerInputTest = Display.checkInput(1, playerParty.Length + 1, Console.ReadLine(), out pokemonSelection);
                    } while (playerInputTest == false);
                    playerTrainer.Switch(ref playerActivePokemon, playerParty[(pokemonSelection -1)]);
                    int aiAttack = randomAttack.Next(aiActivePokemon.GetNumAttacks());
                    aiActivePokemon.PerformAttack(playerActivePokemon, aiAttack);
                }
                                              
                if(playerActivePokemon.hp <= 0)
                {                    
                    playerTrainer.Alive -= 1;
                    if (playerTrainer.Alive > 0)
                    {                        
                        do
                        {
                            Console.Clear();
                            Display.PokemonSwitchSelection(playerParty);
                            playerInputTest = Display.checkInput(0, playerParty.Length, Console.ReadLine(), out pokemonSelection);
                        } while (playerInputTest == false);
                        playerActivePokemon = playerParty[(pokemonSelection - 1)];
                        Console.WriteLine("You have selected " + playerActivePokemon.name); Console.ReadLine();
                    } else
                    {
                        Console.WriteLine(playerTrainer.trainerName + " has run out of Pokemon!"); Console.ReadLine();
                        break;
                    }
                    
                }
                if(aiActivePokemon.hp <= 0)
                {                    
                    aiTrainer.Alive -= 1;
                    if (aiTrainer.Alive > 0)
                    {
                        do
                        {
                            aiActivePokemon = aiParty[randomPokemon.Next(aiParty.Length)];
                        } while (aiActivePokemon.hp <= 0);
                        Console.WriteLine(aiTrainer.trainerName + " sends out " + aiActivePokemon.name); Console.ReadLine();                        
                    }
                    else
                    {
                        Console.WriteLine("All of " + aiTrainer.trainerName + "'s Pokemon have fainted!"); Console.ReadLine();
                        break;
                    }
                }                                                                                                   
            }            
        }
    }
}
