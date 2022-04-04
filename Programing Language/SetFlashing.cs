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
            class SetFlashing : Command
            {
                private string commandLine;
                private int lineNumber;

                public SetFlashing(string commandLine, int lineNumber)
                {
                    this.commandLine = commandLine;
                    this.lineNumber = lineNumber;
                }

                public override void execute()
                {
                    ArrayList errors = new ArrayList();
                    if (commandLine.ToUpper() == "ON")
                    {
                        Form1.factoryCreator.setFlashing(true);
                    }
                    else if (commandLine.ToUpper() == "OFF")
                    {
                        Form1.factoryCreator.setFlashing(false);
                    }
                    else
                    {
                        try
                        {
                            Form1.factoryCreator.setFlashing(Command.evaluatebool(commandLine, lineNumber, errors));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("execute " + e.Message);
                            addError("Parsing boolean expression fails", lineNumber, errors);
                        }
                    }
                }

                public void parse(ArrayList errors)
                {
                    string[] st = commandLine.Split(',');
                    if (st.Length != 1)
                    {
                        addError("Set flashing command needs only one params", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }
                    commandLine = st[0];
                }
            }
        }
    }
}
