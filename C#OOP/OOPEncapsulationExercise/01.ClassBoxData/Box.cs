using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private const string INVALID_SIDE_EXC_MSG =
            "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                ValidateSide(value, nameof(Length));
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                ValidateSide(value, nameof(Width));
                width = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                ValidateSide(value, nameof(Height));
                height = value;
            }
        }

        public void ValidateSide(double side,string parmName)
        {
            if (side<=0)
            {
                string currentMessage = String.Format(INVALID_SIDE_EXC_MSG, parmName);
                throw new ArgumentException(currentMessage);
            }
        }
        public double CalcSurfaceArea()
        {
            return 2*Length * Width +CalcLateralSurfaceArea();
        }
        public double CalcLateralSurfaceArea()
        {
            return 2 * Height * Width + 2 * Length * Height;
        }
        public double CalcVolume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {CalcSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {CalcLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {CalcVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
