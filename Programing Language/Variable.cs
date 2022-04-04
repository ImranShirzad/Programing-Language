using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace model
    {
        class Variable
        {
            private String name;
            private Object value;

            public String getName()
            {
                return name;
            }

            public void setName(String name)
            {
                this.name = name;
            }

            public Object getValue()
            {
                return value;
            }

            public void setValue(Object value)
            {
                this.value = value;
            }
        }
    }
}
