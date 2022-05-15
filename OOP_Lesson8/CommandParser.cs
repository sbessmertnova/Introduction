using System;
using System.Collections.Generic;
using System.Linq;
using static OOP_Lesson8.Const;

namespace OOP_Lesson8
{
    public class CommandParser
    {
        public static KeyParsingResult GetShowInfoCommand() => new KeyParsingResult
        {
            Command = Const.GetAllCommandInfos().First(command => command.userAction == UserActions.ShowInfo)
        };

        public static KeyParsingResult ParseToCommand(string input)
        {
            var userValues = input.Split(' ');//получаем ключ и значение (-я) ключа, введенные пользователем
            var userKey = userValues.First();
            var allCommands = Const.GetAllCommandInfos();
            var actionValues = userValues.Skip(1).Any()
                ? userValues.Skip(1)
                : Array.Empty<string>();
            if (!allCommands.Any(command=> command.inputKey == userKey))
            {
                return new KeyParsingResult
                {
                    Command = null,
                    ActionValues = actionValues.ToArray()
                };
            }
            var command = allCommands.First(command => command.inputKey == userKey);
            return new KeyParsingResult
            {
                Command = command,
                ActionValues = actionValues.ToArray()
            };
        }
    }


    public class KeyParsingResult
    {
        public CommandInfo Command { get; set; }
        public string[] ActionValues { get; set; }
    }
}
