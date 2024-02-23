using System;
using static Mastermind.AppSettings;

namespace Mastermind.GameCore
{
    internal static class SecretCode
    {
        public static string GenerateSecretCode()
        {
            Random rng = new Random();
            char[] charset = Rules.SecretCharSet.ToCharArray();
            char[] secretCode = new char[Rules.SecretLength];
            
            for (int i = 0; i < Rules.SecretLength; ++i)
            {
                secretCode[i] = charset[rng.Next(charset.Length)];
            }

            return new string(secretCode);
        }
    }
}
