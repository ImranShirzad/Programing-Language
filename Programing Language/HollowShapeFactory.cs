﻿using Programing_Language.products.shapes;
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
        public class HollowShapeFactory : AbstractShapeFactory
        {
            private Color color;

            public Circle createCircle(Point center, int radius)
            {
                Circle result = new Circle();
                result.setColor(color);
                result.setFilled(false);
                result.setRadius(radius);
                result.setFlashing(false);
                result.setCenter(center);
                return result;
            }

            public LineSegment createLine(Point start, Point end)
            {
                LineSegment result = new LineSegment();
                result.setColor(color);
                result.setStart(start);
                result.setEnd(end);
                result.setFlashing(false);
                return result;
            }

            public products.shapes.Rectangle createRectangle(Point current, int width, int height)
            {
                products.shapes.Rectangle result = new products.shapes.Rectangle();
                result.setColor(color);
                result.setFilled(false);
                result.setCenter(current);
                result.setWidth(width);
                result.setFlashing(false);
                result.setHeight(height);
                return result;
            }

            public Triangle createTriangle(Point current, int width, int height)
            {
                Triangle result = new Triangle();
                result.setColor(color);
                result.setFilled(false);
                result.setTopLeft(current);
                result.setWidth(width);
                result.setFlashing(false);
                result.setHeight(height);
                return result;
            }

            public void setColor(Color color)
            {
                this.color = color;
            }
        }
    }
}
