using HangmanRenderer.Renderer;
using System;
using System.Security;


namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private Random rand = new Random();
        private const string none = "-";
        char[] arrGuess;
        char[] tempStr;
        private string[] words = {
            "EASY",
            "XENOPHOBIA",
            "ONOMATOPOEIA",
            "SAMSUNG",
            "CHINA",
            "INSOMNIA",
            "INFINITE",
            "GLUTONNY",
            "IDENTITY",
            "NEUROSCIENCE",
            "INCONSISTENCY",
            "PHLEBOTOMY",
            "OESOPHAGUS",
            "SUPERCALIGRAGILISTICEXPIALIDOCOIUS",
            "MANNEQUIN",
            "SINGULARITY",
            "GAUSSIAN",
            "ELECTROMAGNETIC",
            "INTERPOLATION",
            "OOGENESIS",
            "OVULATION"
        };
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            _renderer.Render(5, 5, 6);
            Play();
        }

        private void Play()
        {
            string guess = PickWord(); //gets the word picked
            guess.ToUpper();
            string blanks = GetSpaces(guess);       //gets the required number of spaces needed for the word

            while (RemainingBlanks(blanks) != 0)
            {
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your current guess: ");
                Console.WriteLine(blanks);
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                char nextGuess = char.Parse(Console.ReadLine());
                Fill(ref blanks, guess, nextGuess);
            }
            Console.WriteLine("You have won!!!");
        }

        private int RemainingBlanks(string blanks)
        {
            char[] counter = blanks.ToCharArray();
            int count = 0;
            foreach (char c in counter)
            {
                if (c == '-')
                    count++;
            }
            return count;
        }

        private void Fill(ref string blanks, string guess,char nextGuess)
        {
            arrGuess = guess.ToCharArray();
            tempStr = blanks.ToCharArray();
            for (int i = 0; i < blanks.Length; i++) {
                if (arrGuess[i] == nextGuess)
                {
                    tempStr[i] = nextGuess;
                }
            }
            
            string temp = string.Empty;
            foreach (char c in tempStr)
            {
                temp += c;
            }
            blanks = temp;
            Console.WriteLine(blanks);
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
