using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Caesar_Cipher
{
    public static class Cipher
    {
        public static string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //public static string usualFrequencyAlphabet = "ОЕАИНТСРВЛКМДПУЯЫЬГЗБЧЙХЖШЮЦЩЭФЪЁ";
        private static byte lastStep = 0;
        public static string Encrypt(string text, byte step)
        {
            text = Decrypt(text, lastStep);
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), "[А-Яа-яЁё]"))
                {
                    int index = russianAlphabet.IndexOf(Char.ToUpper(chars[i])) + step;
                    if (index > 32)
                    {
                        index -= 33;
                    }

                    if (Char.IsLower(chars[i]))
                    {
                        chars[i] = Char.ToLower(russianAlphabet[index]);
                    }
                    else
                    {
                        chars[i] = russianAlphabet[index];
                    }
                }
            }
            lastStep = step;
            return new string(chars);
        }
        private static string Decrypt(string text, byte step)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), "[А-Яа-яЁё]"))
                {
                    int index = russianAlphabet.IndexOf(Char.ToUpper(chars[i])) - step;
                    if (index < 0)
                    {
                        index = 33 + index;
                    }

                    if (Char.IsLower(chars[i]))
                    {
                        chars[i] = Char.ToLower(russianAlphabet[index]);
                    }
                    else
                    {
                        chars[i] = russianAlphabet[index];
                    }
                }
            }
            return new string(chars);
        }

        public static int GuessStep(string text)
        {
            text = Decrypt(text, lastStep);
            Dictionary<char, uint> letterFrequency = new Dictionary<char, uint>();
            foreach (char letter in russianAlphabet)
            {
                letterFrequency.Add(letter, 0);
            }
            
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), "[А-Яа-яЁё]"))
                {
                    char letter = Char.ToUpper(chars[i]);
                    letterFrequency[letter]++;
                }
            }
            char mostFrequentLetter = letterFrequency.Aggregate((l, r) => l.Value > r.Value ? l : r).Key; ;
            
            int deltaStep = russianAlphabet.IndexOf(mostFrequentLetter) - russianAlphabet.IndexOf('О');
            
            return Math.Abs(deltaStep) % 33;
        }
    }
}
