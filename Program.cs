using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.IO;
using System.Threading;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                while (true)
                {
                    Console.WriteLine(Hangmanbanner);
                    Console.Write("Press S to start: ");
                    string input1 = Console.ReadLine();
                    if (input1 == "S")
                    {
                        break;
                    }
                    else if (input1  == "s")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input. Try again!");
                        Console.Clear();
                    }
                }
                Console.Clear();
                string DeutscheWörter = @"C:\Users\Public\Documents\wortliste.txt";
                string Wort = GetRandomLine(DeutscheWörter);
                string WORT = Wort.ToUpper();
                char[] guessedWord = new string('_', Wort.Length).ToCharArray();
                bool einfach = false;
                int lives = 7;
                string Hangman;
                Console.WriteLine(guessedWord);
                while (!einfach)
                {
                    Console.Write("Enter a letter: ");
                    Hangman = GetHangmanArt(lives);
                    Console.WriteLine(Hangman);
                    char guessedLetter = Console.ReadLine()[0];
                    bool letterFound = false;
                    for (int i = 0; i < Wort.Length; i++)
                    {
                        if (Wort[i] == char.ToLower(guessedLetter))
                        {
                            guessedWord[i] = char.ToUpper(guessedLetter);
                            letterFound = true;
                            Console.Clear();
                        }
                        else
                        {
                            guessedLetter = char.ToUpper(guessedLetter);
                            if (Wort[i] == guessedLetter)
                            {
                                guessedWord[i] = guessedLetter;
                                letterFound = true;
                                Console.Clear();
                            }
                        }
                    }

                    if (!letterFound)
                    {
                        Console.Clear();
                        Console.WriteLine("Falsch!");
                        lives -= 1;
                        Hangman = GetHangmanArt(lives);
                        if (lives == 0)
                        {
                            Console.Clear();
                            Console.WriteLine(GameOver);
                            Console.WriteLine("The Word was: " + Wort);
                            Console.Write("press R to restart or any other Letter to end the Game: ");
                            break;
                        }
                    }

                    Console.WriteLine(new string(guessedWord));

                    if (new string(guessedWord) == WORT)
                    {
                        einfach = true;
                        Console.Clear();
                        Console.WriteLine(Congratulations);
                        Console.WriteLine("You have guessed the Word");
                        Console.Write("press R to restart or any other Letter to end the Game: ");
                        break;
                    }

                }
                string input = Console.ReadLine();
                if (input == "R")
                {
                    Console.Clear ();
                    Console.WriteLine("Restarting Game.......");
                    Thread.Sleep(3000);
                    Console.Clear() ;
                }
                else if (input == "r")
                {
                    Console.Clear();
                    Console.WriteLine("Restarting Game.......");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    break;
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
