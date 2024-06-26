﻿using AyodhyaYatra.API.Config;
using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace AyodhyaYatra.API.Common
{
    public static class PasswordHasher
    {


        public static string GenerateHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool AreEqual(string plainTextInput, string hashedInput)
        {
            string newHashedPin = GenerateHash(plainTextInput);
            return newHashedPin.Equals(hashedInput);
        }
    }
}
