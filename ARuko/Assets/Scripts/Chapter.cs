using UnityEngine;

public class Chapter
{
    public Sprite icon;
    public string number;
    public string itemName;

    public Chapter(Sprite icon, string number, string itemName)
    {
        this.icon = icon;
        this.number = number;
        this.itemName = itemName;
    }
}
