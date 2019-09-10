public interface IRegion
{
    string name { get; set; }
    bool encompasses(GPSPoint point);
}
