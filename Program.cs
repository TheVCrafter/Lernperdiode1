using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.IO;
using System.Threading;
using System.Media;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isgamerestarting = true;
            while (isgamerestarting)
            {
                SoundPlayer Titlemusic = new SoundPlayer("Titlemusic.wav");
                Titlemusic.PlayLooping();
                bool isUserinputcorrect = false;
                bool inputright = true;
                while (!isUserinputcorrect)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(Hangmanbanner);
                    Console.WriteLine();
                    if (!inputright)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Input! Try again!");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press S to start: ");
                    string input1 = Console.ReadLine();
                    SoundPlayer Gamestart = new SoundPlayer("gamestart.wav");
                    if (input1 == "S" || input1 == "s")
                    {
                        inputright = true;
                        Gamestart.Play();
                        break;
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                        inputright = false;
                    }
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Starting game...");
                Thread.Sleep(2000);
                SoundPlayer wrong = new SoundPlayer("wrong.wav");
                SoundPlayer right = new SoundPlayer("right.wav");
                Console.Clear();
                string Word = GetRandomLine("wortliste.txt");
                string WORD = Word.ToUpper();
                char[] guessedWord = new string('_', Word.Length).ToCharArray();
                bool gamefinished = false;
                int lives = 7;
                string Hangman;
                string guessedLetters = "";
                bool inputincorrect = false;
                char guessedLetter;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(guessedWord);
                while (!gamefinished)
                {
                    guessedLetter = '\0';
                    Console.Write("Enter a letter: ");
                    Hangman = GetHangmanArt(lives);
                    string inputword = Console.ReadLine();
                    string inputletter = inputword.ToUpper();
                    if (inputletter.Length == 1)
                    {
                        guessedLetter = Convert.ToChar(inputletter);
                        inputincorrect = false;
                    }
                    else if (inputword == WORD)
                    {
                        inputincorrect = false;
                    }
                    else
                    {
                        inputincorrect = true;
                    }
                    bool Letternotguessed = true;
                    bool letterFound = false;
                    for (int i = 0; i < Word.Length; i++)
                    {
                        if (Word[i] == char.ToLower(guessedLetter))
                        {
                            right.Play();
                            guessedWord[i] = char.ToUpper(guessedLetter);
                            letterFound = true;
                            Console.Clear();
                            Console.WriteLine();
                        }
                        else
                        {
                            guessedLetter = char.ToUpper(guessedLetter);
                            if (Word[i] == guessedLetter)
                            {
                                right.Play();
                                guessedWord[i] = guessedLetter;
                                letterFound = true;
                                Console.Clear();
                                Console.WriteLine();
                            }
                        }
                    }

                    for (int i = 0; i < guessedLetters.Length; i++)
                    {
                        if (guessedLetters[i] == guessedLetter)
                        {
                            Letternotguessed = false;
                        }
                    }
                    if (inputincorrect)
                    {
                        letterFound = true;
                        Letternotguessed = true;
                        wrong.Play();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong! This is not the correct Word!");
                        lives -= 1;
                    }
                    if (!inputincorrect)
                    {
                        guessedLetters += char.ToUpper(guessedLetter);
                        guessedLetters += ", ";
                    }
                    if (!letterFound)
                    {
                        wrong.Play();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong! The Word doesn't contain this Letter!");
                        lives -= 1;
                        Hangman = GetHangmanArt(lives);
                        if (lives == 0)
                        {
                            SoundPlayer lost = new SoundPlayer("lost.wav");
                            lost.Play();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(GameOver);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("The Word was: " + Word);
                            Console.Write("press R to restart or any other Letter to end the Game: ");
                            break;
                        }
                    }
                    if (!Letternotguessed)
                    {
                        wrong.Play();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have already guessed this letter!");
                        lives -= 1;
                        Hangman = GetHangmanArt(lives);
                        if (lives == 0)
                        {
                            SoundPlayer lost = new SoundPlayer("lost.wav");
                            lost.Play();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(GameOver);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("The Word was: " + Word);
                            Console.Write("press R to restart or any other Letter to end the Game: ");
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Hangman);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new string(guessedWord));
                    Console.WriteLine("Guessed Letters: " + guessedLetters);
                    if (new string(guessedWord) == WORD)
                    {
                        SoundPlayer Win = new SoundPlayer("win.wav");
                        Win.Play();
                        gamefinished = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Congratulations);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have guessed the Word");
                        Console.Write("press R to restart or any other Letter to end the Game: ");
                        gamefinished = true;
                    }
                    if (inputword.ToUpper() == WORD)
                    {
                        SoundPlayer Win = new SoundPlayer("win.wav");
                        Win.Play();
                        gamefinished = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Congratulations);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have guessed the Word");
                        Console.Write("press R to restart or any other Letter to end the Game: ");
                        gamefinished = true;
                    }

                }
                string input = Console.ReadLine();
                if (input == "R")
                {
                    Console.Clear();
                    Console.WriteLine("Restarting Game.......");
                    Thread.Sleep(3000);
                    Console.Clear();
                    guessedLetters = "";
                }
                else if (input == "r")
                {
                    Console.Clear();
                    Console.WriteLine("Restarting Game.......");
                    Thread.Sleep(3000);
                    Console.Clear();
                    guessedLetters = "";
                }
                else
                {
                    isgamerestarting = false;
                }
            }




        }
        static string GetRandomLine(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Random rnd = new Random();
            int randomIndex = rnd.Next(lines.Length);
            return lines[randomIndex];
        }
        static string GetHangmanArt(int lives)
        {
            string[] hangmanArt = {
            @"",
            @"
  +---+
  |   |
      |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
        };
            return hangmanArt[7 - lives];
        }

        static string Hangmanbanner = @" 
 _    _                                         
| |  | |                                        
| |__| | __ _ _ __   __ _ _ __ ___   __ _ _ __  
|  __  |/ _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| |  | | (_| | | | | (_| | | | | | | (_| | | | |
|_|  |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                     __/ |                      
                    |___/ ";
        static string GameOver = @"  
  _____                         ____                 
 / ____|                       / __ \                
| |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
| | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
| |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
 \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|";
        static string Congratulations = @"
  _____                            _         _       _   _                 
 / ____|                          | |       | |     | | (_)                
| |     ___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_ _  ___  _ __  ___ 
| |    / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __|
| |___| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \
 \_____\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/
                    __/ |                                                  
                   |___/ ";
    }

}
