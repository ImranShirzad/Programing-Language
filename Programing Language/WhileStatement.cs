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
            class WhileStatement : Command, Statement
            {
                private ArrayList commands = new ArrayList();
                private string condition;
                private int lineNumber;

                public WhileStatement(string condition, int lineNumber)
                {
                    this.condition = condition;
                    this.lineNumber = lineNumber;
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
                        addError("Syntax error is found in this While Statement", lineNumber, errors);
                    }
                }

                public override void execute()
                {
                    while (isConditionTrue() && commands.Count > 0)
                    {
                        foreach (Command command in commands)
                        {
                            command.execute();
                        }
                    }
                }

                public void setCondition(string condition)
                {
                    this.condition = condition;
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
                        Console.WriteLine("isConditionTrue " + e.Message);
                    }
                    return result;
                }
            }
        }
    }
}
