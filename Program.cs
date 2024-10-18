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
using System.Runtime.CompilerServices;

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
                GetUserInput(false);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Starting game...");
                Thread.Sleep(2000);
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
                    Console.SetCursorPosition(0, 4);
                    Console.Write("Enter a letter: ");
                    Hangman = GetHangmanArt(lives);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Hangman);
                    Console.SetCursorPosition(16, 4);
                    Console.ForegroundColor= ConsoleColor.White;
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
                            PlaySound("right.wav");
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
                                PlaySound("right.wav");
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
                        PlaySound("wrong.wav");
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong! This is not the correct Word!");
                        lives -= 1;
                        if (lives == 0)
                        {
                            PlaySound("lost.wav");
                            Console.Clear();
                            ColorWrite(GameOver, ConsoleColor.DarkRed, 1);
                            Console.WriteLine("The Word was: " + Word);
                            break;
                        }
                    }
                    if (!inputincorrect)
                    {
                        guessedLetters += char.ToUpper(guessedLetter);
                        guessedLetters += ", ";
                    }
                    if (!letterFound)
                    {
                        PlaySound("wrong.wav");
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong! The Word doesn't contain this Letter!");
                        lives -= 1;
                        Hangman = GetHangmanArt(lives);
                        if (lives == 0)
                        {
                            PlaySound("lost.wav");
                            Console.Clear();
                            ColorWrite(GameOver, ConsoleColor.DarkRed, 1);
                            Console.WriteLine("The Word was: " + Word);
                            break;
                        }
                    }
                    if (!Letternotguessed)
                    {
                        PlaySound("wrong.wav");
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have already guessed this letter!");
                        lives -= 1;
                        Hangman = GetHangmanArt(lives);
                        if (lives == 0)
                        {
                            PlaySound("lost.wav");
                            Console.Clear();
                            ColorWrite(GameOver, ConsoleColor.DarkRed, 1);
                            Console.WriteLine("The Word was: " + Word);
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new string(guessedWord));
                    Console.WriteLine();
                    Console.WriteLine("Guessed Letters: " + guessedLetters);
                    if (new string(guessedWord) == WORD)
                    {
                        PlaySound("win.wav");
                        gamefinished = true;
                        Console.Clear();
                        ColorWrite(Congratulations, ConsoleColor.Green, 1);
                        Console.WriteLine();
                        Console.WriteLine("You have guessed the Word");
                        gamefinished = true;
                    }
                    if (inputword.ToUpper() == WORD)
                    {
                        PlaySound("win.wav");
                        gamefinished = true;
                        Console.Clear();
                        ColorWrite(Congratulations, ConsoleColor.Green, 1);
                        Console.WriteLine();
                        Console.WriteLine("You have guessed the Word");
                        gamefinished = true;
                    }

                }
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("press R to restart or any other Letter to end the Game: ");
                string input = Console.ReadLine();
                if (input.Equals("R", StringComparison.OrdinalIgnoreCase))
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
        static void PlaySound(string soundFilePath)
        {
            SoundPlayer sound = new SoundPlayer(soundFilePath);
            sound.Play();
        }
        static void ColorWrite(string text, ConsoleColor color, int Position)
        {
            // 1. Speichere die derzeitige Farbe
            ConsoleColor current = Console.ForegroundColor;

            // 2. Setze die Farbe auf color
            Console.ForegroundColor = color;
            // 3. Schreibe text
            Console.Write(text);
            int topcursor = Console.CursorTop;
            Console.CursorTop = topcursor + Position;
            // 4. Setze die Farbe auf current
            Console.ForegroundColor = current;
        }
        static void GetUserInput(bool isUserinputcorrect)
        {
            int Counter = 0;
            while (!isUserinputcorrect)
            {
                ColorWrite(Hangmanbanner, ConsoleColor.DarkGray, 1);
                if (Counter > 0)
                {
                    Console.CursorLeft = 1;
                    ColorWrite("Wrong input, try again!", ConsoleColor.Red, 1);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.CursorLeft = 0;
                ColorWrite("Press S to Start: ", ConsoleColor.White, 0);
                string input1 = Console.ReadLine();
                if (input1 == "S" || input1 == "s")
                {
                    PlaySound("gamestart.wav");
                    isUserinputcorrect = true;
                }
                else
                {
                    Console.Clear();
                    isUserinputcorrect = false;
                }
                Counter++;
            }
        }
    }

}

