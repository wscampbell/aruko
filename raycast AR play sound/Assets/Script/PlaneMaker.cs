using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject makePicPlane(string filename)
    {
        string pathName = "Tour/" + filename;
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        // TODO change this material to something not null
        plane.GetComponent<Renderer>().material.mainTexture = pathName;

        return plane;
    }
}
