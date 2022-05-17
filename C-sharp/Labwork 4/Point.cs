
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Point point = (Point)obj;

            return (Xaxis == point.Xaxis && Yaxis == point.Yaxis);
        }

        public static bool operator ==(Point firstPoint, Point secondPoint)
        {
            return firstPoint.Equals(secondPoint);
        }

        public static bool operator !=(Point firstPoint, Point secondPoint)
        {
            return !firstPoint.Equals(secondPoint);
        }
    }
}
