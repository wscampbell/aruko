using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUI : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform menuPanel;
    Camera ARCamera;

    List<string> flatFiles = new List<string>();
    List<Sprite> sprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        ARCamera = Camera.main;
        // retrieves image names from tour file
        EditourTour editourTour = JSONHelper.JSONToEditourTour(JSONHelper.JSONFromFilename("ritsu-tour"));
        foreach (EditourRegion editourRegion in editourTour.regions)
        {
            flatFiles.AddRange(editourRegion.images);
        }

        // print out all of the filenames in flatfiles
        foreach (string str in flatFiles)
        {
            Debug.Log(str);
        }

        // loads all images as Sprites for application to buttons
        Texture2D[] textures = Resources.LoadAll<Texture2D>("ritsu-tour");
        //Sprite[] testSprites = Resources.LoadAll<Sprite>("ritsu-tour");
        Debug.Log("textures length: " + textures.Length);
        foreach (Texture2D texture in textures)
        {
            //Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Debug.Log(texture.width + " " + texture.height);
            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0));

            sprites.Add(sprite);
        }
        //Debug.Log("sprites length: " + testSprites.Length);

        // add buttons to dropdown
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponent<Image>().sprite = sprites[i];
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(
                () => { ARCamera.GetComponent<ModelSwap>().SwapPic(flatFiles[index]); }
            );
            //button.AddComponent<LayoutElement>();
            //button.GetComponent<LayoutElement>().minHeight = textures[i].height;
            button.transform.parent = menuPanel;
            button.GetComponent<RectTransform>().localScale = new Vector3(1, textures[i].height / textures[i].width, 1);
            button.SetActive(true);
        }
    }
}
