using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightedString
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong weight = Convert.ToUInt64(Console.ReadLine().Trim());

            string result = Result.smallestString(weight);
            Console.WriteLine(result);
        }
    }

    class Result
    {

        /*
         * Complete the 'smallestString' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts LONG_INTEGER weight as parameter.
         */

        static Dictionary<char, ulong> dic = null;

        public static string smallestString(ulong weight)
        {
            dic = new Dictionary<char, ulong>
            {
                { 'A', 1 }
            };

            for (int i = 1; i < 26; i++)
            {
                char k = Convert.ToChar(65 + i);
                char prev = Convert.ToChar(65 + i - 1);                
                dic[k] = dic[prev] * (ulong)(i + 2);
            }

            StringBuilder retString = new StringBuilder();
            ulong sum = 0;
            do
            {
                char k = default;                
                k = dic.Last(x => x.Value <= (weight - sum)).Key;
                retString.Append(k);
                sum = getTotWeight(retString.ToString());
            } while (sum != weight);
            
            return retString.ToString();
        }

        public static ulong getTotWeight(string input)
        {
            ulong retTot = 0;            

            foreach (char c in input)
            {
                if (dic.TryGetValue(c, out ulong v))
                {
                    retTot += v;
                }
            }
            return retTot;
        }

    }
}
