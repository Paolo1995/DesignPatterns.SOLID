﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <summary>
// Liskov Substitution Principle
// "functions that use pointers to base classes must be able to use objects of derived classes without knowing it."
// Thus, the objects of the subclasses should behave in the same way as the objects of the superclass.
// </summary>
namespace DesignPatterns.SOLID
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
            
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Width = value; }
        }
    }

    public class LSP
    {
        public static int Area(Rectangle r) => r.Width * r.Height;
    }
}
