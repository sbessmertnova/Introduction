using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class FileInfoValidationResult : ValuesValidationResultBase
    {
        public string FileInfo { get; private set; }

        public FileInfoValidationResult(string[] userValues)
        {
            if (userValues.Length != 1)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только одно значение";
                return;
            }
            if (!File.Exists(userValues[0]))
            {
                ErrorMessage = $"Файла по указанному пути {userValues[0]} не существует";
                return;
            }
            InputIsCorrect = true;
            FileInfo = userValues[0];
        }
    }
}

