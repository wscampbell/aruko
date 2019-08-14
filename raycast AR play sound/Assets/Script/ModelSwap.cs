using UnityEngine;
using Vuforia;
using System.Collections;

public class ModelSwap : MonoBehaviour 
{
    public TrackableBehaviour theTrackable;
    private bool mSwapCube = false;
    private bool mSwapCapsule = false;
    private bool CapsuleActive = true;

    // Use this for initialization
    void Start () 
    {
        if (theTrackable == null)
        {
            Debug.Log ("Warning: Trackable not set !!");
        }
    }

    // Update is called once per frame
    void Update () 
    {
        if (mSwapCube && theTrackable != null) 
        {
            SwapCube();
            mSwapCube = false;
        }
        else if (mSwapCapsule && theTrackable != null)
        {
            SwapCapsule();
            mSwapCapsule = false;
        }
    }

    void OnGUI() 
    {
        if (CapsuleActive)
        {
            if (GUI.Button (new Rect(50,50,240,80), "Swap Cube")) 
            {
                mSwapCube = true;
            }
        }
        else
        {
            if (GUI.Button (new Rect(50,50,240,80), "Swap Capsule"))
            {
                mSwapCapsule = true;
            }
        }
        
    }

    private void SwapCube() 
    {
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.active = false;
        }

        // Create a simple cube object
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Re-parent the cube as child of the trackable gameObject
        cube.transform.parent = theTrackable.transform;

        // Adjust the position and scale
        // so that it fits nicely on the target
        cube.transform.localPosition = new Vector3(0,0.2f,0);
        cube.transform.localRotation = Quaternion.identity;
        cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Make sure it is active
        cube.active = true;
        CapsuleActive = false;
    }

    private void SwapCapsule() 
    {
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.active = false;
        }

        // Create a simple cube object
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        // Re-parent the cube as child of the trackable gameObject
        capsule.transform.parent = theTrackable.transform;

        // Adjust the position and scale
        // so that it fits nicely on the target
        capsule.transform.localPosition = new Vector3(0,0.2f,0);
        capsule.transform.localRotation = Quaternion.identity;
        capsule.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Make sure it is active
        capsule.active = true;
        CapsuleActive = true;
    }
}