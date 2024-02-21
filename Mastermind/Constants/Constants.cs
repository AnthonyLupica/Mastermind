﻿namespace Mastermind
{
    internal static class Constants
    {
        internal static class Regex
        {
            // matches non-numeric input that is not the (case-insensitive) letter q (quit) or h (help)
            public const string InvalidPlayerInput = @"[^qh\d]";
        }

        internal static class Rules 
        {
            // number of attempts the player has before game over
            public const int GuessLimit = 12;

            // how many digits the secret code is
            public const int SecretLength = 4;

            // charset on which to generate the secret code
            public const string SecretCharSet = "123456";
        }
    }
}