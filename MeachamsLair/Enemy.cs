using System;
using System.Collections.Generic;
using System.Text;

namespace MeachamsLair
{
    class Enemy
    {
        // This array houses all potential monster names
        private string[] enemies = { "Skeleton Warrior", "Phantom Assassin", "Undead Ape", "Berserker Orc", "Zombie Tom Cruise", "Vegan Vampire" };


        // Initialize Random object in order to create random health and random attack values 
        Random rand = new Random();


        // Declare enemy variables
        private string name;
        private int maxHealth = 30;
        private int health;
        private int maxAttack = 18;
        private static bool finalBoss = false;



        // Constructor - generates a random name and health value based on maxAttack variable
        public Enemy()
        {
            this.name = enemies[rand.Next(0, enemies.Length)];
            this.health = rand.Next(1, maxHealth + 1);
        }

        // Create Getters and Setters
        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public void SetHealth(int number)
        {
            this.health = number;
        }

        public void SetMaxAttack(int number)
        {
            this.maxAttack = number;
        }

        public static void SetFinalBoss(Enemy enemy)
        {
            Enemy.finalBoss = true;
        }


        // Method used for applying player attack on the enemy
        public void RemoveHealth(int number)
        {
            this.health -= number;
        }


        // Method used to determine whether a player is on the final tile
        public bool IsFinalBoss()
        {
            if (Enemy.finalBoss == true) return true;
            else return false;
        }


        // Enemy attack method
        public void Attack(Player player)
        {
            // generate random attack value based on maxAttack variable
            int attack = rand.Next(0, maxAttack + 1);

            // print enemy name and how much it hit for
            Console.WriteLine("\n\t>> " + this.name + " hits for " + attack + " damage.");

            // if an enemy attack is greater than the player's remaining health, game is over
            if (attack >= player.GetHealth())
            {
                player.SetHealth(0);        // sets player health to 0
                Game.GameOver(player);      // invoke end of game method, present player with menu
                Enemy.finalBoss = false;    // new enemy will no longer have final boss settings
            }

            // if enemy attack is less than remaining player health, simply subtract the attack 
            // from the player's health. output remaining player health.
            else
            {
                player.RemoveHealth(attack);
                Console.WriteLine("\t>> You have " + player.GetHealth() + " HP remaining.\n\n");
                Console.WriteLine("\t---------------------------------------------------------\n\n");
                Console.ReadLine();

            }
        }
    }
}
