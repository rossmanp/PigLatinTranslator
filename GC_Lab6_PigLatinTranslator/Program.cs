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
    //This program takes a word or sentence in English and translates it to Pig Latin.

    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            char[] delimiterChars = { ' ' };           
            string word = "";

            //This array is used to detect if a word contains symbols.
            //If a word does contain one of the symbols in the array, it is not translated.
            char[] symbols = "@#$%^&*()".ToCharArray();

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            //This loop is run until the user inputs a character, word, or sentence.

            while (run)
            {
                Console.WriteLine("\nEnter a word or sentence to be translated: ");
                word = Console.ReadLine();
                if (word.Equals(""))
                {
                    Console.WriteLine("You did not input anything! Please try again.");
                }
                else
                {
                    run = false;
                }
            }

            //The input is converted to lowercase and split into words.
            word = word.ToLower();
            string[] words = word.Split(delimiterChars);
            Console.Write("The Pig Latin translation is: ");

            //The foreach loop detects if each word starts with a vowel or consonant,
            //as well as if there are any numbers or symbols in the word.

            foreach (string s in words)
            {
                char firstLetter = s[0];
                bool isVowel = "aeiouAEIOU".IndexOf(firstLetter) >= 0;
                int indexOf = s.IndexOfAny(symbols);
                if (indexOf > -1 || s.Any(char.IsDigit))
                {
                    Console.Write(s + " ");
                }                                                                                        
                else if (isVowel == true)
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
                        Console.Write(newWord.Substring(0, newWord.Length - 1) + 
                        firstLetter + "way" + newWord[newWord.Length - 1] + " ");
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
