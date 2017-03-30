using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pete Rossman
//Grand Circus .NET Bootcamp Lab 6
//March 30, 2017

namespace GC_Lab6_PigLatinTranslator
{
    //This program takes a word in English and translates it to Pig Latin.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine("\nEnter a word to be translated: ");
            string word = Console.ReadLine();
            word = word.ToLower();
            char firstLetter = word[0];
            bool isVowel = "aeiouAEIOU".IndexOf(firstLetter) >= 0;
            if (isVowel == true)
            {
                Console.WriteLine(word + "way");
            }
            else
            {
                string newWord = word.Remove(0, 1);
                Console.WriteLine(newWord + firstLetter + "way");
            }
            Console.ReadLine();
        }
    }
}
