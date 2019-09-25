using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignTranslation : MonoBehaviour
{
    // panel the translation appears on
    [SerializeField] GameObject TranslationZone;

    // Start is called before the first frame update
    void Start()
    {
        // make sure the panel isn't appearing when it shouldn't be
        TranslationZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // on mouse click/screen tap
        if (Input.GetMouseButtonDown(0))
        {
            try     // for preventing the NullReferenceException that occurs when the camera is deactivated
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Info")     // if you tap the 'i' button, call it's onClick methods
                    {
                        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
            catch
            {
                // do nothing
            }
        }
    }
}
