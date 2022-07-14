using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        None = 0,
        Armor = 1,
        Weapon = 2,
        Food = 3,
        Potion = 4
    };

    public ItemType itemType;

    public AssetItem AssetItem => _assetItem;

    [SerializeField] private AssetItem _assetItem;

}
