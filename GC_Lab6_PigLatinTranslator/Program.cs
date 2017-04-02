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
            char[] symbols = "@#$%^+&*()".ToCharArray();

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
            string[] words = word.Split(delimiterChars);
            Console.Write("The Pig Latin translation is: ");

            //The foreach loop detects if each word starts with a vowel or consonant,
            //as well as if there are any numbers or symbols in the word.

            foreach (string s in words)
            {
                char firstLetter = s[0];
                string vowels = "aeiouAEIOU";
                bool isVowel = vowels.IndexOf(firstLetter) >= 0;
                int firstVowel = 0;
                bool vowelNotFound = true;
                while (vowelNotFound)
                {                 
                    foreach (char c in s)
                    {                   
                        if (vowels.Contains(c))
                        {
                            firstVowel = s.IndexOf(c);
                            vowelNotFound = false;
                        }
                    }
                }
                int indexOf = s.IndexOfAny(symbols);
                string way = "way";

                // If a word contains a symbol or a number, the word is not translated.

                if (indexOf > -1 || s.Any(char.IsDigit))
                {
                    Console.Write(s + " ");
                }
                
                //If the word starts with a vowel, "way" is appended to the word's end.
                //If a word ends with a punctuation mark, that mark is kept.
                                                                                                     
                else if (isVowel)
                {
                    if (IsAllUpper(s))
                    {
                        way = "WAY";
                    }
                    if (Char.IsPunctuation(s[s.Length - 1]))
                    {
                        Console.Write(s.Substring(0, s.Length - 1) + way + s[s.Length - 1] + " ");
                    }
                    else
                    {
                        Console.Write(s + way + " ");
                    }
                }

                //Translate a word beginning with a consonant to Pig Latin
                //by taking its first letter, placing at the end, and then 
                //adding "way". Any punctuation used at the end is maintained.

                else
                {
                    string firstPart = s.Substring(0, firstVowel);
                    firstPart = firstPart.ToLower();
                    string newWord = s.Remove(0, firstVowel);

                    if (Char.IsUpper(firstLetter) && !IsAllUpper(s))
                    {
                        firstLetter = Char.ToLower(firstLetter);
                        newWord = Char.ToUpper(newWord[0]) + newWord.Substring(1, newWord.Length - 1);                                              
                    }
                    if (IsAllUpper(s))
                    {
                        way = "WAY";
                    }
                    if (Char.IsPunctuation(newWord[newWord.Length - 1]))
                    {
                        Console.Write(newWord.Substring(0, newWord.Length - 1) + 
                        firstPart + way + newWord[newWord.Length - 1] + " ");
                    }                 
                    else
                    {
                        Console.Write(newWord + firstPart + way + " ");
                    }
                }
            }
            Console.ReadLine();
        }

        public static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

   
}
