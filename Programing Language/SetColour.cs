using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace products
    {
        namespace commands
        {
            class SetColour : Command
            {
                private string r;
                private string g;
                private string b;
                private string commandLine;
                private int lineNumber;

                public SetColour(string commandLine, int lineNumber)
                {
                    this.commandLine = commandLine;
                    this.lineNumber = lineNumber;
                }

                public override void execute()
                {
                    ArrayList errors = new ArrayList();
                    Color color = Color.FromArgb(evaluateInteger(r, lineNumber, errors),
                        evaluateInteger(g, lineNumber, errors),
                        evaluateInteger(b, lineNumber, errors));
                    Form1.factoryCreator.setColor(color);
                }
                public void parse(ArrayList errors)
                {
                    string[] st = commandLine.Split(',');
                    if (st.Length != 3)
                    {
                        addError("Set colour command needs three params", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }
                    r = st[0];
                    g = st[1];
                    b = st[2];
                }
            }
        }
    }
}
