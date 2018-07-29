using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace game
{
    public class Battle
    {
        public static void NewBattle (Trainer trainer1, Trainer trainer2)
        {
            Random rand = new Random();
            while (true)
            {
                BattleActions(trainer1, trainer2);
                trainer2.activePokemon.PerformAttack(trainer1.activePokemon, rand.Next(trainer2.activePokemon.GetNumAttacks()));
                if (!trainer1.activePokemon.isAlive)
                {
                    trainer1.Alive--;
                    if(trainer1.Alive >0)
                    {
                        SwitchActions(trainer1, trainer2, false);
                    } 
                    else
                    {
                        Console.WriteLine(trainer1.trainerName + " has run out of Pokemon!");
                        Console.ReadLine();
                        break;
                    }
                }
                if (!trainer2.activePokemon.isAlive)
                {
                    Random random = new Random();
                    trainer2.Alive--;
                    if (trainer2.Alive > 0)
                    {
                        do
                        {
                            trainer2.activePokemon = trainer2.partyofPokemon[random.Next(trainer2.partyofPokemon.Length)];
                        } while (trainer2.activePokemon.hp <= 0);
                        Console.WriteLine(trainer2.trainerName + " sends out " + trainer2.activePokemon.name);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("All of " + trainer2.trainerName + "'s Pokemon have fainted!");
                        Thread.Sleep(2000);
                        break;
                    }
                }                                
            }
        }

        private static void BattleActions(Trainer trainer1, Trainer trainer2)
        {
            int playerChoice;            
            Display.BattleMenu(trainer1, trainer2, out playerChoice);
            switch (playerChoice)
            {
                case 1:
                    AttackActions(trainer1, trainer2);                    
                    break;
                case 2:
                    SwitchActions(trainer1, trainer2);
                    break;
            }            
        }

        private static void AttackActions(Trainer trainer1, Trainer trainer2)
        {
            int playerChoice;
            Display.MovesSelection(trainer1, trainer2, out playerChoice);
            if (playerChoice == 0)
            {
                BattleActions(trainer1, trainer2);
            }
            else
            {
                trainer1.activePokemon.PerformAttack(trainer2.activePokemon, playerChoice - 1);
            }
        }

        public static void SwitchActions(Trainer trainer1, Trainer trainer2, bool fromBattleMenu = true)
        {
            int playerChoice;
            Display.PokemonSwitchMenu(trainer1, out playerChoice, fromBattleMenu);
            if (playerChoice == 0)
            {
                BattleActions(trainer1, trainer2);
            }
            else
            {
                trainer1.activePokemon = trainer1.partyofPokemon[playerChoice - 1];
                Display.SwitchedInPokemon(trainer1.activePokemon);
            }
        }
    }
}
