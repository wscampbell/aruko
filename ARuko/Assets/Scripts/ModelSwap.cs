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
        Camera user = Camera.main;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }

        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        // Adjust the position and scale so that it fits nicely on the target
        model.transform.localPosition = new Vector3(0, 0.05f, 0);
        model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        model.transform.LookAt(new Vector3(user.transform.position.x, user.transform.position.y, user.transform.position.z));

        // Make sure it is active
        model.SetActive(true);
    }

    public void SwapModel(string filename)
    {
        // Create a simple cube object
        GameObject model = Instantiate(Resources.Load(filename, typeof(GameObject))) as GameObject;
        SwapModelFromModel(model);
    }

    public void SwapPic(string filename)
    {
        GameObject model = PlaneMaker.makePicPlane("ritsu-tour", filename);
        SwapModelFromModel(model);
    }

    public void orientModel()
    {
        GameObject trackableGameObject = theTrackable.gameObject;
        // if assumption that only one child exist ever changes, we gotta change this
        Transform child = trackableGameObject.transform.GetChild(0);
        Camera camera = Camera.main;
        Vector3 targetPosition = new Vector3(camera.transform.position.x, child.position.y, camera.transform.position.z);
        child.LookAt(targetPosition);
    }
}