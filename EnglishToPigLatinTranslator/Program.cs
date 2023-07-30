//https://edabit.com/challenge/uhsik73PY7Y2XftzG

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EnglishToPigLatinTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TranslateWord(""));
            Console.WriteLine(TranslateSentence(@"He said, ""When will this all end?"""));
        }

        public static string TranslateWord(string word)
        {
            if (word.Length == 0) return "";

            char[] vowels = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            string newWord;

            string targetWord = word;

            int alphaCharacterStart = 0;

            if (!Regex.IsMatch(targetWord.Substring(0, 1), @"^[a-zA-Z]+$"))
            {
                for (int i = 0; i < targetWord.Length; i++)
                {
                    if (alphaCharacterStart == 0 && Regex.IsMatch(targetWord.Substring(i, 1), @"^[a-zA-Z]+$"))
                    {
                        alphaCharacterStart = i;
                    }
                }
            }

            int alphaCharacterEnd = 0;

            for (int i = targetWord.Length - 1; i >= 0; i--)
            {
                if (alphaCharacterEnd == 0 && Regex.IsMatch(targetWord.Substring(i, 1), @"^[a-zA-Z]+$"))
                {
                    alphaCharacterEnd = i;
                }
            }

            targetWord = targetWord.Substring(alphaCharacterStart, targetWord.Length - alphaCharacterStart - (targetWord.Length - alphaCharacterEnd - 1));

            if (vowels.Contains(targetWord.ToCharArray()[0]))
            {
                newWord = targetWord + "yay";
            }

            else
            {
                int vowelPosition = 0;

                for (int i = 0; i < targetWord.Length; i++)
                {
                    if (vowelPosition == 0 && vowels.Contains(targetWord[i]))
                    {
                        vowelPosition = i;
                    }
                }

                newWord = targetWord.Substring(vowelPosition, targetWord.Length - vowelPosition) + targetWord.Substring(0, vowelPosition) + "ay";
            }

            newWord = newWord.ToLower();

            if (Regex.IsMatch(targetWord.Substring(0, 1), @"^[A-Z]+$"))
            {
                newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1, newWord.Length - 1);
            }

            newWord = word.Substring(0, alphaCharacterStart) + newWord + word.Substring(alphaCharacterEnd + 1, word.Length - alphaCharacterEnd - 1);

            return newWord;
        }

        public static string TranslateSentence(string sentence)
        {
            return string.Join(" ", sentence.Split(' ').Select(TranslateWord).ToArray()).TrimEnd();
        }
    }
}