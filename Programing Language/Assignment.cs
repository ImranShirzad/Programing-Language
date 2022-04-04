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
            class Assignment : Command
            {
                private string commandLine;
                private int lineNumber;

                public Assignment(string commandLine, int lineNumber)
                {
                    this.commandLine = commandLine;
                    this.lineNumber = lineNumber;
                }

                public override void execute()
                {
                    ArrayList errors = new ArrayList();
                    try
                    {
                        model.Variable newVar = parse(errors);
                        Command.getVariable(newVar.getName()).setValue(newVar.getValue());
                    }
                    catch (Exception e)
                    {
                        throw new Exception("There is a runtime error found at Line " + lineNumber + " " + e.Message);
                    }
                }

                public model.Variable parse(ArrayList errors)
                {
                    model.Variable variable = null;
                    string[] st = commandLine.Split('=');
                    if (st.Length != 2)
                    {
                        addError("Assignment command needs one value", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }

                    try
                    {
                        variable = new model.Variable();
                        variable.setName(st[0]);
                        variable.setValue(evaluateInteger(st[1], lineNumber, errors));
                    }
                    catch (Exception e)
                    {
                        addError("The given param can not be parsed as an integer", lineNumber, errors);
                        Console.WriteLine("DRAWTO " + e.Message);
                        throw new Exception("Syntax checking is failed");
                    }
                    return variable;
                }
            }
        }
    }
}
