using Programing_Language.products.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace factories
    {
        class BasicCommandFactory : AbstractCommandFactory
        {
            SetFlashing AbstractCommandFactory.createSetFlashingCommand(string commandLine, int lineNumber)
            {
                return new SetFlashing(commandLine, lineNumber);
            }

            Assignment AbstractCommandFactory.createAssignmentCommand(string commandLine, int lineNumber)
            {
                return new Assignment(commandLine, lineNumber);
            }

            DrawCircle AbstractCommandFactory.createDrawCircleCommand(string commandLine, int lineNumber)
            {
                return new DrawCircle(commandLine, lineNumber);
            }

            DrawRectangle AbstractCommandFactory.createDrawRectangleCommand(string commandLine, int lineNumber)
            {
                return new DrawRectangle(commandLine, lineNumber);
            }

            DrawTo AbstractCommandFactory.createDrawToCommand(string commandLine, int lineNumber)
            {
                return new DrawTo(commandLine, lineNumber);
            }

            DrawTriangle AbstractCommandFactory.createDrawTriangleCommand(string commandLine, int lineNumber)
            {
                return new DrawTriangle(commandLine, lineNumber);
            }

            IfStatement AbstractCommandFactory.createIfStatement(string commandLine, int lineNumber)
            {
                return new IfStatement(commandLine, lineNumber);
            }

            Method AbstractCommandFactory.createMethod(string commandLine, int lineNumber)
            {
                return new Method(commandLine, lineNumber);
            }

            MoveTo AbstractCommandFactory.createMoveToCommand(string commandLine, int lineNumber)
            {
                return new MoveTo(commandLine, lineNumber);
            }

            SetColour AbstractCommandFactory.createSetColourCommand(string commandLine, int lineNumber)
            {
                return new SetColour(commandLine, lineNumber);
            }

            SetFilled AbstractCommandFactory.createSetFilledCommand(string commandLine, int lineNumber)
            {
                return new SetFilled(commandLine, lineNumber);
            }

            WhileStatement AbstractCommandFactory.createWhileStatement(string commandLine, int lineNumber)
            {
                return new WhileStatement(commandLine, lineNumber);
            }
        }
    }
}
