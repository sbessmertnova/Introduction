using OOP_Lesson8.ValidationResults;
using System;
using System.IO;
using static OOP_Lesson8.Const;

namespace OOP_Lesson8
{
    public class CommandExecutor
    {
        public static void Execute(KeyParsingResult result)
        {
            var validationResult = result?.Command.validatorCreator(result.ActionValues);
            if (validationResult == null || !validationResult.InputIsCorrect)
            {
                throw new ArgumentException(validationResult.ErrorMessage);
            }
            Execute(result, validationResult);
        }

        private static void Execute(KeyParsingResult result, ValuesValidationResultBase values)
        {
            switch (result.Command.userAction)
            {
                case Const.UserActions.ShowInfo:
                    CommandExecutor.ShowInfo();
                    break;
                case Const.UserActions.PagingOutput:
                    CommandExecutor.PagingOutput((PagingOutputValidationResult)values);
                    break;
                case Const.UserActions.CreateFolder:
                    CommandExecutor.CreateFolder((CreateFolderValidationResult)values);
                    break;
                case Const.UserActions.CreateFile:
                    CommandExecutor.CreateFile((CreateFileValidationResult)values);
                    break;
                case Const.UserActions.CopyFolder:
                    CommandExecutor.CopyFolder((CopyFileValidationResult)values);
                    break;
                case Const.UserActions.CopyFile:
                    CommandExecutor.CopyFile((CopyFileValidationResult)values);
                    break;
                case Const.UserActions.RemoveFolder:
                    CommandExecutor.RemoveFolder((RemoveFolderValidationResult)values);
                    break;
                case Const.UserActions.RemoveFile:
                    CommandExecutor.RemoveFile((RemoveFileValidationResult)values);
                    break;
                case Const.UserActions.FolderInfo:
                    CommandExecutor.FolderInfo((FolderInfoValidationResult)values);
                    break;
                case Const.UserActions.FileInfo:
                    CommandExecutor.PrintFileInfo((FileInfoValidationResult)values);
                    break;
                case Const.UserActions.Unknown:
                default:
                    throw new ArgumentException(result.Command.ToString());
            }
        }

        private static void CopyFolder(CopyFileValidationResult result) =>
            File.Copy(result.FileToCopy, result.DestingationCopy);

        private static void CreateFolder(CreateFolderValidationResult result) =>
            Directory.CreateDirectory(result.FolderToCreate);

        private static void CreateFile(CreateFileValidationResult result) =>
            File.Create(result.FileToCreate);

        private static void CopyFile(CopyFileValidationResult result) =>
            File.Copy(result.FileToCopy, result.DestingationCopy);

        private static void DeleteDirectory(RemoveFolderValidationResult result)=>
            Directory.Delete(result.FolderToRemove, true);

        private static void DeleteFile(RemoveFileValidationResult result) =>
            File.Delete(result.FileToRemove);

        private static void FolderInfo(FolderInfoValidationResult result) =>
            Helpers.PrintFolderInfo(result.FolderInfo);

        private static void PrintFileInfo(FileInfoValidationResult result)
        {
            FileInfo info = new FileInfo(result.FileInfo);

            Console.WriteLine($"{info.FullName} {info.Length} bytes. " +
                    $"Last write time: {info.LastWriteTime}. From directory: {info.DirectoryName}" +
                    $"Atributes: readonly - {info.IsReadOnly}, hidden - {info.Attributes.HasFlag(FileAttributes.Hidden)}");

            if (info.Extension == ".txt")
            {
                Console.WriteLine(new TextFileAnalysisResult(result.FileInfo));
            }
        }

        private static void PagingOutput(PagingOutputValidationResult result)
        {
            var helpers = new Helpers(result.Page);

            var contents = Helpers.GetContentsFromFolderRecursive(result.Path, 0, 2);

            var cutresult = helpers.CutResultsToRange(contents, 1);

            foreach (var resultValue in cutresult.result)
            {
                Console.WriteLine(resultValue);
            }
        }

        private static void ShowInfo()
        {
            string showInfo =
                   $"{Environment.NewLine}{Keys.Info} - справка" +
                   $"{Environment.NewLine}{Keys.PagingOutput} - постраничный вывод дерева " +
                   $"{Environment.NewLine}{Keys.CreateFolder} - создание каталога" +
                   $"{Environment.NewLine}{Keys.CreateFile} - создание каталога" +
                   $"{Environment.NewLine}{Keys.CopyFolder} - копирование каталога" +
                   $"{Environment.NewLine}{Keys.CopyFile} - копирование файла" +
                   $"{Environment.NewLine}{Keys.RemoveFolder} - удаление каталога" +
                   $"{Environment.NewLine}{Keys.RemoveFile} - удаление файла" +
                   $"{Environment.NewLine}{Keys.FolderInfo} - информация о каталоге" +
                   $"{Environment.NewLine}{Keys.FileInfo} - информация о файле";

            Console.WriteLine(showInfo);
        }

        private static void RemoveFolder(RemoveFolderValidationResult values) =>
            Directory.Delete(values.FolderToRemove, true);

        private static void RemoveFile(RemoveFileValidationResult values) =>
            File.Delete(values.FileToRemove);
    }
}
