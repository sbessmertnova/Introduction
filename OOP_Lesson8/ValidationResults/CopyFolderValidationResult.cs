using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class CopyFolderValidationResult : ValuesValidationResultBase
    {
        public string FolterToCopy { get; private set; }
        public string DestingationCopy { get; set; }

        public CopyFolderValidationResult(string[] userValues)
        {
            if(userValues.Length != 2)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только два значения";
                return;
            }
            if (!Directory.Exists(userValues[0]))
            {
                ErrorMessage = $"Папки по указанному пути {userValues[0]} не существует";
                return;
            }
            if (Directory.Exists(userValues[1]))
            {
                ErrorMessage = $"Папка по указанному пути {userValues[1]} уже существует";
                return;        
            }
            InputIsCorrect = true;
            FolterToCopy = userValues[0];
            DestingationCopy = userValues[1];
        }
    }
}

