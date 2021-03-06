﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class Program {
        const int MaxGuesses = 7;
        int NbrOfGuesses = MaxGuesses;
    
      int GenerateMagicNumber(int HighestNumber){
            Random rnd = new Random();
            var MagicNumber = rnd.Next(HighestNumber+1);
            //this is commented out to keep from revealing the magic number >> Debug($" The magic number is { MagicNumber}");
            return MagicNumber;
        }
        int AskForTheGuess() {
            NbrOfGuesses--; // same as NbrOfGuesses = NbrOfGuesses -1;
            Console.Write($"Enter your guess : ");
            var TheGuess = Console.ReadLine();
            int GuessNumber = int.Parse(TheGuess);
            return GuessNumber;
        }
        int CompareGuessToMagicNumber(int MagicNumber, int TheGuess){
            if (MagicNumber == TheGuess){ // is the guesss correct?            {
                return 0;
                   }
            if (MagicNumber > TheGuess)
            { //guess is too low
                return -1;
            }
            if (TheGuess > MagicNumber) { //guess is too high
                
                    return 1;
                
            }
            return -2;
        }
        bool PrintOutcomeResult(int result) {
            if (result == 0){ //the guess matched - they won
                Debug("Correct! - You Won!");
                return true;
            }
            if (result== -1){ //the guess is too low
                Debug($"Too Low. You have {NbrOfGuesses} guesses remaining.");
                if (NbrOfGuesses == 0) {
                    Debug("You're out of guesses -you lose!");
                return false;
                }
            }
            if (result == 1)
            { //the guess is too high
                Debug($"Too High.  You have {NbrOfGuesses} guesses remaining.");
                if (NbrOfGuesses == 0)
                {
                    Debug("You're out of guesses -you lose!");


                    return false;
                }
            }
            return true;          
        }
        void Debug(string message){
          Console.WriteLine(message);
        }
        void RunGameOnce(){
            NbrOfGuesses = MaxGuesses;
            var MagicNumber = GenerateMagicNumber(100);
            bool GameOver = false;
            while (GameOver== false) {
                var UserGuess = AskForTheGuess();
                var GuessResult = CompareGuessToMagicNumber(MagicNumber, UserGuess);
                 GameOver = PrintOutcomeResult(GuessResult);
                }
            }
        void Run() { 
            bool PlayAgain = true;
            while (PlayAgain == true) {
                RunGameOnce();
                Console.Write($"Do you want to play again? Y/N : ");
                var answer = Console.ReadLine();
                if (answer == "Y" || answer == "y"){
                    PlayAgain = true;
                }
                else{
                    PlayAgain = false;
                }
            }
        }
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
