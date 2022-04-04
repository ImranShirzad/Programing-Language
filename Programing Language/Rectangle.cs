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
            public class Rectangle : AseShape
            {
                private Point center;
                private int width;
                private int height;

                public void setCenter(Point center)
                {
                    this.center = center;
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
                    if (filled)
                    {
                        graphics.FillRectangle(getBrush(), center.X - width / 2, center.Y - height / 2, width, height);
                    }
                    else
                    {
                        graphics.DrawRectangle(getPen(), center.X - width / 2, center.Y - height / 2, width, height);
                    }
                }
            }
        }
    }
}
