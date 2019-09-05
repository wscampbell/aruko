using UnityEngine;
using Vuforia;
using System.Collections;

public class ModelSwap : MonoBehaviour
{
    public TrackableBehaviour theTrackable;

    // Use this for initialization
    void Start()
    {
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }
    }

    public void SwapModelFromModel(GameObject model)
    {
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }

        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        // Adjust the position and scale
        // so that it fits nicely on the target
        model.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        model.transform.localPosition = new Vector3(0, 0.05f, 0);
        //model.transform.localRotation = Quaternion.identity;
        //model.transform.LookAt(this.transform);                       Tried this to get image planes to face user; maybe come back to later
        //model.transform.localRotation = Quaternion.Euler(90, 180, 0);

        // Make sure it is active
        model.SetActive(true);
        orientModel();
    }

    public void SwapModel(string filename)
    {
        // Create a simple cube object
        GameObject model = Instantiate(Resources.Load(filename, typeof(GameObject))) as GameObject;
        SwapModelFromModel(model);
    }

    public void SwapPic(string filename)
    {
        // TODO make this take in a tour as well
        GameObject model = PlaneMaker.makePicPlane("ritsu-tour", filename);
        SwapModelFromModel(model);
    }

    public void orientModel()
    {
        Debug.Log("orient model called");
        GameObject trackableGameObject = theTrackable.gameObject;
        Debug.Log("trackable game object: " + trackableGameObject);
        // if assumption that only one child exist ever changes, we gotta change this
        Transform child = trackableGameObject.transform.GetChild(0);
        Camera camera = Camera.main;
        Debug.Log(camera.transform.position.x);
        Debug.Log(camera.transform.position.y);
        Debug.Log(camera.transform.position.z);
        Vector3 targetPosition = new Vector3(camera.transform.position.x, child.position.y, camera.transform.position.z);
        child.LookAt(targetPosition);
        //child.transform.localRotation = Quaternion.Euler(90, 180, 0);
    }
}