using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRegion
{
    bool encompasses(GPSPoint point);
}
