using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Object3D
    {
        private double[][] Points;

        public Object3D(double [][] array)
        {
            Points = array;
        }

        public double[][] GetPoints()
        {
            return Points;
        }

        public void move(double px, double py, double pz)
        {
            foreach(double[] point in Points)
            {
                point[0] = point[0] + px; 
                point[1] = point[1] + py; 
                point[2] = point[2] + pz; 
            }
        }
        public void scale(double px, double py, double pz)
        {
            foreach (double[] point in Points)
            {
                point[0] = point[0] * px;
                point[1] = point[1] * py;
                point[2] = point[2] * pz;
            }
        }
        public void RotateY(double angle)
        {
            double rad = angle * Math.PI / 180;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);
            foreach (double[] point in Points)
            {
                point[0] = point[2] * sin + point[0] * cos;
                point[1] = point[1];
                point[2] = point[2] * cos - point[0] * sin;
            }
        }
        public void RotateX(double angle)
        {
            double rad = angle * Math.PI / 180;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);
            foreach (double[] point in Points)
            {
                point[0] = point[0];
                point[1] = point[1] * cos - point[2] * sin;
                point[2] = point[1] * sin + point[2] * cos;
            }
        }
        public void RotateZ(double angle)
        {
            double rad = angle * Math.PI / 180;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);
            foreach (double[] point in Points)
            {
                point[0] = point[0] * cos - point[1] * sin;
                point[1] = point[0] * sin + point[1] * cos;
                point[2] = point[2];             }
        }
    }
}
