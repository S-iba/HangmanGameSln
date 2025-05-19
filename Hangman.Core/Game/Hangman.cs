﻿using HangmanRenderer.Renderer;
using System;
using System.Security;


namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private Random rand = new Random();
        int numGallows = 6;
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
            int choice = 0;
            while (choice != 99)
            {
                numGallows = 6;
                Play();
                Console.WriteLine("Play? Please Enter any number \nTo Exit! Please Enter 99");
                choice = int.Parse(Console.ReadLine());
            }
        }

        private void Play()
        {   
            Console.Clear();
            _renderer.Render(5, 5, numGallows);
            string guess = PickWord(); //gets the word picked
            guess.ToUpper();
            string blanks = GetSpaces(guess);       //gets the required number of spaces needed for the word

            while (RemainingBlanks(blanks) != 0 && numGallows > 0)
            {
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your current guess: ");
                Console.WriteLine(blanks);
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                string oldBlanks = blanks;

                Console.Write("What is your next guess: ");
                char nextGuess = char.Parse(Console.ReadLine());
                Fill(ref blanks, guess, nextGuess);

                if (oldBlanks == blanks)
                {
                    numGallows--;
                    _renderer.Render(5,5,numGallows);
                }
                    
            }
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Your current guess: ");
            Console.WriteLine(blanks);
            Console.SetCursorPosition(0, 15);

            if (numGallows != 0)
            {
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("Congratulations, You have won!!!");
            }
            else {
                Console.SetCursorPosition(0, 17);
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Sorry, You L.O.S.T!!!");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"The word you were looking for is: {guess}");
            }
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
            //Console.WriteLine(blanks);
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
