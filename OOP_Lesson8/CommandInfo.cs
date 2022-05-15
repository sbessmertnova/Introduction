using OOP_Lesson8.ValidationResults;
using System;
using System.Collections.Generic;

namespace OOP_Lesson8
{
    public static partial class Const
    {
        public class CommandInfo
        {
            public string inputKey { get; set; }
            public UserActions userAction { get; set; }
            public Func<string[], ValuesValidationResultBase> validatorCreator { get; set; }
        }
    }
}
