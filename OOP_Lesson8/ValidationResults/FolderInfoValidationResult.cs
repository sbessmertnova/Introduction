using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class FolderInfoValidationResult : ValuesValidationResultBase
    {
        public string FolderInfo { get; private set; }

        public FolderInfoValidationResult(string[] userValues)
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
            FolderInfo = userValues[0];
        }
    }
}

