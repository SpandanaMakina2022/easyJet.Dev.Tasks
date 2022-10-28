using Craps.Service;
using System;
using System.Linq;

namespace easyJet.Dev.Tasks
{
    class Craps
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("====== easyJet Craps Game Simulator =====");

                int numberOfGames = GetGameCount();
               
                int[][] gameResults = new CrapsGameSimulator().RunSimulator(numberOfGames);
                int[] resultRolls = gameResults[0];
                int[] results = gameResults[1];

                Console.WriteLine();
                Console.WriteLine("Your game statistics: ");
                Console.WriteLine("--------------------- ");

                Console.WriteLine("The average number rolls per game : {0}", (resultRolls.Length) / numberOfGames);

                Console.WriteLine("The highest number of rolls : {0}", resultRolls.Max());

                Console.WriteLine("The lowest number of rolls : {0}", resultRolls.Min());

                Console.WriteLine("The most common roll : {0}", GetCommon(resultRolls));

                Console.WriteLine("The average winning percentage : {0}", (results.Where(r => r == 1)?.Count() * 100) / results.Length);

                Console.WriteLine("The number of wins : {0}", results.Where(r => r == 1)?.Count() ?? 0);

                Console.WriteLine("The number of losses : {0}", results.Where(r => r == 0)?.Count() ?? 0);

                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Do you want to continue the game (Y/N)");
                
            } while (Console.ReadKey().KeyChar.ToString().ToUpper() == "Y");
                                    
        }

        /// <summary>
        /// Allows gamer to enter the number of games they want to play
        /// </summary>
        /// <returns></returns>
        private static int GetGameCount()
        {
            Console.WriteLine("Enter No. of games you want to play: ");

            string gameCount = Console.ReadLine();

            while (string.IsNullOrEmpty(gameCount))
            {
                Console.WriteLine("Enter No. of games you want to play: ");
                gameCount = Console.ReadLine();
            }


            if (int.TryParse(gameCount, out int number))
            {
                return number;
            }

            Console.WriteLine("Please enter a valid number");

            return GetGameCount();
        }

        /// <summary>
        /// Gets the common dice roll from all the games
        /// </summary>
        /// <param name="array">array of all the dice rolls from all the games</param>
        /// <returns></returns>
        private static int GetCommon(int[] array)
        {            
            var results = array.GroupBy(a => a).Select(g => new { g.Key, Common = g.Count() });
            results = results.OrderByDescending(r => r.Common);

            return results.FirstOrDefault().Key;
        }
    }
}
