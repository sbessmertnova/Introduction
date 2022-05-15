using System;
using System.IO;
using System.Linq;

namespace OOP_Lesson8
{
    public class TextFileAnalysisResult
    {
        public long AmountOfWords { get; private set; }
        public long AmountOfLines { get; set; }
        public long AmountOfParagraphs { get; set; }
        public long AmountOfCharacters { get; set; }
        public long AmountOfCharactersWithoutSpaces { get; set; }

        public TextFileAnalysisResult(string pathToFile)
        {
            var text = File.ReadAllText(pathToFile);
            var words = text.Split(' ');
            AmountOfWords = words.Length;

            var paragraphs = text.Split(Environment.NewLine);
            AmountOfParagraphs = paragraphs.Length;

            AmountOfCharacters = text.Length;

            var totalLettersWithoutSpaces = text.Where(character => character != ' ').Count();
            AmountOfCharactersWithoutSpaces = totalLettersWithoutSpaces;

            var lines = File.ReadAllLines(pathToFile);
            AmountOfLines = lines.Length;
        }

        public override string ToString() =>
            $"Text file statistics: {AmountOfWords} words," +
                $" {AmountOfLines} lines," +
                $" {AmountOfParagraphs} paragraphs," +
                $" {AmountOfCharacters} characters," +
                $" {AmountOfCharactersWithoutSpaces} characters without spaces.";
    }
}
