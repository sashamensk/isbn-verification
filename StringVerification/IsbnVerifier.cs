using System;

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

            int count = 10, multipleOfNumbers = 0, currentNumber, i = 0;
            string numberToCheck;
            string lastNumber = number.Substring(number.Length - 1);
            bool isNumeric;

            for (; i < number.Length; i++)
            {
                numberToCheck = number.Substring(i, 1);
                isNumeric = int.TryParse(numberToCheck, out currentNumber);
                if (isNumeric)
                {
                    multipleOfNumbers += currentNumber * count;
                    count--;
                }
                else
                {
                    if (numberToCheck == "-")
                    {
                        continue;
                    }

                    return false;
                }

                if (count == 1)
                {
                    break;
                }
            }

            if (count != 1)
            {
                return false;
            }

            if (lastNumber == "X")
            {
                lastNumber = "10";
            }

            int.TryParse(lastNumber, out currentNumber);
            if (11 - (multipleOfNumbers % 11) == currentNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
}
