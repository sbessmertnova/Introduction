using System.IO;

namespace OOP_Lesson8.ValidationResults
{
    public class PagingOutputValidationResult : ValuesValidationResultBase
    {
        public int Page { get; private set; }
        public string Path { get; private set; }
        public PagingOutputValidationResult(string[] userValues)
        {
            if (userValues.Length != 2)
            {
                ErrorMessage = $"{userValues.Length} значений у ключа. У ключа может быть только два значения: номер страницы и путь";
                return;
            }
            var path = userValues[1];
            if (!Directory.Exists(path))
            {
                ErrorMessage = $"Папки по указанному пути не существует";
                return;
            }
            if (!int.TryParse(userValues[0], out int parsedUserKeyValue))
            {
                ErrorMessage = $"Не удалось определить значение ключа {userValues[0]}";
                return;
            }
            Page = parsedUserKeyValue;
            Path = path;
            InputIsCorrect = true;
        }
    }
}

