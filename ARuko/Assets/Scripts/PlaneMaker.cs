using UnityEngine;

public class PlaneMaker : MonoBehaviour
{
    public static GameObject makePicPlane(string tourName, string filename)
    {
        //string pathName = "Assets/Tour/" + filename;
        string pathName = tourName + "/" + filename;
        Texture2D imageTexture = Resources.Load<Texture2D>(pathName);

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.GetComponent<Renderer>().material.mainTexture = imageTexture;

        plane.transform.rotation = Quaternion.Euler(90, 0, 0);


        return plane;
    }
}
