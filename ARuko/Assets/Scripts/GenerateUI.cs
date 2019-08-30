using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUI : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform menuPanel;
    Camera ARCamera;

    private List<string> flatFiles = new List<string>();
    private List<Sprite> sprites = new List<Sprite>();

    public static Dictionary<string, GameObject> buttonMap = new Dictionary<string, GameObject>();

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
        List<Texture2D> textures = new List<Texture2D>();
        foreach (string flatFile in flatFiles)
        {
            Texture2D texture = Resources.Load<Texture2D>("ritsu-tour/" + (flatFile.Split('.'))[0]);
            textures.Add(texture);
        }
        //Sprite[] testSprites = Resources.LoadAll<Sprite>("ritsu-tour");
        foreach (Texture2D texture in textures)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0));
            sprites.Add(sprite);
        }

        // add buttons to dropdown
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponent<Image>().sprite = sprites[i];
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(
                () => { ARCamera.GetComponent<ModelSwap>().SwapPic(flatFiles[index]); }
            );
            button.transform.parent = menuPanel;
            button.GetComponent<RectTransform>().localScale = new Vector3(1, textures[i].height / textures[i].width, 1);
            buttonMap.Add(flatFiles[i], button);
        }
    }
}
