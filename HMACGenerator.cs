using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class HMACGenerator
    {
        private byte[] key;
        public HMACGenerator()
        {
            GenerateKey();
        }
        private void GenerateKey()
        {
            using(var rng = RandomNumberGenerator.Create())
            {
                key = new byte[32];
                rng.GetBytes(key);
            }
        }
        public byte[] ComputeHMAC(byte[] move)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(move);
            }
        }
        public string GetKey()
        {
            return BitConverter.ToString(key).Replace("-",string.Empty);
        }
    }
}
