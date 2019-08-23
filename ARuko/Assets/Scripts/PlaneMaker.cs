using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    public static GameObject makePicPlane(string filename)
    {
        string pathName = "Tour/" + filename;
        Texture2D imageTexture = Resources.Load<Texture2D>(pathName);

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.GetComponent<Renderer>().material.mainTexture = imageTexture;

        return plane;
    }
}
