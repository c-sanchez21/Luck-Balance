using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
HackerRank Challenge: Luck Balance - https://www.hackerrank.com/challenges/luck-balance/problem
Lena is preparing for an important coding competition 
that is preceded by sequential preliminary contests.
She believes in "saving luck", and wants to check her theory.
Each contest is described by two integers, Li and Ti :
Li is the amount of luck that can be gained by winning the contest. 
If Lena wins the contest, her luck balance will decrease by Li ; 
if she loses it, her luck balance will increase by Li.
Ti denotes the contest's importance rating.
It's equal to 1 if the contest is important, and it's equal to 0 if it's unimportant.
If Lena loses no more than k important contests, 
what is the maximum amount of luck she can have after competing in all the preliminary contests?
This value may be negative.
*/
namespace Luck_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int k = 3;

            //Key value pairs
            int[][] kvp = new int[][] {new int[] {5,1}, new int[] { 2, 1 }, new int[] {1,1},
                                        new int[] {8,1 }, new int[] {10,0 }, new int[] {5,0 } };                                    
            IOrderedEnumerable<int[]> orderedPair =  kvp.OrderByDescending(x => x[0]); //Sort pairs by their luck, highest first;          
            int lost = 0;//Count of important contest lost;
            int luck = 0; 
            foreach(int[] a in orderedPair)
            {
                if (a[1] == 0) //Not Important so store luck
                    luck += a[0];
                else if (lost < k)//If important and we can still lose then store luck
                {
                    luck += a[0];
                    lost++;
                }
                else luck -= a[0];//Have to use stored luck.        
            }
            Console.WriteLine(luck);//Output our total stored luck
            Console.ReadKey();
        }
    }
}
