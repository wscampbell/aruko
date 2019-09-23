using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignTranslation : MonoBehaviour
{
    [SerializeField] GameObject TranslationZone;

    // Start is called before the first frame update
    void Start()
    {
        TranslationZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Info")
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
