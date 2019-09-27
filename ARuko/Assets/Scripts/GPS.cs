using System.Collections;
using UnityEngine;
using UnityEngine.UI;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class GPS : MonoBehaviour
{
    public static GPS instance { set; get; }

    public float latitude { get; private set; }
    public float longitude { get; private set; }
    public float timesStarted = 0;

    private int timesUpdated = 0;
    public Text debugText;

    GameObject dialog = null;

    private void Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
        }
#endif

        instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            //dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("user has not enabled location services");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("unable to determine device location");
            yield break;
        }

        UpdatePosition();
        timesStarted++;
        yield break;
    }

    public void UpdatePosition()
    {
        // uncomment these to fake the coordinates for testing on computer
        //latitude = (float)34.979535;
        //longitude = (float)135.964329;

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        debugText.text = "lat: " + latitude + " lon: " + longitude + " len: " + Regions.length();
    }
}
