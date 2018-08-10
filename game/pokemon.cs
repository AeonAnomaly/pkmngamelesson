using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    public class pokemon: element
    {
        public string name;
        public int hp { get; set; }
        elements pmElement;
        attack[] assignedAttack = new attack[2];
        public int Speed;
        public bool isAvailable = true;
        public bool isAlive{ get; set; }
        public bool StatusCondition { get; set; }
        public bool isPoisoned { get; set; }
        public bool isBurned { get; set; }
        public int maxHP = 100;
        

        public pokemon(int hitpoints, string pokemonName, elements pokemonElement, int PokemonSpeed)
        {
            isAlive = true;
            hp = hitpoints;
            name = pokemonName;
            pmElement = pokemonElement;
            setAttacks();
            Speed = PokemonSpeed;                        
        }

        private void setAttacks()
        {
            switch (name)
            {
                case "Bulbasaur":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.grass, "Vine Whip", statusconditions.normal);
                    break;
                case "Charmander":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.fire, "Ember", statusconditions.burn);
                    break;                
                case "Squirtle":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.water, "Water Gun", statusconditions.normal);
                    break;
                case "Rattata":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.dark, "Bite", statusconditions.normal);
                    break;
                case "Pidgey":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.flying, "Gust", statusconditions.normal);
                    break;
                case "Spearow":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.flying, "Peck", statusconditions.normal);
                    break;
                case "Nidoran":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.fight, "Double Kick", statusconditions.normal);
                    break;
                case "Caterpie":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.bug, "Bug Bite", statusconditions.normal);
                    break;
                case "Weedle":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.poison, "Poison Sting", statusconditions.poison);
                    break;
                case "Pikachu":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle", statusconditions.normal);
                    assignedAttack[1] = new attack(15, elements.electric, "Thundershock", statusconditions.normal);
                    break;
            }
        }

        public int GetNumAttacks()
        {
            return assignedAttack.Length;
        }

        public string GetAttackName (int getAttackIndex)
        {
            return assignedAttack[getAttackIndex].name;
        }
            
        public void PerformAttack(Trainer defPokemon, int attackIndex)
        {
            if (!isAlive)
            {
                return;
            }
            int dmg;
            float stabmulti = 1;
            if (this.pmElement == assignedAttack[attackIndex].attackElement)
            {
                stabmulti = 1.5f;
            }
            dmg = (int)Math.Round((float)assignedAttack[attackIndex].damage * elementGrid[(int)assignedAttack[attackIndex].attackElement, (int)defPokemon.activePokemon.pmElement] * stabmulti);
            defPokemon.activePokemon.TakeDamage(dmg);
            Display.PokemonUsedMove(this, defPokemon, assignedAttack[attackIndex].name, dmg, elementGrid[(int)assignedAttack[attackIndex].attackElement, (int)defPokemon.activePokemon.pmElement]);                        
            if (assignedAttack[attackIndex].attackStatus != element.statusconditions.normal && defPokemon.activePokemon.StatusCondition == false)
            {
                Random rand = new Random();
                int chance = rand.Next(1, 100);
                if (chance <= 100)
                {
                    defPokemon.activePokemon.StatusCondition = true;
                    switch (assignedAttack[attackIndex].attackStatus)
                    {
                        case statusconditions.burn:
                            defPokemon.activePokemon.isBurned = true;
                            Console.WriteLine(defPokemon.activePokemon.name + " was burned!");                            
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write(new string(' ', Console.BufferWidth));
                            break;
                        case statusconditions.poison:                            
                            defPokemon.activePokemon.isPoisoned = true;
                            Console.WriteLine(defPokemon.activePokemon.name + " was poisoned!");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write(new string(' ', Console.BufferWidth));
                            break;
                    }
                        
                }
            }
        }

        public void TakeDamage (int damageTaken)
        {
            hp -= damageTaken;
            if (hp <= 0)
            {
                hp = 0;
                isAlive = false;                
            }
        }
        
        public void CheckStatusCondition()
        {
            if (isBurned)
            {
                TakeDamage(maxHP / 8);                
                Console.WriteLine(name + " is hurt by its burn!");
            }
            if (isPoisoned)
            {
                TakeDamage(maxHP / 8);
                Console.WriteLine(name + " is hurt by poison!");
            }
        }
    }
}
