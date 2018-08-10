using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    public static class Display
    {
        private static int timeOut = 2000;

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
            Thread.Sleep(timeOut);
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

        public static void TrainerChallenge(Trainer ChallengingTrainer, pokemon startingPlayerPokemon)
        {
            Console.WriteLine(ChallengingTrainer.trainerName + " wants to battle!");
            Console.WriteLine(ChallengingTrainer.trainerName + " sends out " + ChallengingTrainer.activePokemon.name);
            Console.WriteLine(startingPlayerPokemon.name + ", I choose you!");
            Thread.Sleep(timeOut);
            Console.Clear();
        }

        public static void PokemonSwitchMenu(Trainer trainerPlayer, out int playerInput, bool fromBattleMenu = true)
        {
            bool playerInputTest;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose the Pokemon you want to switch in:");
                for (int i = 0; i < trainerPlayer.partyofPokemon.Length; i++)
                {
                    if (trainerPlayer.partyofPokemon[i].isAlive)
                    {
                        Console.WriteLine((i + 1) + ". " + trainerPlayer.partyofPokemon[i].name + " Current HP: " + trainerPlayer.partyofPokemon[i].hp);

                    }
                }
                if (fromBattleMenu)
                {
                    Console.WriteLine("\n0. Return to previous menu.");
                }
                string input = Console.ReadLine();
                if (fromBattleMenu)
                {
                    playerInputTest = Input.checkInput(0, trainerPlayer.partyofPokemon.Length + 1, input, out playerInput);
                    if (playerInput == 0)
                    {                        
                        break;
                    }
                }
                else
                {
                    playerInputTest = Input.checkInput(1, trainerPlayer.partyofPokemon.Length + 1, input, out playerInput);                    
                }
            } while (playerInputTest == false || !trainerPlayer.partyofPokemon[playerInput -1].isAlive || trainerPlayer.activePokemon == trainerPlayer.partyofPokemon[playerInput-1]);
        }

        public static void PokemonCombatantsHP (pokemon ThePokemon)
        {            
            Console.Write(" " + ThePokemon.name);
            Console.SetCursorPosition(13, Console.CursorTop);
            Console.Write(" HP: [                    ]");

            Console.SetCursorPosition(19, Console.CursorTop);
            for (int i = 0; i < (ThePokemon.hp / 5 ); i++)
            {
                
                Console.Write("|");
            }
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine("");
        }

        public static void UpdatePokemonHp (Trainer TrainerWithPokemonHealthChanged)
        {
            int currentCursorPosition = (int)Console.CursorTop;
            if (TrainerWithPokemonHealthChanged.isPlayer)
            {                
                Console.SetCursorPosition(13, 0);
                Console.Write(" HP: [                    ]");
                Console.SetCursorPosition(19, 0);
                for (int i = 0; i < (TrainerWithPokemonHealthChanged.activePokemon.hp / 5); i++)
                {

                    Console.Write("|");
                }
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine("");
                Console.SetCursorPosition(0, currentCursorPosition);
            }
            else
            {
                Console.SetCursorPosition(13, 1);
                Console.Write(" HP: [                    ]");
                Console.SetCursorPosition(19, 1);
                for (int i = 0; i < (TrainerWithPokemonHealthChanged.activePokemon.hp / 5); i++)
                {

                    Console.Write("|");
                }
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine("");
                Console.SetCursorPosition(0, currentCursorPosition);
            }
        }

        public static void BattleMenu(Trainer iPlayerTrainer, Trainer iAiTrainer, out int playerInput)
        {
            bool playerInputTest;            
            string input;
            do
            {                
                Console.Clear();
                PokemonCombatantsHP(iPlayerTrainer.activePokemon);
                PokemonCombatantsHP(iAiTrainer.activePokemon);
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
                Console.Clear();
                PokemonCombatantsHP(iPlayerTrainer.activePokemon);
                PokemonCombatantsHP(iAiTrainer.activePokemon);
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

        public static void PokemonUsedMove(pokemon attackPokemon, Trainer defendPokemon, string moveUsed, int damageDealt, float superEffectiveCheck)
        {
            UpdatePokemonHp(defendPokemon);            
            Console.SetCursorPosition(0, 8);
            Console.Write(new string (' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 8);
            Console.WriteLine(attackPokemon.name + " used " + moveUsed + "!");
            Console.Write(new string(' ', Console.BufferWidth));
            if (superEffectiveCheck == 2)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("It's super effective!");                
            }
            if(superEffectiveCheck == 0.5)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("It's not very effective...");                
            }
            if(superEffectiveCheck == 0)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("It doesn't have any effect...");                
            }                        
            Thread.Sleep(timeOut);            
        }

        public static void FaintedPokemon(pokemon OneWhoHasFainted)
        {
            Console.WriteLine(OneWhoHasFainted.name + " has fainted!");
            Thread.Sleep(timeOut);
        }

        public static void SwitchedInPokemon(pokemon OneWhoHasSwitchedIn)
        {
            Console.WriteLine("You have selected " + OneWhoHasSwitchedIn.name);
            Thread.Sleep(timeOut);
        }        
    }
}
