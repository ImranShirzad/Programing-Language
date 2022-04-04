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
            class DrawTo : Command
            {
                private string commandLine;
                private int lineNumber;
                private string valueX;
                private string valueY;

                public DrawTo(string commandLine, int lineNumber)
                {
                    this.commandLine = commandLine;
                    this.lineNumber = lineNumber;
                }
                public override void execute()
                {
                    ArrayList errors = new ArrayList();
                    Point end = new Point(evaluateInteger(valueX, lineNumber, errors), evaluateInteger(valueY, lineNumber, errors));
                    Form1.shapes.Add(Form1.factoryCreator.factoryMethod().createLine(
                        new Point(Form1.currentPoint.X, Form1.currentPoint.Y), end));
                    Form1.currentPoint = new Point(end.X, end.Y);
                }
                public void parse(ArrayList errors)
                {
                    string[] st = commandLine.Split(',');
                    if (st.Length != 2)
                    {
                        addError("DrawTo command needs two params separated by comma", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }
                    try
                    {
                        valueX = st[0];
                        valueY = st[1];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("parse " + e.Message);
                        addError("The given param can not be parsed as an integer", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }
                }
            }
        }
    }
}
