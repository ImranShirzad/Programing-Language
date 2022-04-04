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
            public abstract class AseShape
            {
                protected bool status;
                protected bool flashing;
                protected bool filled;
                protected Color color;

                public Pen getPen()
                {
                    Pen pen = new Pen(color);
                    return pen;
                }

                public Brush getBrush()
                {
                    Brush brush = new SolidBrush(color);
                    return brush;
                }

                public void setFlashing(bool flashing)
                {
                    this.flashing = flashing;
                }

                public void setFilled(bool filled)
                {
                    this.filled = filled;
                    this.status = filled;
                }

                public AseShape()
                {
                    filled = false;
                }

                public void setColor(Color color)
                {
                    this.color = color;
                }

                public abstract void draw(Graphics graphics);
            }
        }
    }
}
