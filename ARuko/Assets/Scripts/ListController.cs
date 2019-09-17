using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{
    public Sprite[] chapterImages;
    public GameObject contentPanel;
    public GameObject listItemPrefab;

    ArrayList chapters;

    void start()
    {
        chapters = new ArrayList() {
            new ListItem(chapterImages[0], "1", "INTRO"),
            new ListItem(chapterImages[1], "2", "ASHIKAGA"),
            new ListItem(chapterImages[2], "3", "ZEN BUDDHISM")
        };

        foreach(ListItem li in chapters) {
            GameObject newChapter = Instantiate(listItemPrefab) as GameObject;
            ListItemController controller = newChapter.GetComponent<ListItemController>();
            controller.icon.sprite = li.icon;
            controller.itemName.text = li.itemName;
            controller.number.text = li.number;
            newChapter.transform.parent = contentPanel.transform;
            newChapter.transform.localScale = Vector3.one;

        }
    }
}
