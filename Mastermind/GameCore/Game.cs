using Mastermind.ResourseStrings;
using System;
using static Mastermind.AppSettings;

namespace Mastermind.GameCore
{
    internal class Game
    {
        public Game() {}

        /// <summary>
        /// Starts the game of Mastermind
        /// </summary>
        public void Play()
        {
            Console.WriteLine(GameStrings.Introduction);

            while (true)
            {
                bool didPlayerWin = StartNewRound();

                // See if the player wants to play again
                Console.Write(didPlayerWin ? GameStrings.KeepPlayingWon : GameStrings.KeepPlayingLost);
                ConsoleKeyInfo response = Console.ReadKey();

                if (response.KeyChar.ToString().ToUpper() == ConsoleKey.N.ToString())
                {
                    break;
                }
            }

            Console.WriteLine(GameStrings.Exit);
        }

        private bool StartNewRound()
        {
            GameRound round = new GameRound();

            // Print the round intro and rules
            string roundStart = string.Format(
                    GameStrings.RoundStart,
                    Rules.SecretLength,
                    Rules.SecretCharSet[0],
                    Rules.SecretCharSet[Rules.SecretCharSet.Length - 1],
                    Rules.GuessLimit
                );

            Console.WriteLine(roundStart);

            // Begin prompting the player
            bool playerGuessedCorrectly = false;
            while (round.RemainingGuesses != 0)
            {
                Console.Write(string.Format(GameStrings.Guess_Prompt, (Rules.GuessLimit - round.RemainingGuesses) + 1, Rules.GuessLimit));
                string guess = Console.ReadLine();

                try
                {
                    string feedback = round.TryCheckGuess(guess);
                    Console.WriteLine(feedback);

                    if (!feedback.Contains('-') && feedback.Length == Rules.SecretLength)
                    {
                        playerGuessedCorrectly = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // @TODO reveal the secret

            return playerGuessedCorrectly;
        }
    }
}
