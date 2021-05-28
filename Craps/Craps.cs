using System;

namespace Craps
{
    class Craps
    {
        /* Austin Rogers
         * Assignment 1
         * 
         * Craps game in C#
         * Game allows the player to play Craps
         * 1. Place Wager
         * 2. Rolls two die and sum the result
         * 3. Compare with win(7,11), lose(2,3,12), and continue conditions(Every other value)
         * 4a. Player either wins or loses.
         * 4b. Player continues rolling. If they roll a 7, they lose. 
               If Player rolls their first value again(called the point), they win.
           5. Distribute winnings and see if they wish to play again.
         */
        static void Main(string[] args)
        {
            
            bool play = true;
            int chips = 100;
            int wager = 0;

            while (play)
            {
                Console.WriteLine("You have " + chips + " chips. Place your wager: ");
                wager = Convert.ToInt32(Console.ReadLine());

                /* Modifies the wager to be within the range of 0 
                 * to the current number of chips
                 */
                if(wager < 0)
                {
                    wager = 0;
                }
                if(wager > chips)
                {
                    wager = chips;
                }
                                            //Starts the game and updates number of chips
                chips += playCraps(wager);

                if(chips <= 0)              //Exits loop if player runs out of chips
                {
                    Console.WriteLine("You are out of chips. Thanks for playing.");
                    break;
                }
                Console.WriteLine("You have " + chips + " chips. Continue Playing? (Enter 'n' to quit)");
                String keepPlaying = Console.ReadLine();

                if (keepPlaying.Equals("n")){    //Exits loop if player is done playing
                    play = false;
                    Console.WriteLine("You ended the game with " + chips + " chips.");
                }
            }



        }

        public static int rollDie()             //assigns a random number(1-6) to a die
        {
            int die = 0;
            Random rand = new Random();
            die = rand.Next(6) + 1;
            return die;
        }
        public static int playCraps(int wager)  //Plays the game of craps
        {
            bool playerWin = false;             //tracks player win condition
                                                //Default is player lost
            int die1 = rollDie();
            int die2 = rollDie();
            int sum = die1 + die2;              //Tracks sum of dice
            int point = 0;

            Console.WriteLine("You rolled a " + sum + ".");
            switch (sum)
            {
                case 7:                         //Initial win condition
                case 11:
                    Console.WriteLine("You won!");
                    playerWin = true;
                    break;
                case 2:                         //Initial lose condition
                case 3:
                case 12:
                    Console.WriteLine("You Lost.");
                    break;
                default:                        //Continues the game if neither condition is satisfied
                    point = sum;
                    Console.WriteLine("Your point is now " + point + ".");
                    break;
            }

            while(point != 0)       //continues game until point is made or lost
            {
                die1 = rollDie();   //rerolls dice 
                die2 = rollDie();
                sum = die1 + die2;

                Console.WriteLine("You rolled a " + sum + ".");
                if(sum == point)    //Win Condition
                {
                    Console.WriteLine("You won!");
                    playerWin = true;
                    break;
                }
                if(sum == 7)        //Lose Condition
                {
                    Console.WriteLine("You lost.");
                    break;
                }
            }

            if (!playerWin)  //If player lost, subtracts the wager from their chips
            {
                wager = -wager;
            }
            return wager;
        }
    }
}
