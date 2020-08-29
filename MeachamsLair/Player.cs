using System;
using System.Collections.Generic;
using System.Text;

namespace MeachamsLair
{
    class Player
    {
        // Initialize Player variables
        private string name;
        private int health = 100;
        private int maxHealth = 100;
        private int maxAttack = 25;
        private int position = 0;
        private int coins = 0;
        private int healthPotionPouch;



        // Initialize Random Object for Attack method
        Random rand = new Random();



        // Create getters and setters
        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetCoins()
        {
            return this.coins;
        }

        public int GetPosition()
        {
            return this.position;
        }

        public void SetPosition(int number)
        {
            this.position = number;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetMaxHealth()
        {
            return this.maxHealth;
        }

        public void SetHealth(int number)
        {
            this.health = number;
        }


        // Method used to advance player position
        public void AdvanceTile()
        {
            this.position++;
        }


        // Add and Remove coins for when a player defeats a monster or puchases a potion
        public void AddCoins(int number)
        {
            this.coins += number;
            Console.WriteLine("\n\t>> You found " + number + "gp! You now have " + this.coins + "gp.");
            Console.ReadLine();
        }

        public void SubtractCoins(int number)
        {
            this.coins -= number;
        }

        // Add and remove health methods to calculate player healtha after being attacked and
        // after drinking a health potion
        public void RemoveHealth(int number)
        {
            this.health -= number;
        }

        public void AddHealth(int number)
        {
            this.health += number;
        }

        // Methods used to retrieve current potion total and increase/decrease potion count
        public int GetPotionCount()
        {
            return this.healthPotionPouch;
        }

        public void SetPotionCount(int number)
        {
            this.healthPotionPouch = number;
        }


        // Method to be invoked when player decides to attack an enemy spawn
        public void Attack(Enemy enemy)
        {
            // Create random attack value
            int attack = rand.Next(0, maxAttack + 1);

            // if attack value is zero, output a 'miss' message
            if (attack == 0)
                Console.WriteLine("\n\t>>> Oh no! You missed!");

            // display how much player attacked for
            Console.WriteLine("\n\t>> You attacked for " + attack + " damage!");


            // if enemy health is less than or equal to the attack value, then enemy is defeated
            if (enemy.GetHealth() <= attack)
            {
                enemy.SetHealth(0);         // enemy health is now 0

                // print this message only if the enemy was declared as the final boss, hence end of game
                if (enemy.IsFinalBoss())
                {
                    Console.WriteLine("\t##########################################");
                    Console.WriteLine("\t### YOU REACHED THE END OF THE DUNGEON ###");
                    Console.WriteLine("\t################ WINNER! #################");
                    Console.WriteLine("\t##########################################");
                }
                Console.WriteLine("\n\t>> The " + enemy.GetName() + " was defeated!");

                // add coin drop value and health potion drop chance
                this.AddCoins(Game.GenerateCoinDrop());

                // print this only if enemy drops a health potion
                if (Game.DidPotionDrop())
                {
                    Console.WriteLine("\n\t>> The " + enemy.GetName() + " dropped a health potion! Nice!");
                    this.SetPotionCount(this.GetPotionCount() + 1);
                    Console.WriteLine("\t>> You add the health potion to your pouch. You now have " + this.GetPotionCount() + " health potions.");
                    Console.ReadLine();
                }

                Console.Clear();
            }
            else                // if attack is less than enemy health, remove health and print remaining
            {
                enemy.RemoveHealth(attack);
                Console.WriteLine("\t>> The " + enemy.GetName() + " has " + enemy.GetHealth() + " HP remaining.");
            }
        }

    }
}
