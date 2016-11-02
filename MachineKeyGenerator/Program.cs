using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace MachineKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write(
"/*\n"+
"* decryptionKey:\n"+
"* DES: 64 bits (16 hexadecimal characters)\n"+
"* 3DES:192 bits (48 hexadecimal characters)\n"+
"* AES: 128 bits (32 characters), 192 bits (48 characters), or 256 bits (64 characters)\n"+
"* \n"+
"  validationKey:\n"+
"    AES requires a 256-bit key (64 hexadecimal characters).\n"+
"    MD5 requires a 128-bit key (32 hexadecimal characters).\n"+
"    SHA1 requires a 160-bit key (40 hexadecimal characters).\n"+
"    3DES requires a 192-bit key (48 hexadecimal characters).\n"+
"    HMACSHA256 requires a 256-bit key (64 hexadecimal characters).\n"+
"    HMACSHA384 requires a 384-bit key (96 hexadecimal characters).\n"+
"    HMACSHA512 requires a 512-bit key (128 hexadecimal characters).\n" +
"*/\n");

            var chare = 1;

            while (chare > 0)
            {
                var res = int.TryParse(Console.ReadLine(), out chare);
                if(!res) break;
                Console.WriteLine(CreateMachineKey(chare));
                Console.Read();
            }
            
        }
        private static string CreateMachineKey(int characterLength)
        {

            var byteArray = new byte[characterLength / 2];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(byteArray);
            var sb = new StringBuilder(characterLength);
            foreach (var t in byteArray)
            {
                sb.Append($"{t}");
            }
            Debug.WriteLine(sb);
            return sb.ToString();
        }
    }
}
