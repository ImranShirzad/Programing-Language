using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace model
    {
        internal class Error
        {
            private String message;
            private int line;

            public String getMessage()
            {
                return message;
            }

            public void setMessage(String message)
            {
                this.message = message;
            }

            public int getLine()
            {
                return line;
            }

            public void setLine(int line)
            {
                this.line = line;
            }
        }
    }
}
