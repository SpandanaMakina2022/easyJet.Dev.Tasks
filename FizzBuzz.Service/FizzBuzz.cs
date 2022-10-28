using System;
using System.Collections.Generic;

namespace FizzBuzz.Service
{
    public class FizzBuzzGame
    {
        public string[] Run(int start, int end)
        {
            try
            {
                if (start >= end)
                {
                    return null;
                }

                string[] results = new string[(end - start) + 1];

                for (int i = start, j = 0; i < end + 1; i++, j++)
                {
                    if (i % 15 == 0)
                        results[j] = "FizzBuzz";
                    else if (i % 3 == 0)
                        results[j] = "Fizz";
                    else if (i % 5 == 0)
                        results[j] = "Buzz";
                    else
                        results[j] = i.ToString();
                }

                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
