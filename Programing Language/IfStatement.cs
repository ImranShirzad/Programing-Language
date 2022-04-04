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
            class IfStatement : Command, Statement
            {
                private ArrayList commands = new ArrayList();
                private string condition;
                private int lineNumber;

                public IfStatement(string condition, int lineNumber)
                {
                    this.condition = condition;
                    this.lineNumber = lineNumber;
                }
                public override void execute()
                {
                    if (isConditionTrue())
                    {
                        foreach (Command command in commands)
                        {
                            command.execute();
                        }
                    }
                }

                public ArrayList getCommands()
                {
                    return commands;
                }

                public int getLineNumber()
                {
                    return lineNumber;
                }

                public bool isConditionTrue()
                {
                    ArrayList errors = new ArrayList();
                    bool result = false;
                    try
                    {
                        result = Command.evaluatebool(condition, lineNumber, errors);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("DRAWTO " + e.Message);
                    }
                    return result;
                }

                public void parse(ArrayList errors)
                {
                    try
                    {
                        Command.evaluatebool(condition, lineNumber, errors);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("parse " + e.Message);
                        addError("Syntax error is found in this If Statement", lineNumber, errors);
                    }
                }
            }
        }
    }
}
