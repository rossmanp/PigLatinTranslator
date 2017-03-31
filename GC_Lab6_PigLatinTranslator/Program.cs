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
            char[] delimiterChars = { ' ' };
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine("\nEnter a word or sentence to be translated: ");
            string word = Console.ReadLine();
            word = word.ToLower();
            string[] words = word.Split(delimiterChars);
            foreach (string s in words)
            {
                char firstLetter = s[0];
                bool isVowel = "aeiouAEIOU".IndexOf(firstLetter) >= 0;
                if (isVowel == true)
                {
                    if (Char.IsPunctuation(s[s.Length - 1]))
                    {
                        Console.Write(s.Substring(0, s.Length - 1) + "way" + s[s.Length - 1] + " ");
                    }
                    else
                    {
                        Console.Write(s + "way" + " ");
                    }
                }
                else
                {
                    string newWord = s.Remove(0, 1);
                    if (Char.IsPunctuation(newWord[newWord.Length - 1]))
                    {
                        Console.Write(newWord.Substring(0, newWord.Length - 1) + firstLetter + "way" + newWord[newWord.Length - 1] + " ");
                    }
                    else
                    {
                        
                        Console.Write(newWord + firstLetter + "way" + " ");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
