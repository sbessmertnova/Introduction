using System.Linq;

namespace OOP_lesson7
{
    public class ACoder : ICoder
    {
        public string Decode(string encodedText)
        {
            return string.Concat(encodedText.Select(letter => (char)(letter - 1)));
        }

        public string Encode(string text)
        {
            return string.Concat(text.Select(letter => (char)(letter + 1)));
        }
    }
}
