using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace products
    {
        namespace shapes
        {
            public class LineSegment : AseShape
            {
                private Point start;
                private Point end;

                public void setStart(Point start)
                {
                    this.start = start;
                }

                public void setEnd(Point end)
                {
                    this.end = end;
                }

                public override void draw(Graphics graphics)
                {
                    graphics.DrawLine(getPen(), start, end);
                }
            }
        }
    }
}
