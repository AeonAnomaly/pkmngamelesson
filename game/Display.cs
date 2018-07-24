using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Display
    {
        public static void AskTrainerName()
        {
            Console.WriteLine("Welcome to the world of Pokemon!");
            Console.Write("Please enter your Trainer Name:");
        }

        public static void GreetingName(Trainer playerTrainerNamed)
        {
            Console.WriteLine("\nNice to meet you " + playerTrainerNamed.trainerName + "!");
            Console.WriteLine("It's time you select your party!"); Console.ReadLine(); Console.Clear();
        }

        public static void PartySelection(pokemon[] availablePokemon, pokemon[] inParty)
        {                        
            Console.WriteLine("Please select your Pokemon from the list!");
            for (int i = 0; i < availablePokemon.Length; i++)
            {
                if(availablePokemon[i].isAvailable == true)
                {
                    Console.WriteLine((i + 1) + ". " + availablePokemon[i].name);
                }                
            }

            Console.Write("In your current party:");
            for(int i = 0; i < inParty.Length; i++)
            {
                if (inParty[i] != null && inParty[i].isAvailable == false)
                {
                    Console.Write( " " + (i + 1) + ". " + inParty[i].name);
                }
            }
            Console.Write("\nEnter your selection:");
            
        }

        public static void TrainerChallenge(string nameofTrainer, pokemon startingAIPokemon, pokemon startingPlayerPokemon)
        {
            Console.WriteLine(nameofTrainer + " wants to battle!");
            Console.WriteLine(nameofTrainer + " sends out " + startingAIPokemon.name);
            Console.WriteLine(startingPlayerPokemon.name + ", I choose you!"); Console.ReadLine(); Console.Clear();
        }

        public static void PokemonSwitchSelection(pokemon[] availablePokemontoSwitchin)
        {
            Console.WriteLine("\nChoose the Pokemon you want to switch in:");
            for (int i = 0; i < availablePokemontoSwitchin.Length; i++)
            {   
                if(availablePokemontoSwitchin[i].hp > 0)
                {
                    Console.WriteLine((i + 1 ) + ". " + availablePokemontoSwitchin[i].name + " Current HP: " + availablePokemontoSwitchin[i].hp);
                }
                
            }
            
        }

        public static void PokemonCombatantsHP (pokemon playerPokemonHP, pokemon aiPokemonHP)
        {
            Console.WriteLine(" " + playerPokemonHP.name + " HP: " + playerPokemonHP.hp + "\n " + aiPokemonHP.name + " HP: " + aiPokemonHP.hp);
        }

        public static void BattleActions()
        {
            Console.WriteLine("\nSelect Action:\n 1. Attack\n 2. Switch");
        }

        public static void MovesSelection (pokemon attackingPokemon)
        {

            Console.WriteLine("\nAvailable attacks for " + attackingPokemon.name + ":");
            for (int i = 0; i < attackingPokemon.GetNumAttacks(); i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + attackingPokemon.GetAttackName(i));
            }
        }

        public static void PokemonUsedMove(pokemon attackPokemon, pokemon defendPokemon, string moveUsed, int damageDealt, float superEffectiveCheck)
        {
            Console.Write(attackPokemon.name + " used " + moveUsed + "!"); Console.ReadLine();
            if(superEffectiveCheck == 2)
            {
                Console.Write("It's super effective!"); Console.ReadLine();
            }
            if(superEffectiveCheck == 0.5)
            {
                Console.Write("It's not very effective..."); Console.ReadLine();
            }
            if(superEffectiveCheck == 0)
            {
                Console.Write("It doesn't have any effect..."); Console.ReadLine();
            }
            Console.Write(defendPokemon.name + " takes " + damageDealt + " damage!"); Console.ReadLine();
        }

        public static void FaintedPokemon(pokemon OneWhoHasFainted)
        {
            Console.WriteLine(OneWhoHasFainted.name + " has fainted!"); Console.ReadLine();
        }

        public static void SwitchedInPokemon(pokemon OneWhoHasSwitchedIn)
        {
            Console.WriteLine("You have selected " + OneWhoHasSwitchedIn.name); Console.ReadLine();
        }

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
            if (output  >= upperBound)
            {
                return false;
            }
            return true;

            
        }
    }
}
