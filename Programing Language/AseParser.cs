using Programing_Language.factories;
using Programing_Language.model;
using Programing_Language.products.commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    class AseParser
    {
        private AbstractCommandFactory commandFactory = new BasicCommandFactory();
        private ArrayList errors = new ArrayList();
        private ArrayList commands = new ArrayList();
        private ArrayList methods = new ArrayList();
        private Stack statements = new Stack();

        public void clear()
        {
            errors.Clear();
            commands.Clear();
            methods.Clear();
            statements.Clear();
            Command.clear();
        }

        public ArrayList getErrors()
        {
            if (errors.Count > 0)
            {
                foreach (Error error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            return errors;
        }

        public void parse(string content)
        {
            clear();
            string[] lines = content.Split(new string[] { Environment.NewLine, "\n" }, System.StringSplitOptions.None);
            for(int i = 0; i < lines.Length; i++)
            {
                parseLine(lines[i], i+1);
            }

            if (statements.Count > 0)
            {
                foreach (var elem in statements)
                {
                    Statement statement = (Statement) elem;
                    Error error = new Error();
                    error.setLine(statement.getLineNumber());
                    error.setMessage(statement.GetType() + " is not closed properly.");
                    errors.Add(error);
                }
            }
        }

        private ArrayList getProperCommands()
        {
            if (statements.Count <= 0)
            {
                return commands;
            }
            return ((Statement)statements.Peek()).getCommands();
        }

        private string preFormat(string[] words)
        {
            string result = "";
            for (int i = 1; i < words.Length; i++)
            {
                result += words[i];
            }
            return result;
        }

        private void addError(String message, int lineNumber)
        {
            Error error = new Error();
            error.setLine(lineNumber);
            error.setMessage(message);
            errors.Add(error);
        }

        private void parseLine(string lineToBeParsed, int lineNumber)
        {
            string line = lineToBeParsed.Trim();
            if (line.Length <= 0)
            {
                return;
            }
            string[] words = line.Split(' ');
            string payload = preFormat(words);
            Statement statement = null;

            switch (words[0].ToUpper())
            {
                case "METHOD":
                    Method method = commandFactory.createMethod(payload, lineNumber);
                    method.parse(errors);
                    statements.Push(method);
                    break;

                case "ENDENDMETHOD":
                    statement = (Statement)statements.Pop();
                    if (statement is Method)
                    {
                        methods.Add((Method)statement);
                    }
                    else
                    {
                        addError("EndWhile does not match its While Statement", lineNumber);
                    }
                    break;

                case "WHILE":
                    WhileStatement whileStatement = commandFactory.createWhileStatement(payload, lineNumber);
                    whileStatement.parse(errors);
                    statements.Push(whileStatement);
                    break;

                case "ENDWHILE":
                    statement = (Statement)statements.Pop();
                    if (statement is WhileStatement)
                    {
                        getProperCommands().Add((WhileStatement)statement);
                    }
                    else
                    {
                        addError("EndWhile does not match its While Statement", lineNumber);
                    }
                    break;

                case "IF":
                    IfStatement ifStatement = commandFactory.createIfStatement(payload, lineNumber);
                    ifStatement.parse(errors);
                    statements.Push(ifStatement);
                    break;

                case "ENDIF":
                    statement = (Statement)statements.Pop();
                    if (statement is IfStatement)
                    {
                        getProperCommands().Add((IfStatement)statement);
                    }
                    else
                    {
                        addError("EndIf does not match its If Statement", lineNumber);
                    }
                    break;

                case "DRAWTO":
                    try
                    {
                        DrawTo drawTo = commandFactory.createDrawToCommand(payload, lineNumber);
                        drawTo.parse(errors);
                        getProperCommands().Add(drawTo);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("DRAWTO " + e.Message);
                    }
                    break;

                case "FILL":
                    try
                    {
                        SetFilled setFilled = commandFactory.createSetFilledCommand(payload, lineNumber);
                        setFilled.parse(errors);
                        getProperCommands().Add(setFilled);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("FILL " + e.Message);
                    }
                    break;

                case "FLASHING":
                    try
                    {
                        SetFlashing setFlashing = commandFactory.createSetFlashingCommand(payload, lineNumber);
                        setFlashing.parse(errors);
                        getProperCommands().Add(setFlashing);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("FILL " + e.Message);
                    }
                    break;

                case "COLOUR":
                    try
                    {
                        SetColour setColour = commandFactory.createSetColourCommand(payload, lineNumber);
                        setColour.parse(errors);
                        getProperCommands().Add(setColour);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("COLOUR " + e.Message);
                    }
                    break;

                case "MOVETO":
                    try
                    {
                        MoveTo moveto = commandFactory.createMoveToCommand(payload, lineNumber);
                        moveto.parse(errors);
                        getProperCommands().Add(moveto);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("MOVETO " + e.Message);
                    }
                    break;

                case "CIRCLE":
                    try
                    {
                        DrawCircle drawCircle = commandFactory.createDrawCircleCommand(payload, lineNumber);
                        drawCircle.parse(errors);
                        getProperCommands().Add(drawCircle);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("CIRCLE " + e.Message);
                    }
                    break;

                case "TRI":
                case "TRIANGLE":
                    try
                    {
                        DrawTriangle drawTriangle = commandFactory.createDrawTriangleCommand(payload, lineNumber);
                        drawTriangle.parse(errors);
                        getProperCommands().Add(drawTriangle);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("TRI " + e.Message);
                    }
                    break;

                case "RECT":
                case "RECTANGLE":
                    try
                    {
                        DrawRectangle drawRectangle = commandFactory.createDrawRectangleCommand(payload, lineNumber);
                        drawRectangle.parse(errors);
                        getProperCommands().Add(drawRectangle);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("RECT " + e.Message);
                    }
                    break;

                default:
                    if (line.EndsWith(")"))
                    {
                        method = commandFactory.createMethod(line, lineNumber);
                        method.parse(errors);
                        Method defined = null;
                        if (methods.Count > 0)
                        {
                            foreach (Method m in methods)
                            {
                                if (m.getName() == method.getName())
                                {
                                    defined = m;
                                }
                            }
                        }
                        if (null == defined)
                        {
                            Command.addError("Method must be defined before using.", lineNumber, errors);
                        }
                        else
                        {
                            if (defined.getParameters().Count != method.getParameters().Count)
                            {
                                Command.addError("Paramater list does not match.", lineNumber, errors);
                            }
                            defined.setParameters(method.getParameters());
                            getProperCommands().Add(defined);
                        }
                    }
                    else
                    {
                        try
                        {
                            Assignment assignment = new Assignment(words[0] + payload, lineNumber);
                            Variable variable = assignment.parse(errors);
                            if (statements.Count <= 0)
                                Command.addVariable(variable);
                            getProperCommands().Add(assignment);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("DEFAULT " + e.Message);
                        }
                    }
                    break;
            }
        }

        public void setErrors(ArrayList errors)
        {
            this.errors = errors;
        }

        public ArrayList getCommands()
        {
            return commands;
        }

        public ArrayList getMethods()
        {
            return methods;
        }
    }
}
