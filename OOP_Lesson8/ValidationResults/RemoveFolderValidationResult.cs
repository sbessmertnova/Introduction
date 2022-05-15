using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class RemoveFolderValidationResult : ValuesValidationResultBase
    {
        public string FolderToRemove { get; private set; }

        public RemoveFolderValidationResult(string[] userValues)
        {
            if (userValues.Length != 1)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только одно значение";
                return;
            }
            if (!Directory.Exists(userValues[0]))
            {
                ErrorMessage = $"Папки по указанному пути {userValues[0]} не существует";
                return;
            }
            InputIsCorrect = true;
            FolderToRemove = userValues[0];
        }
    }
}

