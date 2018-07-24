using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.grass, "Vine Whip");
                    break;
                case "Charmander":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch");
                    assignedAttack[1] = new attack(15, elements.fire, "Ember");
                    break;                
                case "Squirtle":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.water, "Water Gun");
                    break;
                case "Rattata":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch");
                    assignedAttack[1] = new attack(15, elements.dark, "Bite");
                    break;
                case "Pidgey":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.flying, "Gust");
                    break;
                case "Spearow":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch");
                    assignedAttack[1] = new attack(15, elements.flying, "Peck");
                    break;
                case "Nidoran":
                    assignedAttack[0] = new attack(5, elements.normal, "Scratch");
                    assignedAttack[1] = new attack(15, elements.fight, "Double Kick");
                    break;
                case "Caterpie":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.bug, "Bug Bite");
                    break;
                case "Weedle":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.poison, "Poison Sting");
                    break;
                case "Pikachu":
                    assignedAttack[0] = new attack(5, elements.normal, "Tackle");
                    assignedAttack[1] = new attack(15, elements.electric, "Thundershock");
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
        

        public void PerformAttack(pokemon defPokemon, int attackIndex)
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
            dmg = (int)Math.Round((float)assignedAttack[attackIndex].damage * elementGrid[(int)assignedAttack[attackIndex].attackElement, (int)defPokemon.pmElement] * stabmulti);
            Display.PokemonUsedMove(this, defPokemon, assignedAttack[attackIndex].name, dmg, elementGrid[(int)assignedAttack[attackIndex].attackElement, (int)defPokemon.pmElement]);
            defPokemon.TakeDamage(dmg);            
        }

        public void TakeDamage (int damageTaken)
        {
            hp -= damageTaken;
            if (hp <= 0)
            {
                hp = 0;
                isAlive = false;
                Display.FaintedPokemon(this);
            }
        }


    }
}
