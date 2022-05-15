using OOP_Lesson8.ValidationResults;
using System.Collections.Generic;

namespace OOP_Lesson8
{
    public static partial class Const
    {
        public static class Keys
        {
            public const string Info = "-i";
            public const string PagingOutput = "-p";
            public const string CreateFolder = "-crct";
            public const string CreateFile = "-crf";
            public const string CopyFolder = "-cpct";
            public const string CopyFile = "-cpfl";
            public const string RemoveFolder = "-rmct";
            public const string RemoveFile = "-rmfl";
            public const string FolderInfo = "-ctinfo";
            public const string FileInfo = "-flinfo";
        }

        public enum UserActions
        {
            Unknown,
            ShowInfo,
            PagingOutput,
            CreateFolder,
            CreateFile,
            CopyFolder,
            CopyFile,
            RemoveFolder,
            RemoveFile,
            FolderInfo,
            FileInfo
        }

        public static List<CommandInfo> GetAllCommandInfos() =>
            new List<CommandInfo>
            {
                new CommandInfo { inputKey = Keys.Info, userAction = UserActions.ShowInfo, validatorCreator = (values)=> new ShowInfoValidationResult(values)},
                new CommandInfo { inputKey = Keys.PagingOutput, userAction = UserActions.PagingOutput, validatorCreator = (values) => new PagingOutputValidationResult(values)},
                new CommandInfo { inputKey = Keys.CreateFolder, userAction = UserActions.CreateFolder, validatorCreator = (values)=> new CreateFolderValidationResult(values)},
                new CommandInfo { inputKey = Keys.CreateFile, userAction = UserActions.CreateFile, validatorCreator = (values)=> new CreateFileValidationResult(values)},
                new CommandInfo { inputKey = Keys.CopyFolder, userAction = UserActions.CopyFolder, validatorCreator = (values)=> new CopyFolderValidationResult(values)},
                new CommandInfo { inputKey = Keys.CopyFile, userAction = UserActions.CopyFile, validatorCreator = (values)=> new CopyFileValidationResult(values)},
                new CommandInfo { inputKey = Keys.RemoveFolder, userAction = UserActions.RemoveFolder, validatorCreator = (values) => new RemoveFolderValidationResult(values)},
                new CommandInfo { inputKey = Keys.RemoveFile, userAction = UserActions.RemoveFile, validatorCreator = (values) => new RemoveFileValidationResult(values)},
                new CommandInfo { inputKey = Keys.FolderInfo, userAction = UserActions.FolderInfo, validatorCreator =(values)=> new FolderInfoValidationResult(values)},
                new CommandInfo { inputKey = Keys.FileInfo, userAction = UserActions.FileInfo, validatorCreator = (values)=> new FileInfoValidationResult(values)}
            };
    }

}
