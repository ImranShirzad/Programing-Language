using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace products
    {
        namespace commands
        {
            interface Statement
            {
                bool isConditionTrue();
                ArrayList getCommands();
                int getLineNumber();
            }
        }
    }
}
