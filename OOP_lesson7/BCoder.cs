using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lesson7
{
    public class BCoder : ICoder
    {
        public string Decode(string encodedText)
        {
            return string.Concat(encodedText.Select(letter => DecodeLetter(letter)));
        }

        public string Encode(string text)
        {

            return string.Concat(text.Select(letter => EncodeLetter(letter)));
        }
        public static char EncodeLetter(char letter)
        {
            var isLower = char.IsLower(letter);
            var alphabet = Enumerable.Range(isLower
                ?1072
                :1040,
                32).ToArray();
            var position = Array.IndexOf(alphabet, letter) + 1;
            return (char)alphabet[^(position)];
        }
        public static char DecodeLetter(char letter)
        {
            var isLower = char.IsLower(letter);
            var alphabet = Enumerable.Range(isLower
                ?1072
                :1040, 
                32).ToArray().Reverse().ToArray();
            var position = Array.IndexOf(alphabet, letter) + 1;
            return (char)alphabet[^(position)];
        }

    }
}
