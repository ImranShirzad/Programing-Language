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
            public class Triangle : AseShape
            {
                private Point topLeft;
                private int width;
                private int height;

                public void setTopLeft(Point topLeft)
                {
                    this.topLeft = topLeft;
                }

                public void setWidth(int width)
                {
                    this.width = width;
                }
                public void setHeight(int height)
                {
                    this.height = height;
                }

                public override void draw(Graphics graphics)
                {
                    if (flashing)
                    {
                        status = !status;
                        draw(graphics, status);
                    }
                    else
                    {
                        draw(graphics, filled);
                    }
                }

                private void draw(Graphics graphics, bool filled)
                {
                    Point[] points = new Point[3];
                    points[0] = new Point(topLeft.X, topLeft.Y - height / 2);
                    points[1] = new Point(topLeft.X - width / 2, topLeft.Y + height / 2);
                    points[2] = new Point(topLeft.X + width / 2, topLeft.Y + height / 2);
                    if (filled)
                    {
                        graphics.FillPolygon(getBrush(), points);
                    }
                    else
                    {
                        graphics.DrawPolygon(getPen(), points);
                    }
                }
            }
        }
    }
}
