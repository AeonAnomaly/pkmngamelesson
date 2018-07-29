using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    public class Display
    {
               
        public static void AskTrainerName(ref Trainer newPlayerTrainer)
        {
            string playerNameInput;
            do {
                Console.Clear();
                Console.WriteLine("Welcome to the world of Pokemon!");
                Console.Write("Please enter your Trainer Name:");
                playerNameInput = Console.ReadLine();
            } while (playerNameInput.Trim().Length == 0);
            newPlayerTrainer.trainerName = playerNameInput;
            Console.WriteLine("\nNice to meet you " + newPlayerTrainer.trainerName + "!");
            Console.WriteLine("It's time for you to select your party!");
            Thread.Sleep(2000);
            Console.Clear();            
        }

        public static void PartySelection(pokemon[] availablePokemon, pokemon[] inParty)
        {
            Console.Clear();
            Console.WriteLine("Please select your Pokemon from the list:");
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
            Console.WriteLine(startingPlayerPokemon.name + ", I choose you!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void PokemonSwitchMenu(Trainer trainer1, out int playerInput, bool fromBattleMenu = true)
        {
            bool playerInputTest;
            //bool done = false;
            do {
                Console.Clear();
                Console.WriteLine("Choose the Pokemon you want to switch in:");
                for (int i = 0; i < trainer1.partyofPokemon.Length; i++)
                {
                    if (trainer1.partyofPokemon[i].isAlive)
                    {
                        Console.WriteLine((i + 1) + ". " + trainer1.partyofPokemon[i].name + " Current HP: " + trainer1.partyofPokemon[i].hp);
                    }                                    
                }
                if (fromBattleMenu)
                {
                    Console.WriteLine("0. Return to previous menu.");
                }
                string input = Console.ReadLine();
                if (!fromBattleMenu)
                {
                    playerInputTest = Input.checkInput(1, trainer1.partyofPokemon.Length + 1, input, out playerInput);
                    //done = true;
                }
                else
                {
                    playerInputTest = Input.checkInput(0, trainer1.partyofPokemon.Length + 1, input, out playerInput);
                    if (playerInput == 0)
                    {
                        //done = true;
                        break;
                    }
                }                                
            } while (playerInputTest == false || !trainer1.partyofPokemon[playerInput -1].isAlive || trainer1.activePokemon == trainer1.partyofPokemon[playerInput-1]);
        }

        public static void PokemonCombatantsHP (Trainer iPlayerTrainer, Trainer iAiTrainer)
        {
            Console.Clear();
            Console.WriteLine(" " + iPlayerTrainer.activePokemon.name + " HP: " + iPlayerTrainer.activePokemon.hp + "\n " + iAiTrainer.activePokemon.name + " HP: " + iAiTrainer.activePokemon.hp + "\n");
        }

        public static void BattleMenu(Trainer iPlayerTrainer, Trainer iAiTrainer, out int playerInput)
        {
            bool playerInputTest;            
            string input;
            do
            {
                PokemonCombatantsHP(iPlayerTrainer, iAiTrainer);
                Console.WriteLine("\nSelect Action:\n 1. Attack\n 2. Switch");
                input = Console.ReadLine();
                playerInputTest = Input.checkInput(1, 3, input, out playerInput);
            } while (playerInputTest == false);            
        }         

        public static void MovesSelection(Trainer iPlayerTrainer, Trainer iAiTrainer, out int playerInput)
        {
            bool playerInputTest;
            string input;
            do
            {
                PokemonCombatantsHP(iPlayerTrainer, iAiTrainer);
                Console.WriteLine("\nAvailable attacks for " + iPlayerTrainer.activePokemon.name + ":");
                for (int i = 0; i < iPlayerTrainer.activePokemon.GetNumAttacks(); i++)
                {
                    Console.WriteLine(" " + (i + 1) + ". " + iPlayerTrainer.activePokemon.GetAttackName(i));
                }
                Console.WriteLine("\n0. Return to previous menu");
                input = Console.ReadLine();
                playerInputTest = Input.checkInput(0, iPlayerTrainer.activePokemon.GetNumAttacks() + 1, input, out playerInput);
            } while (playerInputTest == false);        
        }

        public static void PokemonUsedMove(pokemon attackPokemon, pokemon defendPokemon, string moveUsed, int damageDealt, float superEffectiveCheck)
        {
            Console.WriteLine(attackPokemon.name + " used " + moveUsed + "!");            
            if(superEffectiveCheck == 2)
            {
                Console.WriteLine("It's super effective!");                
            }
            if(superEffectiveCheck == 0.5)
            {
                Console.WriteLine("It's not very effective...");                
            }
            if(superEffectiveCheck == 0)
            {
                Console.WriteLine("It doesn't have any effect...");                
            }
            Console.WriteLine(defendPokemon.name + " takes " + damageDealt + " damage!");
            Thread.Sleep(2000);
        }

        public static void FaintedPokemon(pokemon OneWhoHasFainted)
        {
            Console.WriteLine(OneWhoHasFainted.name + " has fainted!");
            Thread.Sleep(2000);
        }

        public static void SwitchedInPokemon(pokemon OneWhoHasSwitchedIn)
        {
            Console.WriteLine("You have selected " + OneWhoHasSwitchedIn.name);
            Thread.Sleep(2000);
        }        
    }
}
