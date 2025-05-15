using HangmanRenderer.Renderer;
using System;


namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private Random rand = new Random();
        private const string none = "-";
        char[] arrGuess;
        private string[] words = {
            "Easy",
            "Xenophobia",
            "onomatopoeia",
            "Samsung",
            "China",
            "Insomnia",
            "Infinite",
            "Glutony",
            "Identity",
            "Neuroscience",
            "Inconsistency",
            "Phlebotomy",
            "oesophogus",
            "Supercalifragilisticexpialidocious",
            "Mannequin",
            "Singularity",
            "Gaussian",
            "Electromagnetic",
            "Interpolation",
            "Oogenesis",
            "Ovulation"
        };
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            _renderer.Render(5, 5, 6);

        }

        private void Play()
        {
            string guess = PickWord(); //gets the word picked
            string blanks = GetSpaces(guess);       //gets the required number of spaces needed for the word

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Your current guess: ");
            Console.WriteLine(blanks);
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();
        }

        private void Fill(ref string blanks, string guess,char nextGuess)
        {
            arrGuess = guess.ToCharArray();

            for (int i = 0; i < blanks.Length; i++) {
                if (arrGuess[i] == nextGuess)
                {
                    blanks[i]= nextGuess;
                }
                }
        }

        private string PickWord()
        {
            string tempWord = string.Empty;
            int num = rand.Next(20);
            tempWord = words[num];
            return tempWord;
        }

        private string GetSpaces(string word)
        {
            string newStr = string.Empty;

            int len = word.Length;

            for (int i = 0; i < len; i++)
            {
                newStr += none;
            }

            return newStr;
        }
    }
}
