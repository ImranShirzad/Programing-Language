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
            abstract class Command
            {
                private static ArrayList variables = new ArrayList();

                abstract public void execute();

                public static model.Variable getVariable(String name)
                {
                    if (variables.Count > 0)
                    {
                        foreach (model.Variable var in variables)
                        {
                            if (var.getName().Equals(name, StringComparison.OrdinalIgnoreCase))
                            {
                                return var;
                            }
                        }
                    }
                    return null;
                }

                public static void clear()
                {
                    variables.Clear();
                }

                public static void addVariable(model.Variable variable)
                {
                    variables.Add(variable);
                }

                public static void addError(String message, int lineNumber, ArrayList errors)
                {
                    model.Error error = new model.Error();
                    error.setLine(lineNumber);
                    error.setMessage(message);
                    errors.Add(error);
                }

                public static bool evaluatebool(string expression, int lineNumber, ArrayList errors)
                {
                    bool result = false;

                    if (expression.IndexOf(">=") > 0) 
                    {
                        string[] stringSeparators = new string[] { ">=" };
                        string[] st = expression.Split(stringSeparators, System.StringSplitOptions.None);
                        if (st.Length != 2)
                        {
                            addError("bool needs two params", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }

                        int left = Command.evaluateInteger(st[0], lineNumber, errors); 
                        int right = Command.evaluateInteger(st[1], lineNumber, errors);

                        return left >= right;
                    } 
                    else if (expression.IndexOf(">") > 0)
                    {
                        string[] st = expression.Split('>');
                        if (st.Length != 2)
                        {
                            addError("bool needs two params", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }

                        int left = Command.evaluateInteger(st[0], lineNumber, errors);
                        int right = Command.evaluateInteger(st[1], lineNumber, errors);

                        return left > right;
                    }
                    else if (expression.IndexOf("<=") > 0)
                    {
                        string[] stringSeparators = new string[] { "<=" };
                        string[] st = expression.Split(stringSeparators, System.StringSplitOptions.None);
                        if (st.Length != 2)
                        {
                            addError("bool needs two params", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        int left = Command.evaluateInteger(st[0], lineNumber, errors);
                        int right = Command.evaluateInteger(st[1], lineNumber, errors);
                        return left <= right;
                    }
                    else if (expression.IndexOf("<") > 0)
                    {
                        string[] st = expression.Split('<');
                        if (st.Length != 2)
                        {
                            addError("bool needs two params", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        int left = Command.evaluateInteger(st[0], lineNumber, errors);
                        int right = Command.evaluateInteger(st[1], lineNumber, errors);
                        return left < right;
                    }
                    else if (expression.IndexOf("==") > 0)
                    {
                        string[] stringSeparators = new string[] { "==" };
                        string[] st = expression.Split(stringSeparators, System.StringSplitOptions.None);
                        if (st.Length != 2)
                        {
                            addError("bool needs two params", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        int left = Command.evaluateInteger(st[0], lineNumber, errors);
                        int right = Command.evaluateInteger(st[1], lineNumber, errors);
                        return left == right;
                    }
                    else
                    {
                        model.Variable variable = Command.getVariable(expression);
                        if (null == variable)
                        {
                            result = bool.TryParse(expression, out bool booleanValue); 
                        }
                        else
                        {
                            result = (bool)variable.getValue();
                        }
                    }
                    return result;
                }

                public static int evaluateInteger(string expression, int lineNumber, ArrayList errors)
                {
                    int result = 0;

                    if (expression.IndexOf("+") > 0) 
                    {
                        string[] st = expression.Split('+');
                        if (st.Length < 2)
                        {
                            addError("Addition needs at least two params separated by +", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        for (int i = 0; i < st.Length; i++)
                        {
                            result += evaluateInteger(st[i], lineNumber, errors);
                        }
                    } 
                    else if (expression.IndexOf("-") > 0) 
                    {
                        string[] st = expression.Split('-');
                        if (st.Length < 2)
                        {
                            addError("Substraction needs at least two params separated by -", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        for (int i = 0; i < st.Length; i++)
                        {
                            if (i == 0)
                            {
                                result = evaluateInteger(st[0], lineNumber, errors);
                            }
                            else
                            {
                                result -= evaluateInteger(st[i], lineNumber, errors);
                            }
                        }
                    } else if (expression.IndexOf("*") > 0) {
                        result = 1;
                        string[] st = expression.Split('*');
                        if (st.Length < 2)
                        {
                            addError("Multiplication needs at least two params separated by *", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        for (int i = 0; i < st.Length; i++)
                        {
                            result *= evaluateInteger(st[i], lineNumber, errors);
                        }
                    } else if (expression.IndexOf("/") > 0) {
                        string[] st = expression.Split('*');
                        if (st.Length < 2)
                        {
                            addError("Division needs at least two params separated by /", lineNumber, errors);
                            throw new Exception("Syntax checking is failed");
                        }
                        for (int i = 0; i < st.Length; i++)
                        {
                            if (i == 0)
                            {
                                result = evaluateInteger(st[0], lineNumber, errors);
                            }
                            else
                            {
                                result /= evaluateInteger(st[i], lineNumber, errors);
                            }
                        }
                    } else {
                        model.Variable variable = getVariable(expression);
                        if (null == variable)
                        {
                            result = Convert.ToInt32(expression);
                        }
                        else
                        {
                            result = (int)variable.getValue();
                        }
                    }
                    return result;
                }
            }
        }
    }
}
