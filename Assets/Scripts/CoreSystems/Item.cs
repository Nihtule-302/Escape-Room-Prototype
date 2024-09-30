using UnityEngine;

public class Item: MonoBehaviour
{
    public ItemType type;
}

public enum ItemType
{
    Bracelet,
    Necklace,
    Crown,
    StatueHandle
        
}