using UnityEngine;

public class ListItem
{
    public Sprite icon;
    public string number;
    public string itemName;

    public ListItem(Sprite icon, string number, string itemName)
    {
        this.icon = icon;
        this.number = number;
        this.itemName = itemName;
    }
}
