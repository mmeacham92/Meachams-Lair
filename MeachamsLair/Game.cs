using System;
using System.Collections.Generic;
using System.Text;

namespace MeachamsLair
{
    class Game
    {
        // Initialize Random object for coin and potion drops
        public static Random rand = new Random();

        // Declare Game variables
        static bool running = true;
        private static int finalTile = 10;
        private static int healthPotionValue = 25;
        private static int startingPotionCount = 3;
        private static int healthPotionCost = 150;
        private static int potionDropRate = 25;
        private static int maxCoinDrop = 100;



        // Start method
        public static void Start(Player currentPlayer)
        {
            // Title message
            Console.WriteLine("\n\n\t\t#     #                                           ###           #                       \n" +
                "\t\t##   ## ######   ##    ####  #    #   ##   #    # ###  ####     #         ##   # #####  \n" +
                "\t\t# # # # #       #  #  #    # #    #  #  #  ##  ##  #  #         #        #  #  # #    # \n" +
                "\t\t#  #  # #####  #    # #      ###### #    # # ## # #    ####     #       #    # # #    # \n" +
                "\t\t#     # #      ###### #      #    # ###### #    #          #    #       ###### # #####  \n" +
                "\t\t#     # #      #    # #    # #    # #    # #    #     #    #    #       #    # # #   #  \n" +
                "\t\t#     # ###### #    #  ####  #    # #    # #    #      ####     ####### #    # # #    #");

            Console.WriteLine("\n\n\t\t\t\t     'THOSE WHO DARETH ENTER OFFERTH THOU SOUL'\n\n");

            // Collect current player's name and assign the name to the object variable 'name'
            Console.WriteLine("Enter your name: \n");
            string input = Console.ReadLine();
            currentPlayer.SetName(input);

            // give player a starting amount of potions
            currentPlayer.SetPotionCount(startingPotionCount);

            // if player does not enter a name, set name to "Unknown"
            if (currentPlayer.GetName() == "") currentPlayer.SetName("Unknown");

            // print story information
            Console.WriteLine("\n\n\n\n\n\n\t>> While on an afternoon stroll through a field with your dog, Sparky, " +
                "\n\t>> he spots a Mysterious Figure near the tree line and takes off towards it.");
            Console.ReadLine();
            Console.WriteLine("\n\n\t>> You chase Sparky into the woods, frightened at what the figure might have been." +
                "\n\t>> After 20 minutes of searching, you realize you are now lost...");
            Console.ReadLine();
            Console.WriteLine("\n\n\t>> Now frantic, you desperately glance the surroundings for a familiar sight, " +
                "\n\t>> only to see a sign placed at the mouth of a cavern...\n\n");
            Console.ReadLine();
            Console.WriteLine("\t>> It reads...\n\n\n");
            Console.ReadLine();
            Console.WriteLine(" \t\t\t\t\t =============================================");
            Console.WriteLine("\t\t\t\t\t||                                           ||");
            Console.WriteLine("\t\t\t\t\t||   APPLE JACKS > APPLE CINNAMON CHEERIOS   ||");
            Console.WriteLine("\t\t\t\t\t||                                           ||");
            Console.WriteLine(" \t\t\t\t\t =============================================\n\n\n");
            Console.ReadLine();
            Console.WriteLine("\t>> You've never read anything more ridiculous. You are overcome with rage and forget about your canine companion.");
            Console.ReadLine();
            Console.WriteLine("\n\n\t>> You decide whomever wrote such nonsense must reside inside the cave. ");
            Console.ReadLine();
            Console.WriteLine("\n\n\t>> You take your first step into the darkness...\n\n\n");
            Console.ReadLine();
            Console.WriteLine("\t\tWELCOME " + currentPlayer.GetName().ToUpper() + ", YOU HAVE ENTERED MEACHAM'S LAIR!!! PREPARE FOR DEATH... AND MAYBE TAXES.\t\t\t");
            Console.ReadLine();

            // method begins gameplay
            Game.PlayGame(currentPlayer);
        }


        // method begins gameplay
        public static void PlayGame(Player player)
        {
            // method loops while the player isn't already on the last level
            // and also if the game is still running

            while (player.GetPosition() < finalTile && running)
            {
                // generates random enemy spawn and houses combat method
                Encounter(player);

                // if player survives combat or escapes successfully, display continue menu
                if (running)
                    ContinueMenu(player);
            }
        }



        // method which will handle entire monster encounter
        public static void Encounter(Player player)
        {
            player.AdvanceTile();       // advance the player to the next floor

            // present player with basic story setting
            if (player.GetPosition() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t>> Steps past the entrance of the cave, you see Sparky's collar at the foot of a staircase.");
                Console.ReadLine();
                Console.WriteLine("\t>> You begin your ascension to the top of Meacham's Lair, determined to confront the Mysterious Figure");
                Console.WriteLine("\t>> and to save your dog from his absurd taste in cereal.");
                Console.ReadLine();
            }

            // present player with final story setting
            else if (player.GetPosition() == finalTile)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t>> After hacking your way through " + (finalTile - 1) + " floors, you see your companion, seemingly eating");
                Console.WriteLine("\t>> from a bowl next to another set of stairs. You begin to approach until you see the Mysterious Figure standing near the");
                Console.WriteLine("\t>> top of the staircase.");
                Console.ReadLine();
                Console.WriteLine("\n\t>> You shout out 'Who are you? And how can you say that about Apple Cinnamon Cheerios???'");
                Console.ReadLine();
                Console.WriteLine("\n\t>> The Mysterious Figure laughs hauntingly, takes several steps backwards, and disappears into the darkness.");
                Console.ReadLine();
                Console.WriteLine("\n\n\t>> Before following him to the next floor, you approach Sparky to see what is in the bowl...");
                Console.ReadLine();
                Console.WriteLine("\n\n\t>> 'APPLE JACKS!?!?!'");
                Console.ReadLine();
                Console.WriteLine("\n\n\t>> Your love for your dog and hatred for Apple Jacks reinvigorates you.");
                Console.ReadLine();
                Console.WriteLine("\n\t>> As if you ate a senzu bean, you feel your energy has been completely restored! You are back to full HP!");
                player.SetHealth(player.GetMaxHealth());
                Console.ReadLine();
                Console.WriteLine("\n\n\t> You are ready to confront the Mysterious Figure.");
                Console.ReadLine();

            }
            Console.Clear();
            Console.WriteLine("\n\n\t Current Floor No. " + player.GetPosition() + "\n");       // display current floor
            Enemy enemy = new Enemy();          // create new enemy spawn
            Combat(player, enemy);              // method handles battle phase

        }


        // method handles battle phase between the player and the enemy created in the encounter method
        public static void Combat(Player player, Enemy enemy)
        {
            // set enemy object variables to that of the final boss if the player's position is
            // equivalent to the final level position
            if (player.GetPosition() == finalTile)
            {
                Enemy.SetFinalBoss(enemy);
                enemy.SetName("The Mysterious Figure");
                enemy.SetHealth(100);
                enemy.SetMaxAttack(40);
            }

            // print enemy name
            Console.WriteLine("\n\t# " + enemy.GetName() + " has appeared! #\n");


            // loop will continue until the enemy has been defeated or if bool variable running becomes false
            // loop will break if the player is able to safely run from encounter
            while (enemy.GetHealth() > 0 && running)
            {
                // print player and enemy stats
                Console.WriteLine("\n\t Your HP: " + player.GetHealth() + "/" + player.GetMaxHealth());
                Console.WriteLine("\n\t " + enemy.GetName() + "'s HP: " + enemy.GetHealth());

                // battle menu
                Console.WriteLine("\n\n\n\n\tWhat would you like to do?\n");
                Console.WriteLine("\t1. Attack");
                Console.WriteLine("\t2. Drink health potion ( +" + healthPotionValue + " HP ) ----- x" + player.GetPotionCount());
                Console.WriteLine("\t3. Run");

                // assign player's input to a variable to be used in if statement below
                string input = Console.ReadLine();

                // if player decides to attack
                if (input == "1")
                {
                    // Player has attack priority over enemy
                    player.Attack(enemy);

                    // if enemy wasn't defeated, attack player
                    if (enemy.GetHealth() > 0)
                        enemy.Attack(player);
                }

                // if player decides to drink a health potion
                else if (input == "2")
                {
                    // checks if player has available potion
                    if (player.GetPotionCount() > 0)
                    {
                        DrinkHealthPotion(player);

                        // player still gets attacked after drinking a potion successfully
                        enemy.Attack(player);

                        // will break loop if player is defeated after drinking a potion
                        if (player.GetHealth() == 0)
                            break;
                    }

                    // print message alerting player no more available potions; player does not get attacked
                    // if drink health potion is unsuccessful
                    // will continue to start of combat loop
                    else
                    {
                        Console.WriteLine("\n\t>>> You are out of health potions!");
                        Console.ReadLine();
                        Console.WriteLine("\t---------------------------------------------------------\n\n");
                        continue;
                    }
                }

                // if player decides to attempt to flee encounter
                else if (input == "3")
                {
                    // creates a random number between 0 and 100, used to compare to the runSuccessRate
                    int roll = Game.rand.Next(0, 100);
                    int runSuccessChance = 80;

                    Console.WriteLine("\n\t>> You attempt to run away.\n");
                    Console.ReadLine();

                    // player is unable to run from the enemy if they are final boss, player takes enemy attack
                    if (enemy.IsFinalBoss())
                    {
                        Console.WriteLine("\n\t>> Its too late to run, you insolent fool!!!");
                        enemy.Attack(player);
                    }

                    // triggers if roll is higher than success chance, enemy prevents attempt to run and player takes damage
                    else if (roll >= runSuccessChance)
                    {
                        Console.WriteLine("\t>> The " + enemy.GetName() + " blocks your path! You can't get away!\n");
                        enemy.Attack(player);
                    }

                    // player safely runs from encounter and loop is broken
                    else
                    {
                        Console.WriteLine("\t>> You got away safely.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }

                // prints error message if players inputs a value that isn't 1, 2, or 3... loop then continues from start
                else
                {
                    Console.WriteLine("\n\t>>> Invalid input! Please make a valid selection.");
                    continue;
                }
            }
        }


        // prints game over message and gives player option of playing again
        public static void GameOver(Player player)
        {
            Console.WriteLine("\t>>> You have lost all of your HP!");
            Console.WriteLine("\n\t#######################################");
            Console.WriteLine("\t############## GAME OVER ##############");
            Console.WriteLine("\t#######################################");
            Console.ReadLine();
            Console.WriteLine("\n\t-------------------------------------------------------\n");
            Console.WriteLine("\n\tWould you like to enter the cavern again?\n");
            Console.WriteLine("\t1. Yes");
            Console.WriteLine("\t2. No");

            // assigns player response variable input
            string input = Console.ReadLine();

            // resets player stats to default and re-initializes PlayGame() method
            if (input == "1")
            {
                player.SetHealth(player.GetMaxHealth());
                player.SetPosition(0);
                player.SetPotionCount(startingPotionCount);
                Console.Clear();
                PlayGame(player);
            }

            // assigns running to false, which will break PlayGame() loop
            // prints sad dog message
            else
            {
                running = false;
                Console.WriteLine("\n\t>>> You awaken back at the mouth of the cavern.");
                Console.WriteLine("\n\t>>> No sign of Sparky... maybe he made his way home...");
                Console.ReadLine();
                Console.Clear();
            }
        }


        // handles the drinking of a potion
        public static void DrinkHealthPotion(Player player)
        {
            // subtracts a potion from player's pouch
            player.SetPotionCount(player.GetPotionCount() - 1);
            Console.WriteLine("\n\t>> You drank a health potion.");

            // declare variable which is contingent on player remaining health
            int amountHealed;

            // if difference between player maxHealth and health is less than value of a potion,
            // then only heal for the difference
            if (player.GetHealth() + healthPotionValue > player.GetMaxHealth())
            {
                amountHealed = player.GetMaxHealth() - player.GetHealth();
                player.AddHealth(amountHealed);
                Console.WriteLine("\t>> You healed for " + amountHealed + " HP! Fully restored!\n");
            }

            // otherwise the player will heal for the full amount of a potion
            else
            {
                amountHealed = healthPotionValue;
                Console.WriteLine("\t>> You healed " + amountHealed + " HP!");
                player.AddHealth(amountHealed);
                Console.WriteLine("\n\t You now have " + player.GetHealth() + " HP.\n");
            }
        }


        // generates a random amount between 0 and the max possible coin drop;
        // method invokes in the player.Attack method if enemy is defeated
        public static int GenerateCoinDrop()
        {
            return rand.Next(0, maxCoinDrop);
        }


        // method used to determine whether an enemy, after being defeated, will drop a potion
        public static bool DidPotionDrop()
        {
            // create random number between 0 and 100
            int roll = rand.Next(0, 100);

            // compare roll to potionDropRate and return corresponding boolean value
            if (roll <= potionDropRate) return true;
            else return false;
        }


        // prints a menu to player after encounter if player is still alive
        // this is where players can decide to continue to the next level, purchase potions, or exit
        // the game completely
        public static void ContinueMenu(Player player)
        {
            PrintContinueMenu();

            // assign player response to variable input
            string input = Console.ReadLine();

            switch (input)
            {
                // if player decides to continue, break from the statement
                case "1":
                    break;

                // if player decides to purchase a potion
                case "2":

                    while (input == "2")
                    {

                        // checks if player has enough coins to purchase potion;
                        if (player.GetCoins() >= healthPotionCost)
                        {
                            // increase player's potion count and subtract cost of potion from coin total
                            player.SetPotionCount(player.GetPotionCount() + 1);
                            player.SubtractCoins(healthPotionCost);
                            Console.WriteLine("\n\t>> You purchased a health potion!");

                            // this variable is used to determine whether to print 'potion' or 'potions'
                            // after a potion has been purchased; determined by player.GetPotionCount()
                            string potions = "potions";
                            if (player.GetPotionCount() == 1) potions = "potion";

                            // print new potion and coin totals, then take user back to the continue menu
                            Console.WriteLine("\t>> You now have " + player.GetPotionCount() + " health " + potions + ".");
                            Console.WriteLine("\n\t>> Remaining Coins: " + player.GetCoins() + "gp");
                            Console.ReadLine();
                            Console.Clear();
                            PrintContinueMenu();

                            // reassign input variable after seeing menu again
                            input = Console.ReadLine();
                        }

                        // player does not have enough coins to purchase potion
                        else
                        {
                            // will loop until player chooses a different option
                            while (input == "2")
                            {
                                Console.WriteLine("\n\t>>> Not enough gold pieces to purchase potion!");
                                Console.WriteLine("\t>>> Current Coin Total: " + player.GetCoins() + "gp.");
                                Console.ReadLine();
                                Console.Clear();
                                PrintContinueMenu();

                                // reassign input variable after seeing menu again
                                input = Console.ReadLine();

                                // assign running to false if player decides to leave game
                                if (input.Equals("3"))
                                {
                                    running = false;
                                }
                            }
                        }
                    }
                    break;

                // if player decides to exit the game
                case "3":

                    running = false;        // results in the playgame loop to break
                    Console.WriteLine("\n\n\t>>>>> YOU WILL NEVER SEE YOUR DOG AGAIN, QUITTER!!!");
                    Console.ReadLine();
                    break;

                default:
                    break;
            }
        }


        // simply prints options to player after an encounter
        public static void PrintContinueMenu()
        {
            Console.WriteLine("\n\t-------------------------------------------------------\n");
            Console.WriteLine("\tWhat would you like to do?: \n");
            Console.WriteLine("\t1. Continue through dungeon");
            Console.WriteLine("\t2. Buy potion (150gp)");
            Console.WriteLine("\t3. Exit dungeon");
        }

    }
}
