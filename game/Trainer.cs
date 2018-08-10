using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    public class Trainer
    {
        Random rand = new Random();
        public string trainerName;
        public bool isPlayer { get; set; }
        public pokemon[] partyofPokemon = new pokemon[3];
        public int Alive { get; set; }
        public pokemon activePokemon { get; set; }
        private int timeOut = 2000;

        public Trainer(string name, bool playerCheck = false)
        {
            trainerName = name;
            isPlayer = playerCheck;
            Alive = 3;           
        }
        
        public void setParty(pokemon[] pokemonList)
        {
                for (int i = 0; i < 3; i++)
                {
                    string input;
                    Input.PokemonNames enumCheck;
                    bool selected = false;
                    do
                    {                        
                        Display.PartySelection(pokemonList, partyofPokemon);                        
                        input = Console.ReadLine();
                        if (Enum.TryParse(input, true, out enumCheck))
                        { 
                            if(Enum.IsDefined(typeof(Input.PokemonNames),enumCheck) && pokemonList[(int)enumCheck - 1].isAvailable)
                            {
                                partyofPokemon[i] = pokemonList[(int)enumCheck - 1];
                                selected = true;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid Pokemon.");
                                Thread.Sleep(timeOut);
                            }                            
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                            Thread.Sleep(timeOut);
                        }
                    } while (!selected);                    
                    Console.WriteLine("You have selected " + partyofPokemon[i].name);                    
                    partyofPokemon[i].isAvailable = false;
                    Thread.Sleep(timeOut);
                    Console.Clear();
                }                                   
        }   
        public void setAIParty(pokemon[] pokemonList)
        {
            for (int i = 0; i < 3; i++)
            {
                partyofPokemon[i] = pokemonList[rand.Next(pokemonList.Length)];
                while (partyofPokemon[i].isAvailable == false)
                {
                    partyofPokemon[i] = pokemonList[rand.Next(pokemonList.Length)];
                }
                partyofPokemon[i].isAvailable = false;
            }
            activePokemon = partyofPokemon[0];
        }

        public void CheckPlayerAlive(Trainer AItrainer, ref bool PartyisStillAlive)
        {
            if (!activePokemon.isAlive)
            {
                Display.FaintedPokemon(this.activePokemon);
                Alive--;
                if (Alive > 0)
                {                    
                    Battle.SwitchActions(this, AItrainer, false);
                }
                else
                {
                    Console.WriteLine(trainerName + " has run out of Pokemon!");
                    PartyisStillAlive = false;
                    Thread.Sleep(timeOut);
                }
            }
        }

        public void CheckAIAlive(ref bool PartyisStillAlive)
        {
            if (!activePokemon.isAlive)
            {
                Display.FaintedPokemon(this.activePokemon);
                Alive--;
                if (Alive > 0)
                {
                    do
                    {
                        activePokemon = partyofPokemon[rand.Next(partyofPokemon.Length)];
                    } while (activePokemon.hp <= 0);
                    Console.WriteLine(trainerName + " sends out " + activePokemon.name);
                    Thread.Sleep(timeOut);
                }
                else
                {
                    Console.WriteLine("All of " + trainerName + "'s Pokemon have fainted!");
                    PartyisStillAlive = false;
                    Thread.Sleep(timeOut);
                }
            }            
        }
    }
}
