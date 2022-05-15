using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class RemoveFileValidationResult : ValuesValidationResultBase
    {
        public string FileToRemove { get; private set; }

        public RemoveFileValidationResult(string[] userValues)
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
            FileToRemove = userValues[0];
        }
    }
}

