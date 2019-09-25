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
            Debug.Log("Warning: Trackable not set!!");
        }
    }

    // swap the given model with the model currently attached to the ground plane
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

        // Re-parent the model as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        // Adjust the position and scale so that it fits nicely on the target
        model.transform.localPosition = new Vector3(0, 0.05f, 0);
        model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        model.transform.LookAt(new Vector3(user.transform.position.x, user.transform.position.y, user.transform.position.z));

        // Make sure it is active
        model.SetActive(true);
    }

    // swap a given model file with the model currently on the ground plane
    public void SwapModel(string filename)
    {
        // Create a simple cube object
        GameObject model = Instantiate(Resources.Load(filename, typeof(GameObject))) as GameObject;
        SwapModelFromModel(model);
    }

    // make a cube with the given image on it, and swap it with the current ground plane model
    public void SwapPic(string filename)
    {
        GameObject model = PlaneMaker.makePicPlane("ritsu-tour", filename);
        SwapModelFromModel(model);
    }

    // get the ground plane model to face the user
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