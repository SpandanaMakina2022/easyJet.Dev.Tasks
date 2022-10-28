using System;
using System.Collections.Generic;

namespace Craps.Service
{
    public class CrapsGameSimulator
    {
        //To generate random dice roll
        public Random random = new Random();
       
        public int[][] RunSimulator(int numberOfGames)
        {

            //2 in length:
            //1) to hold dice rolls (resultRolles),
            //2) the win/lose result per game (results)
            int[][] returnList = new int[2][]; 

            List<int> resultRolles = new  List<int>(); //holds each dice roll number from all the games played by the gamer/user
            int[] results = new int[numberOfGames]; // 0 - lose, 1 - win

            while (numberOfGames > 0)
            {
                int diceSum = GetDiceSum();

                int index = numberOfGames - 1;
                resultRolles.Add(diceSum);

                //dice sum for 2, 3, 12: shooter loses the game
                if (diceSum < 4 || diceSum == 12)
                {
                    results[index] = 0;
                }
                //dice sum for 7 or 11: shooter wins the game
                else if (diceSum == 7 || diceSum == 11)
                {
                    results[index] = 1;
                }
                //other number: points based game continues
                else
                {
                    while (true)
                    {
                        int diceNewSum = GetDiceSum(); //points based dice roll
                        resultRolles.Add(diceNewSum);

                        //the initial point (diceSum) is taken as reference for the shooter to win the game in points based round
                        if (diceSum == diceNewSum)
                        {
                            results[index] = 1;
                            break;
                        }
                        //shooter lose the game on dice roll of 7
                        else if (diceNewSum == 7)
                        {
                            results[index] = 0;
                            break;
                        }
                    }
                }

                //resultRolles.Add(0); //added as demiliter to understand whilst debugging

                --numberOfGames; //Get ready for next game: keeps track of games played
            }


            //resultRolles.RemoveAll(r => r == 0); //clear demiliter before posting back

            returnList[0] = resultRolles.ToArray();
            returnList[1] = results;

            return returnList;

            //Gets the sum of two 6 faced dice roll
            int GetDiceSum()
            {
                return random.Next(1, 7) + random.Next(1, 7);
            }
        }

    }
}
