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

            // Start the main game loop
            while (true)
            {
                bool didPlayerWin = StartNewRound();

                // See if the player wants to play again
                Console.Write(didPlayerWin ? GameStrings.KeepPlayingWon : GameStrings.KeepPlayingLost);
                char response = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (response.ToString().ToUpper() == ConsoleKey.N.ToString())
                {
                    break;
                }
            }

            Console.WriteLine(GameStrings.Exit);
        }

        private bool StartNewRound()
        {
            Round round = new Round();

            // Print the round intro and rules
            string roundStart = string.Format(
                    GameStrings.RoundStart,
                    Rules.SecretLength,
                    Rules.SecretCharSet[0],
                    Rules.SecretCharSet[Rules.SecretCharSet.Length - 1],
                    Rules.GuessLimit
                );

            PromptShowHelp();

            // Begin prompting the player for guesses
            Console.WriteLine(roundStart);

            bool playerGuessedCorrectly = false;
            while (round.RemainingGuesses != 0)
            {
                Console.Write(string.Format(GameStrings.Prompt_Guess, (Rules.GuessLimit - round.RemainingGuesses) + 1, Rules.GuessLimit));
                string guess = Console.ReadLine();

                try
                {
                    string feedback = round.TryCheckGuess(guess);
                    Console.WriteLine(string.Format(GameStrings.Feedback, feedback));

                    // End the round if the player guesses correctly
                    if (!feedback.Contains('-') && feedback.Length == Rules.SecretLength)
                    {
                        playerGuessedCorrectly = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    // Handle invalid guess attempt
                    Console.WriteLine(e.Message);
                    Console.WriteLine(GameStrings.Validation_ConfirmGuessNotTaken);

                    PromptShowHelp();
                }
            }

            // Congratulations or failure
            Console.WriteLine(playerGuessedCorrectly ? GameStrings.YouSolvedIt : string.Format(GameStrings.YouLose, round.Secret));

            return playerGuessedCorrectly;
        }

        private void PromptShowHelp()
        {
            Console.Write(GameStrings.Prompt_Help);
            char response = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (response.ToString().ToUpper() == ConsoleKey.Y.ToString())
            {
                Console.WriteLine(GameStrings.Help);

                Console.Write(GameStrings.Prompt_AnyKeyContinue);
                Console.ReadKey();
            }
           
            Console.WriteLine();
        }
    }
}
