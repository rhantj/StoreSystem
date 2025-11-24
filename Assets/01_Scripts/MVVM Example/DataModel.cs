using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/ItemData")]
public class ItemData : ScriptableObject
{
    public string d_Name;
    public string d_Description;
    public int d_Count;
    public int d_Price;
    public Sprite d_Icon;
    public bool canStack;
}
