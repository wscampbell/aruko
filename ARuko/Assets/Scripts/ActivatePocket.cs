using UnityEngine;

public class ActivatePocket : MonoBehaviour
{
    [SerializeField] GameObject pocketPanel;
    public void activate()
    {
        pocketPanel.SetActive(true);
    }
}
