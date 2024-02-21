using Mastermind.ResourseStrings;
using System;
using System.Text.RegularExpressions;

namespace Mastermind.GameCore
{
    internal class MastermindGame
    {
        private const int _maxGuesses = Constants.Rules.GuessLimit;

        private readonly string[] _args;

        private int _remainingGuesses;
        private string _secretCode;

        public MastermindGame(string[] args)
        { 
            _args = args;
        }

        #region MainGame

        /// <summary>
        /// Initiates the start of the game
        /// </summary>
        internal void Start()
        {
            Console.WriteLine(GameStrings.StartGame_Introduction);

            // Game loop
            while (true)
            {
                // Start a new round
                StartRound(out bool shouldQuit);
                
                if (shouldQuit)
                {
                    break;
                }
            }

            Console.WriteLine(GameStrings.Exit);
        }

        private void StartRound(out bool shouldQuit)
        {
            // Initialize quit flag
            shouldQuit = false;

            // Initialize remaining guesses
            _remainingGuesses = _maxGuesses;

            // Get new generated code for this round 
            _secretCode = new SecretCodeGenerator().SecretCode;

            while (!IsGameOver())
            {
                // Prompt player for guess
                Console.Write(string.Format(GameStrings.Guess_Prompt, (_maxGuesses - _remainingGuesses) + 1, _maxGuesses));
                string guess = Console.ReadLine();

                // @TODO check if player wants to quit or see help menu

                try
                {
                    // Evaluate the guess
                    ProcessGuess(guess);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    // Prompt for guess again
                    continue;
                }
            }
        }

        #endregion

        #region Helpers

        private void ProcessGuess(string guess)
        {
            if (!IsValidGuess(guess))
            {
                throw new ArgumentException(string.Format(GameStrings.Guess_Invalid, guess));
            }

            _remainingGuesses--;
            
            // @TODO evaluate valid guess
        }

        bool IsValidGuess(string guess)
        {
            if (string.IsNullOrWhiteSpace(guess) || Regex.IsMatch(guess, Constants.Regex.InvalidPlayerInput, RegexOptions.IgnoreCase))
            {
                return false;
            }

            return true;
        }

        bool IsGameOver()
        {
            return _remainingGuesses == 0;

            // @TODO implement game over if player wins
        }

        #endregion
    }
}
