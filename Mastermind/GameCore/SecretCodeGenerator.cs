using System;
using System.Security.Cryptography;

namespace Mastermind.GameCore
{
    internal class SecretCodeGenerator
    {
        public string SecretCode { get; private set; }

        public SecretCodeGenerator() : this(Constants.Rules.SecretLength) { }

        public SecretCodeGenerator(int length)
        {
            Random rng = new Random();
            char[] charset = Constants.Rules.SecretCharSet.ToCharArray();
            char[] secretCode = new char[length];
            
            for (int i = 0; i < length; ++i)
            {
                secretCode[i] = charset[rng.Next(charset.Length)];
            }

            SecretCode = new string(secretCode);
        }
    }
}
