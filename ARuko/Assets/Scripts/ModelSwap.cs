using UnityEngine;
using Vuforia;
using System.Collections;

public class ModelSwap : MonoBehaviour 
{
    // For testing
    /*
    private bool mSwapModel = false;
    private bool mSwapCapsule = false;
    private bool CapsuleActive = true;
    */

    public TrackableBehaviour theTrackable;

    // Use this for initialization
    void Start () 
    {
        if (theTrackable == null)
        {
            Debug.Log ("Warning: Trackable not set !!");
        }
    }

    public void SwapModel(string filename) 
    {
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.active = false;
            Destroy(child.gameObject);
        }

        // Create a simple cube object
        GameObject model = Instantiate(Resources.Load(filename, typeof(GameObject))) as GameObject;

        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        // Adjust the position and scale
        // so that it fits nicely on the target
        model.transform.localPosition = new Vector3(0,0.2f,0);
        model.transform.localRotation = Quaternion.identity;
        model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Make sure it is active
        model.active = true;
        
        // For testing
        //CapsuleActive = false;
    }

    // Also for testing
    /*
    // Update is called once per frame
    void Update () 
    {
        if (mSwapModel && theTrackable != null) 
        {
            SwapModel();
            mSwapModel = false;
        }
        else if (mSwapCapsule && theTrackable != null)
        {
            SwapCapsule();
            mSwapCapsule = false;
        }
    }

    void OnGUI() 
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 48;

        if (CapsuleActive)
        {
            if (GUI.Button (new Rect(50,50,480,160), "Swap Model", fontSize)) 
            {
                mSwapModel = true;
            }
        }
        else
        {
            if (GUI.Button (new Rect(50,50,480,160), "Swap Capsule", fontSize))
            {
                mSwapCapsule = true;
            }
        }
        
    }
    */

    

    // For testing
    /*
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
    */
}