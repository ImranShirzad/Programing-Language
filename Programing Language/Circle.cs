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
            public class Circle : AseShape
            {
                private int radius;
                private Point center;

                public void setRadius(int value)
                {
                    radius = value;
                }

                public void setCenter(Point value)
                {
                    center = value;
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
                        graphics.FillEllipse(getBrush(), center.X - radius, center.Y - radius, radius + radius, radius + radius);
                    }
                    else
                    {
                        graphics.DrawEllipse(getPen(), center.X - radius, center.Y - radius, radius + radius, radius + radius);
                    }
                }
            }
        }
    }
}
