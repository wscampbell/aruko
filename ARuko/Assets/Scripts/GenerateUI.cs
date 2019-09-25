using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateUI : MonoBehaviour
{
    [SerializeField] Transform menuPanel;

    private List<string> flatFiles = new List<string>();
    private List<Sprite> sprites = new List<Sprite>();
    public static Dictionary<string, GameObject> imageMap = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // retrieves image names from tour file
        EditourTour editourTour = JSONHelper.JSONToEditourTour(JSONHelper.JSONFromFilename("ritsu-tour"));
        foreach (EditourRegion editourRegion in editourTour.regions)
        {
            flatFiles.AddRange(editourRegion.images);
        }

        // loads all images as Sprites for image gallery
        List<Texture2D> textures = new List<Texture2D>();
        foreach (string flatFile in flatFiles)
        {
            Texture2D texture = Resources.Load<Texture2D>("ritsu-tour/" + (flatFile.Split('.'))[0]);
            textures.Add(texture);
        }

        // generate Sprites
        foreach (Texture2D texture in textures)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0, 0));
            sprites.Add(sprite);
        }

        // add images to gallery
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject gameObject = new GameObject();
            Image image = gameObject.AddComponent<Image>();
            image.sprite = sprites[i];
            gameObject.SetActive(false);
            gameObject.transform.parent = menuPanel;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(900, 900);
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            imageMap.Add(flatFiles[i], gameObject);
        }
    }
}
