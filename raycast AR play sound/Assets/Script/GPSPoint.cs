// TODO override GetHashCode if needed
public class GPSPoint
{
    public double x { get; }
    public double y { get; }

    public GPSPoint(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public static GPSPoint operator +(GPSPoint point1, GPSPoint point2)
    {
        return new GPSPoint(point1.x + point2.x, point1.y + point2.y);
    }

    public static GPSPoint operator *(double scalar, GPSPoint point)
    {
        return new GPSPoint(point.x * scalar, point.y * scalar);
    }

    public override bool Equals(System.Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            GPSPoint point = (GPSPoint)obj;
            return (x == point.x) && (y == point.y);
        }
    }

    public override string ToString()
    {
        return string.Format("Point({0}, {1})", x, y);
    }
}
