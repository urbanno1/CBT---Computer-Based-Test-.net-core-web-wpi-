using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CBT.Service.Helpers
{
    public static class RandomPassword
    {
        public static string GenerateRandomPassword(PasswordOptions options = null)
        {
            if (options == null)
                options = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireUppercase = true,
                    RequireLowercase = true,
                    RequireDigit = true,
                    RequireNonAlphanumeric = true,
                };

            var randomCharacters = new string[]
            {
             "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
             "abcdefghijkmnopqrstuvwxyz",    // lowercase
             "0123456789",                   // digits
             "!@$?_-"
            };

            Random random = new Random(Environment.TickCount);
            List<char> password = new List<char>();

            if (options.RequireUppercase)
                password.Insert(random.Next(0, password.Count), randomCharacters[0][random.Next(0, randomCharacters[0].Length)]);
            if (options.RequireLowercase)
                password.Insert(random.Next(0, password.Count), randomCharacters[1][random.Next(0, randomCharacters[1].Length)]);
            if (options.RequireDigit)
                password.Insert(random.Next(0, password.Count), randomCharacters[2][random.Next(0, randomCharacters[2].Length)]);
            if (options.RequireNonAlphanumeric)
                password.Insert(random.Next(0, password.Count), randomCharacters[3][random.Next(0, randomCharacters[3].Length)]);

            //Iterate over the password to get exact required length
            for (int i = password.Count; i < options.RequiredLength
               || password.Distinct().Count() < options.RequiredUniqueChars; i++)
            {
                string randomString = randomCharacters[random.Next(0, randomCharacters.Length)];
                password.Insert(random.Next(0, password.Count),
                    randomString[random.Next(0, randomString.Length)]);
            }

            return new string(password.ToArray());
        }
    }
}
