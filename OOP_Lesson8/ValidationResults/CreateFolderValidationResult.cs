using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class CreateFolderValidationResult : ValuesValidationResultBase
    {
        public string FolderToCreate { get; private set; }

        public CreateFolderValidationResult(string[] userValues)
        {
            if (userValues.Length != 1)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только одно значение";
                return;
            }
            if (Directory.Exists(userValues[0]))
            {
                ErrorMessage = $"Папка по указанному пути {userValues[0]} уже существует";
                return;
            }
            InputIsCorrect = true;
            FolderToCreate = userValues[0];
        }
    }
}

