using System;
using System.Collections.Generic;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"{nameof(number)} is null or whitespace");
            }

            string str = number;
            List<int> list = new List<int>();
            int num;

            for (int i = 0; i < number.Length; i++)
            {
                if (int.TryParse(str[i].ToString(), out num))
                {
                    list.Add(num);
                }
                else if ((i == 1 || i == 5 || i == 11) && str[i] == '-')
                {
                    continue;
                }
                else if (i == str.Length - 1 && str[i] == 'X')
                {
                    list.Add(10);
                }
                else
                {
                    return false;
                }
            }

            if (list.Count != 10)
            {
                return false;
            }

            int checkSum = 0;
            int index = 10;

            for (int i = 0; i < list.Count; i++)
            {
                checkSum += list[i] * index;
                index--;
            }

            if (checkSum % 11 == 0)
            {
                return true;
            }

            return false;
        }       
    }
}
