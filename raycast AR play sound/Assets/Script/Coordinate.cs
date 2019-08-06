using System;

public class Coordinate
{
    private double latitude { get; set; }
    private double longitude { get; set; }
    // in degrees. Default = 0.001
    private double radius;

    public Coordinate(double latitude, double longitude, double radius = 0.001)
    {
        this.latitude = latitude;
        this.longitude = longitude;
        this.radius = radius;
    }

    public bool checkWithin(double inLat, double inLong)
    {
        return Math.Pow(radius, 2) > Math.Pow(latitude - inLat, 2) + Math.Pow(longitude - inLong, 2);
    }

    public override string ToString()
    {
        return "Coordinate: lat=" + this.latitude + ", lon=" + this.longitude;
    }
}
