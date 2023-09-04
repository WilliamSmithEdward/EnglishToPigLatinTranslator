# EnglishToPigLatinTranslator
This program is designed to translate English words and sentences into Pig Latin.

https://edabit.com/challenge/uhsik73PY7Y2XftzG

## Summary

The program is designed to translate English into Pig Latin. It consists of two main algorithms: one for translating individual words and another for processing entire sentences.

The TranslateWord algorithm manages the translation of singular words. It identifies the beginning of the actual word, separating it from any surrounding non-alphabetic characters. It then categorizes the word based on its starting character: vowel or consonant. The word is then transformed according to Pig Latin rules, ensuring that its original format, especially punctuation, remains intact.

Subsequently, the TranslateSentence algorithm decomposes a given sentence into its constituent words, applies the TranslateWord algorithm to each word, and then reconstructs the sentence in Pig Latin, preserving the original spacing between words. When executed, the program demonstrates its functionality by translating predefined text samples.

## Methods

#### `TranslateWord(string word)`

Takes a single English word and translates it into Pig Latin.

* If the word is empty, it immediately returns an empty string.
* An array of vowels (both uppercase and lowercase) is defined for reference in later steps.
* If the word starts with a non-alphabetic character, the code determines the starting and ending position of the alphabetic substring within the word. This helps in preserving punctuation or other symbols.
* If the word starts with a vowel, it appends "yay" to the word.
* If the word starts with a consonant, it determines the position of the first vowel. Then, it rearranges the word by moving the initial consonant cluster to the end and appending "ay".
* The word is converted to lowercase. If the original word started with a capital letter, the translated word's first letter is capitalized. Non-alphabetic characters from the original word (e.g., punctuation) are reattached to their original positions.

#### `TranslateSentence(string sentence)`

Translates an entire sentence into Pig Latin by splitting the sentence into individual words, translating each word, and then joining them back together.

* The method uses the Split(' ') function to break down the sentence into individual words based on spaces.
* After splitting the sentence, it utilizes the Select LINQ extension method to iterate over each word in the resulting array and translate it using the previously defined TranslateWord method.
* Once each word in the sentence has been translated, the string.Join method is used to combine the words back into a sentence. Spaces (' ') are used as the delimiter.
* The TrimEnd() function is applied at the end to ensure there are no trailing spaces in the returned translated sentence.

## Example

The following example implementation will prompt the user with the message: "Enter a word or sentence for translation:" The user can then type in either a single word or an entire sentence.

Once the user inputs the text and hits enter:

  * If the input is a single word, the TranslateWord function is called to translate this word to Pig Latin.
  * If the input contains multiple words (i.e., it's a sentence), the TranslateSentence function is called, which in turn breaks down the sentence into individual words and translates each word using the TranslateWord function.
  * It then reconstructs the sentence with the translated words.
  * After translating the input, the program displays the translated text in Pig Latin on the screen.

```csharp
static void Main(string[] args)
{
    Console.WriteLine("Enter a word or sentence for translation:");
    string input = Console.ReadLine();
    
    if (input.Contains(" "))
    {
        Console.WriteLine(TranslateSentence(input));
    }
    else
    {
        Console.WriteLine(TranslateWord(input));
    }

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```
