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
            class DrawTriangle : Command
            {
                private String commandLine;
                private int lineNumber;
                private String width;
                private String height;

                public DrawTriangle(String commandLine, int lineNumber)
                {
                    this.commandLine = commandLine;
                    this.lineNumber = lineNumber;
                }

                public override void execute()
                {
                    ArrayList errors = new ArrayList();
                    Form1.shapes.Add(Form1.factoryCreator.factoryMethod().createTriangle(
                        Form1.currentPoint,
                        evaluateInteger(width, lineNumber, errors),
                        evaluateInteger(height, lineNumber, errors)));
                }

                public void parse(ArrayList errors)
                {
                    string[] st = commandLine.Split(',');
                    if (st.Length != 2)
                    {
                        addError("Triangle command needs two params", lineNumber, errors);
                        throw new Exception("Syntax checking is failed");
                    }
                    try
                    {
                        width = st[0];
                        height = st[1];
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
