
using System.Drawing;

namespace Labwork_3
{
    public class Point
    {
        public double Xaxis { get; set; }
        public double Yaxis { get; set; }

        public Point(double Xaxis, double Yaxis)
        {
            this.Xaxis = Xaxis;
            this.Yaxis = Yaxis;
        }

        public Point(double sharedAxis)
        {
            Xaxis = sharedAxis;
            Yaxis = sharedAxis;
        }

        public Point() { }

        public static Point operator ++(Point point)
        {
            point.Xaxis++;
            point.Yaxis++;
            return point;
        }

        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            return (firstPoint.Xaxis == secondPoint.Xaxis) && (firstPoint.Yaxis == secondPoint.Yaxis);
        }

        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            return !((firstPoint.Xaxis == secondPoint.Xaxis) && (firstPoint.Yaxis == secondPoint.Yaxis));
        }
    }
}
