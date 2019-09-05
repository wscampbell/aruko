using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    public static GameObject makePicPlane(string tourName, string filename)
    {
        //string pathName = "Assets/Tour/" + filename;
        string pathName = tourName + "/" + filename;
        Texture2D imageTexture = Resources.Load<Texture2D>(pathName);

        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        // TODO change this to an actual plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.GetComponent<Renderer>().material.mainTexture = imageTexture;

        return plane;
    }
}
