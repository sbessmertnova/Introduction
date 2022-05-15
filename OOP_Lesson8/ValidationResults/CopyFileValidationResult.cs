using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class CopyFileValidationResult : ValuesValidationResultBase
    {
        public string FileToCopy { get; private set; }
        public string DestingationCopy { get; set; }

        public CopyFileValidationResult(string[] userValues)
        {
            if (userValues.Length != 2)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только два значения";
                return;
            }
            if (!File.Exists(userValues[0]))
            {
                ErrorMessage = "Файла(-ов) по указанному(-ым) пути(-ям) не существует";
                return;
            }
            if (Directory.Exists(userValues[1]))
            {
                ErrorMessage = "Должен быть указан файл, а не каталог";
                return;
            }
            InputIsCorrect = true;
            FileToCopy = userValues[0];
            DestingationCopy = userValues[1];
        }
    }
}

