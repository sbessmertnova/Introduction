using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson8.ValidationResults
{
    public class ShowInfoValidationResult: ValuesValidationResultBase
    {
        public ShowInfoValidationResult(string[] values)
        {
            InputIsCorrect = true;
        }
    }
}
