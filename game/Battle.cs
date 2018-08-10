using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace game
{
    public static class Battle
    {
        public static void NewBattle (Trainer trainerPlayer, Trainer trainerAI)
        {
            Random rand = new Random();
            bool PartyAlive = true;

            SwitchActions(trainerPlayer, trainerAI, false);
            Display.TrainerChallenge(trainerAI, trainerPlayer.activePokemon);
            do
            {
                BattleActions(trainerPlayer, trainerAI);
                EndOfBattleCheck(trainerPlayer, trainerAI);
                trainerPlayer.CheckPlayerAlive(trainerAI, ref PartyAlive);
                trainerAI.CheckAIAlive(ref PartyAlive);                
            } while (PartyAlive);
        }

        private static void BattleActions(Trainer trainerPlayer, Trainer trainerAI)
        {
            int playerChoice;            
            Display.BattleMenu(trainerPlayer, trainerAI, out playerChoice);
            switch (playerChoice)
            {
                case 1:
                    AttackActions(trainerPlayer, trainerAI);                    
                    break;
                case 2:
                    SwitchActions(trainerPlayer, trainerAI);
                    break;
            }            
        }

        private static void AttackActions(Trainer trainerPlayer, Trainer trainerAI)
        {
            int playerChoice;
            Display.MovesSelection(trainerPlayer, trainerAI, out playerChoice);
            if (playerChoice == 0)
            {
                BattleActions(trainerPlayer, trainerAI);
            }
            else
            {
                SpeedCheck(trainerPlayer, trainerAI, playerChoice - 1);                
            }
        }

        public static void SwitchActions(Trainer trainerPlayer, Trainer trainerAI, bool fromBattleMenu = true)
        {
            int playerChoice;
            Display.PokemonSwitchMenu(trainerPlayer, out playerChoice, fromBattleMenu);
            switch (playerChoice)
            {
                case 0:
                    BattleActions(trainerPlayer, trainerAI);
                    break;
                default:
                    trainerPlayer.activePokemon = trainerPlayer.partyofPokemon[playerChoice - 1];
                    Display.SwitchedInPokemon(trainerPlayer.activePokemon);
                    if (fromBattleMenu)
                    {
                        Console.Clear();
                        Display.PokemonCombatantsHP(trainerPlayer.activePokemon);
                        Display.PokemonCombatantsHP(trainerAI.activePokemon);
                        Random rand = new Random();
                        trainerAI.activePokemon.PerformAttack(trainerPlayer, rand.Next(trainerAI.activePokemon.GetNumAttacks()));
                    }
                    break;
            }            
        }
        
        private static void SpeedCheck(Trainer trainerPlayer, Trainer trainerAI, int PlayerChoosenMove)
        {
            Random rand = new Random();
            if (trainerPlayer.activePokemon.Speed > trainerAI.activePokemon.Speed)
            {
                trainerPlayer.activePokemon.PerformAttack(trainerAI, PlayerChoosenMove);
                trainerAI.activePokemon.PerformAttack(trainerPlayer, rand.Next(trainerAI.activePokemon.GetNumAttacks()));
            }
            else
            {
                trainerAI.activePokemon.PerformAttack(trainerPlayer, rand.Next(trainerAI.activePokemon.GetNumAttacks()));
                trainerPlayer.activePokemon.PerformAttack(trainerAI, PlayerChoosenMove);
            }
        }

        private static void EndOfBattleCheck(Trainer trainerPlayer, Trainer trainerAI)
        {
            trainerPlayer.activePokemon.CheckStatusCondition();
            Display.UpdatePokemonHp(trainerPlayer);
            trainerAI.activePokemon.CheckStatusCondition();
            Display.UpdatePokemonHp(trainerAI);
            Thread.Sleep(2000);
        }
    }
}
