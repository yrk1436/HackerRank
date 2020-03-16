using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'maximumClusterQuality' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY speed
     *  2. INTEGER_ARRAY reliability
     *  3. INTEGER maxMachines
     */

    static IEnumerable<IEnumerable<int>> powerSet;

    public static long maximumClusterQuality(List<int> speed, List<int> reliability, int maxMachines)
    {
        //make sure speed has unique numbers
        speed = speed.Distinct<int>().ToList();

        powerSet = from m in Enumerable.Range(0, 1 << speed.Count)
                   select
                       from i in Enumerable.Range(0, speed.Count)
                       where (m & (1 << i)) != 0
                       select speed[i];

        Dictionary<IEnumerable<int>, long> calcDic = new Dictionary<IEnumerable<int>, long>();
        for (int i = maxMachines; i > 0; i--)
        {
            IEnumerable<IEnumerable<int>> tempLists = from l in powerSet
                                                      where l.Count() == i
                                                      select l;

            foreach(var g in tempLists)
            {
                int minReliab = g.Select(x => reliability[speed.IndexOf(x)]).Min();
                calcDic[g] = g.Sum() * minReliab;
            }

        }

        return calcDic.Values.Max();
    }    
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        Console.WriteLine("Enter Total Available Machines Count - ");
        int speedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> speed = new List<int>();

        for (int i = 0; i < speedCount; i++)
        {
            Console.WriteLine("Enter Machine " + (i + 1) + " Speed - ");
            int speedItem = Convert.ToInt32(Console.ReadLine().Trim());
            speed.Add(speedItem);
        }

        //int reliabilityCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> reliability = new List<int>();

        for (int i = 0; i < speedCount; i++)
        {
            Console.WriteLine("Enter Machine " + (i + 1) + " Reliability - ");
            int reliabilityItem = Convert.ToInt32(Console.ReadLine().Trim());
            reliability.Add(reliabilityItem);
        }

        Console.WriteLine("Enter Max Number of Machines to use - ");
        int maxMachines = Convert.ToInt32(Console.ReadLine().Trim());

        long result = Result.maximumClusterQuality(speed, reliability, maxMachines);

        Console.WriteLine("Quality of the Cluster is - " + result);
        Console.ReadLine();
    }
}
