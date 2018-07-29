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
        bool isPlayer;
        public pokemon[] partyofPokemon = new pokemon[3];
        public int Alive { get; set; }
        public pokemon activePokemon { get; set; }

        public Trainer(string name, bool playerCheck = false)
        {
            trainerName = name;
            isPlayer = playerCheck;
            Alive = 3;           
        }
        
        public void setParty(pokemon[] pokemonList)
        {
            if (isPlayer)
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
                                Thread.Sleep(2000);
                            }                            
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                            Thread.Sleep(2000);
                        }
                    } while (!selected);                    
                    Console.WriteLine("You have selected " + partyofPokemon[i].name);                    
                    partyofPokemon[i].isAvailable = false;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            if (!isPlayer)
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
            }            
        }                                           
    }
}
