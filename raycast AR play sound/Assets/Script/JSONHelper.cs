using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONHelper
{
    public static EditourRegion JSONToEditourRegion(string json)
    {
        EditourRegion editourRegion = (EditourRegion)JsonUtility.FromJson(json, typeof(EditourRegion));
    }
}
