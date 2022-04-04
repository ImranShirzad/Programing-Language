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
            internal class Method : Command, Statement
            {
                private ArrayList commands = new ArrayList();
                private ArrayList parameters = new ArrayList();
                private string name;
                private string expression;
                private int lineNumber;



                public Method(string expression, int lineNumber)
                {
                    this.expression = expression;
                    this.lineNumber = lineNumber;
                }

                public override void execute()
                {
                    if (commands.Count > 0)
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
                    return false;
                }

                public string getName()
                {
                    return name;
                }

                public ArrayList getParameters()
                {
                    return parameters;
                }

                public void setParameters(ArrayList parameters)
                {
                    this.parameters = parameters;
                }

                public void parse(ArrayList errors)
                {
                    int left = expression.IndexOf("(");
                    int right = expression.IndexOf(")");
                    if (left > right)
                    {
                        addError("( should be put in front of )", lineNumber, errors);
                    }
                    string[] st = expression.Split('(');
                    int numOfLeft = st.Length - 1;
                    st = expression.Split(')'); 
                    int numOfRight = st.Length;
                    if (numOfLeft != 1)
                    {
                        addError("Something wrong with the number of (", lineNumber, errors);
                    }
                    if (numOfRight != 1)
                    {
                        addError("Something wrong with the number of )", lineNumber, errors);
                    }
                    string[] stringSeparators = new string[] { "(", ")" };
                    st = expression.Split(stringSeparators, System.StringSplitOptions.None);
                    if (st.Length > 2 || st.Length < 1)
                    {
                        addError("Syntax error is found in the signature of this method", lineNumber, errors);
                    }
                    name = st[0];
                    if (st.Length > 1)
                    {
                        string[] p = st[1].Split(',');
                        for (int i = 0; i < p.Length; i++) {
                            parameters.Add(p[i]);
                        }
                    }
                }
            }
        }
    }
}
