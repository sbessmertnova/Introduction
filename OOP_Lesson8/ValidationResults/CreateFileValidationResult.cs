using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class CreateFileValidationResult : ValuesValidationResultBase
    {
        public string FileToCreate { get; private set; }

        public CreateFileValidationResult(string[] userValues)
        {
            if (userValues.Length != 1)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только одно значение";
                return;
            }
            if (File.Exists(userValues[0]))
            {
                ErrorMessage = $"Файл по указанному пути {userValues[0]} уже существует";
                return;
            }

            InputIsCorrect = true;
            FileToCreate = userValues[0];
        }
    }
}

