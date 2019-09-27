using UnityEngine;

public class SpinKinkakuji : MonoBehaviour
{

    private float rotateValue = 1;
    void Update()
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, rotateValue);
        rotateValue += 0.13333f;
    }
}
