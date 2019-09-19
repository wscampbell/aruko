using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{
    public Sprite[] chapterImages;
    public GameObject contentPanel;
    public GameObject listItemPrefab;

    ArrayList chapters;

    void Start()
    {
        // TODO populate chapters from metadata
        chapters = new ArrayList() {
            new Chapter(chapterImages[0], "1", "INTRO"),
            new Chapter(chapterImages[1], "2", "ASHIKAGA"),
            new Chapter(chapterImages[2], "3", "ZEN BUDDHISM"),
            new Chapter(chapterImages[3], "4", "ETC"),
            new Chapter(chapterImages[4], "5", "AND SO ON"),
            new Chapter(chapterImages[5], "6", "BLAH BLAH BLAH"),
        };

        foreach (Chapter c in chapters) {
            GameObject newChapter = Instantiate(listItemPrefab) as GameObject;
            ListItemController controller = newChapter.GetComponent<ListItemController>() as ListItemController;
            controller.icon.sprite = c.icon;
            controller.itemName.text = c.itemName;
            controller.number.text = c.number;
            newChapter.transform.SetParent(contentPanel.transform);
            newChapter.transform.localScale = Vector3.one;
        }
    }
}
