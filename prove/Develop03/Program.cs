using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a single word in the scripture
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public void Reveal(string newText)
        {
            Text = newText;
            IsHidden = false;
        }

        public override string ToString()
        {
            return IsHidden ? "_____" : Text;
        }
    }

    // Represents the reference of the scripture
    public class Reference
    {
        public string Text { get; private set; }

        public Reference(string text)
        {
            Text = text;
        }
    }

    // Represents the scripture itself
    public class Scripture
    {
        public Reference Reference { get; private set; }
        public List<Word> Words { get; private set; }

        public Scripture(string referenceText, string scriptureText)
        {
            Reference = new Reference(referenceText);
            Words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                if (Words.All(word => word.IsHidden)) break;

                int index;
                do
                {
                    index = rand.Next(Words.Count);
                } while (Words[index].IsHidden);

                Words[index].Hide();
            }
        }

        public void Display()
        {
            Console.WriteLine($"{Reference.Text}: {string.Join(" ", Words)}");
        }

        public List<string> GenerateQuizOptions(int hiddenWordIndex)
        {
            Random rand = new Random();
            HashSet<string> options = new HashSet<string>();

            // Get the hidden word to generate options for
            string hiddenWord = Words[hiddenWordIndex].Text;

            // Add the hidden word as one of the options
            options.Add(hiddenWord);

            // Generate random options (ensure they are not duplicates)
            while (options.Count < 4) // Assuming 4 options
            {
                int randomIndex = rand.Next(Words.Count);
                if (!Words[randomIndex].IsHidden && !options.Contains(Words[randomIndex].Text))
                {
                    options.Add(Words[randomIndex].Text);
                }
            }

            return options.OrderBy(x => rand.Next()).ToList(); // Shuffle options
        }
    }

    // Main program class
    public class Program
    {
        static void Main(string[] args)
        {
            var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

            int hiddenWordCount = 1; // Number of words to hide each time
            int totalWords = scripture.Words.Count;
            int quizCount = 0;

            while (true)
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit") break;

                scripture.HideRandomWords(hiddenWordCount); // Hide one random word
                quizCount++;

                // Only ask a quiz if some words are hidden
                if (quizCount <= totalWords / hiddenWordCount)
                {
                    // Get the index of the hidden word
                    int hiddenWordIndex = scripture.Words.FindIndex(w => w.IsHidden);
                    List<string> quizOptions = scripture.GenerateQuizOptions(hiddenWordIndex);

                    Console.Clear();
                    Console.WriteLine("Fill in the blank:");
                    Console.WriteLine($"The verse contains: {string.Join(" ", scripture.Words.Select(w => w.IsHidden ? "_____" : w.Text))}");

                    Console.WriteLine($"What is the missing word? Options: {string.Join(", ", quizOptions)}");
                    string answer = Console.ReadLine();

                    // Check if the answer is correct
                    if (answer.Equals(scripture.Words[hiddenWordIndex].Text, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Correct!");
                        scripture.Words[hiddenWordIndex].Reveal(answer); // Reveal the word with the user's answer
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect! The correct answer was: {scripture.Words[hiddenWordIndex].Text}");
                    }

                    // Pause before the next round
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
