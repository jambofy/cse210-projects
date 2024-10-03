using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a single word in the scripture
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Reveal(string newText)
        {
            _text = newText;
            _isHidden = false;
        }

        public override string ToString()
        {
            return _isHidden ? "_____" : _text;
        }

        public string GetText()
        {
            return _text;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }
    }

    // Represents the reference of the scripture
    public class Reference
    {
        private string _text;

        public Reference(string text)
        {
            _text = text;
        }

        public string GetReference()
        {
            return _text;
        }
    }

    // Represents the scripture itself
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(string referenceText, string scriptureText)
        {
            _reference = new Reference(referenceText);
            _words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
        }

        public List<Word> Words => _words; // Expose words as a read-only property

        public void HideRandomWords(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                // Check if all words are hidden
                if (_words.All(word => word.IsHidden())) break;

                int index;
                do
                {
                    index = rand.Next(_words.Count);
                } while (_words[index].IsHidden());

                _words[index].Hide();
            }
        }

        public void Display()
        {
            Console.WriteLine($"{_reference.GetReference()}: {string.Join(" ", _words)}");
        }
    }

    // Main program class
    public class Program
    {
        static void Main(string[] args)
        {
            var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

            int hiddenWordCount = 1; // Number of words to hide each time

            while (true)
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit") break;

                scripture.HideRandomWords(hiddenWordCount); // Hide one random word
            }
        }
    }
}
