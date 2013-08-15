using System;
using System.IO;


namespace CLRAssembly
{
    sealed class myConsole
    {
        private static void Main()
        {
            Console.WriteLine("");
            testCrypto();
            Console.ReadLine();

            Console.WriteLine("");
            testRandom();
            Console.ReadLine();
        }

        private static void testCrypto()
        {
            string decryptionKey = "ayb&e#i&BWLGMe2V";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("    Enter String: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string testString = Console.ReadLine();

            string encrypted = Cryptography.Encrypt(testString, decryptionKey);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Encrypted String: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(encrypted);

            string decrypted = Cryptography.Decrypt(encrypted, decryptionKey);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Decrypted String: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(decrypted);
        }

        private static void testRandom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    Random tests: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Random Date: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Randomness.Date());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.Write("Random Time: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Randomness.Time());
        }
    }
}