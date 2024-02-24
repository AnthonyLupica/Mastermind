using Mastermind.ResourceStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using static Mastermind.AppSettings;

namespace Mastermind.GameCore
{
    internal class Round
    {
        public string Secret { get; private set; }
        public int RemainingGuesses { get; private set; }

        public Round()
        {
            Secret = SecretCode.GenerateSecretCode();
            RemainingGuesses = Rules.GuessLimit;
        }

        /// <summary>
        /// Validates and Evaluates the player's guess
        /// </summary>
        /// <param name="guess">the player's guess</param>
        /// <returns>A string consisting of +'s and/or -'s for player feedback</returns>
        public string TryCheckGuess(string guess)
        {
            ValidateGuess(guess);

            string pluses = "";
            string minuses = "";

            // Map each digit of the secret to the number of times it appears in the string
            Dictionary<char, int> AvailableSecretDigits = new Dictionary<char, int>();

            // Track indices used for '+' score to avoid double counting when scoring for '-'
            HashSet<int> MatchedPositionIndices = new HashSet<int>();
             
            // Populate Dictionary with frequency of each number in secret code
            foreach (char digit in Secret)
            {
                if (AvailableSecretDigits.ContainsKey(digit))
                {
                    ++AvailableSecretDigits[digit];
                }
                else
                {
                    AvailableSecretDigits[digit] = 1;
                }
            }

            // Score +'s first
            for (int i = 0; i < guess.Length; i++)
            {
                if (!AvailableSecretDigits.TryGetValue(guess[i], out int count) || count == 0)
                {
                    // Guess digit isn't in the secret code or the code has no more "score uses" of this digit
                    continue;
                }

                // Matches number and position
                if (guess[i] == Secret[i])
                {
                    // Append '+', consume one use of this digit's score potential, and track this index
                    pluses += '+';
                    --AvailableSecretDigits[guess[i]];
                    MatchedPositionIndices.Add(i);
                }
            }

            // Score -'s
            for (int i = 0; i < guess.Length; i++)
            {
                if (!AvailableSecretDigits.TryGetValue(guess[i], out int count) || count == 0 || MatchedPositionIndices.Contains(i))
                {
                    // Guess digit isn't in the secret code, the code has no more "score uses" of this digit, or this digit has already been scored with '+'
                    continue;
                }

                // Matches number but not position
                if (Secret.Contains(guess[i]))
                {
                    // Append '-' and consume one use of this digit's score potential
                    minuses += '-';
                    --AvailableSecretDigits[guess[i]];
                }
            }

            --RemainingGuesses;
            return pluses + minuses;
        }

        private void ValidateGuess(string guess)
        {
            if (string.IsNullOrWhiteSpace(guess))
            {
                throw new ArgumentException(GameStrings.Validation_EmptyGuess);
            }

            if (!guess.All(char.IsDigit))
            {
                throw new ArgumentException(GameStrings.Validation_NonDigit);
            }

            if (guess.Trim().Length != Rules.SecretLength)
            {
                throw new ArgumentException(string.Format(GameStrings.Validation_SecretLength, Rules.SecretLength));
            }

            if (guess.Any(number => !Rules.SecretCharSet.Contains(number)))
            {
                throw new ArgumentException(string.Format(
                        GameStrings.Validation_DigitNotInSecretCharSet,
                        Rules.SecretCharSet[0],
                        Rules.SecretCharSet[Rules.SecretCharSet.Length - 1]
                    ));
            }
        }
    }
}
