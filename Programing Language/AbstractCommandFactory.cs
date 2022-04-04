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
        interface AbstractCommandFactory
        {
            Assignment createAssignmentCommand(string commandLine, int lineNumber);
            DrawCircle createDrawCircleCommand(string commandLine, int lineNumber);
            DrawTriangle createDrawTriangleCommand(string commandLine, int lineNumber);
            DrawRectangle createDrawRectangleCommand(string commandLine, int lineNumber);
            DrawTo createDrawToCommand(string commandLine, int lineNumber);
            MoveTo createMoveToCommand(string commandLine, int lineNumber);
            SetColour createSetColourCommand(string commandLine, int lineNumber);
            SetFilled createSetFilledCommand(string commandLine, int lineNumber);
            SetFlashing createSetFlashingCommand(string commandLine, int lineNumber);
            IfStatement createIfStatement(string commandLine, int lineNumber);
            WhileStatement createWhileStatement(string commandLine, int lineNumber);
            Method createMethod(string commandLine, int lineNumber);
        }
    }
}
