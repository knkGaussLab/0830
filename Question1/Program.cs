using System;
using System.Collections.Generic;
using System.Text;

namespace GaussLabQuestion1
{
    class List<T>   //Generic class but only works for strings
    {
        private int currSize = 0;
        private string[] data = new string[10];
        private Dictionary<char, int> counts = new Dictionary<char, int>();
        public void Add(string toAdd)
        {
            if(currSize >= data.Length) //Checks if internal data array needs resizing
            {
                string[] doubledData = new string[data.Length * 2];
                data.CopyTo(doubledData, 0);
                data = doubledData;                
            }            
            data[currSize] = toAdd;
            currSize++;

            char[] toAddChar = toAdd.ToCharArray(); //Update counts of letters 
            for(int i=0; i<toAddChar.Length; i++)
            {
                if (counts.ContainsKey(toAddChar[i]))
                    counts[toAddChar[i]] = counts[toAddChar[i]] + 1;
                else
                    counts[toAddChar[i]] = 1;
            }
        }

        public string ReverseSumAll()
        {
            StringBuilder sb = new StringBuilder(); //Use StringBuilder as strings are immutable in C#
            for (int i = 0; i < currSize; i++)
            {
                char[] currWord = data[i].ToCharArray();
                for (int j = currWord.Length - 1; j >= 0; j--)
                {
                    sb.Append(currWord[j]);
                }
            }
            return sb.ToString();
        }

        public int CountAll(string toCount) // Upper case and lower case letters will be counted separately - Only works when parameter is a single letter
        {
            if (counts.ContainsKey(toCount[0]))
                return counts[toCount[0]];
            else
                return 0;
        }        
    }

    class Runner
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>();
            fruits.Add("apple");
            fruits.Add("banana");
            fruits.Add("cranberry");

            // sum1 expected: elppaananabyrrebnarc
            string sum1 = fruits.ReverseSumAll();

            // count1 expected: 5
            int count1 = fruits.CountAll("a");

            Console.WriteLine("ReverseSumAll() returned... " + sum1);
            Console.WriteLine("CountAll() returned... " + count1);
            Console.ReadLine();
        }
    }
}
