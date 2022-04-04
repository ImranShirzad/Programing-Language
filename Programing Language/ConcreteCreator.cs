using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programing_Language
{
    namespace factories
    {
        public class ConcreteCreator : Creator
        {
            private Color color = Color.Black;
            private bool filled = false;
            private bool flashing = false;
            private HollowShapeFactory hollowShapeFactory = new HollowShapeFactory();
            private FilledShapeFactory filledShapeFactory = new FilledShapeFactory();
            private FlashingShapeFactory flashingShapeFactory = new FlashingShapeFactory();

            public AbstractShapeFactory factoryMethod()
            {
                AbstractShapeFactory result = hollowShapeFactory;
                if (flashing)
                {
                    result = flashingShapeFactory;
                }
                else if (filled)
                {
                    result = filledShapeFactory;
                }
                result.setColor(color);
                return result;
            }

            public void reset()
            {
                color = Color.Black;
                filled = false;
                flashing = false;
            }

            public void setColor(Color color)
            {
                this.color = color;
            }

            public void setFilled(bool filled)
            {
                this.filled = filled;
            }

            public void setFlashing(bool flashing)
            {
                this.flashing = flashing;
            }
    }
    }
}
