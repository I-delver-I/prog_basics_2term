
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
    }
}
