using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{
    public Sprite[] chapterImages;
    public GameObject contentPanel;
    public GameObject listItemPrefab;

    //ArrayList chaptersList;

    void Start()
    {
        populateChapters();
    }

    public void populateChapters()
    {
        List<Chapter> chapters = new List<Chapter>();
        EditourTour editourTour = JSONHelper.JSONToEditourTour(JSONHelper.JSONFromFilename("ritsu-tour"));
        List<EditourRegion> editourRegions = editourTour.regions;

        // TODO sort lexicographically
        int counter = 0;
        foreach (EditourRegion e in editourRegions)
        {
            //Debug.Log(e.name);
            //Debug.Log("count: " + e.images.Count.ToString());
            //Debug.Log((e.images[0].Split('.'))[0]);
            counter++;
            // TODO check to see if this works
            if (e.images.Count > 0)
            {
                //Debug.Log("ritsu-tour/" + (e.images[0].Split('.'))[0]);
                Texture2D texture = Resources.Load<Texture2D>("ritsu-tour/" + (e.images[0].Split('.'))[0]);
                Debug.Log(texture);
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0));
                chapters.Add(new Chapter(sprite, counter.ToString(), e.name));
            }
        }
        Debug.Log(chapters.Count);

        counter = 0;
        foreach (Chapter c in chapters)
        {
            GameObject newChapter = Instantiate(listItemPrefab) as GameObject;
            ListItemController controller = newChapter.GetComponent<ListItemController>() as ListItemController;
            Button button = newChapter.GetComponent<Button>() as Button;
            int index = counter;
            button.onClick.AddListener(() =>
            {
                Debug.Log(index);
                Debug.Log(Regions.getRegion(index).name);
                UpdateDropdown.chapterRegion = Regions.getRegion(index);
                Debug.Log("chapter region name: " + UpdateDropdown.chapterRegion.name);
            });
            controller.icon.sprite = c.icon;
            controller.itemName.text = c.itemName;
            controller.number.text = c.number;
            newChapter.transform.SetParent(contentPanel.transform);
            newChapter.transform.localScale = Vector3.one;
            counter++;
        }
    }
}
