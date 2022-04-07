using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lesson7
{
   public interface ICoder
    {
        public string Encode(string text);

        public string Decode(string encodedText);
    }
}
