using UnityEngine;

public class AssetItem : ScriptableObject, IItem
{
    public int Id => _id;
    public int Amount => _amount;
    public float ItemWeight => _itemWeight;
    public string Name => _name;
    public string Description => _description;
    public bool Stackable => _stackable;
    public GameObject ItemPrefab => _itemPrefab;

    public enum ItemType
    {
        None = 0,
        Armor = 1,
        Weapon = 2,
        Food = 3,
        Potion = 4
    };

    public ItemType itemType;

    [SerializeField] private int _id;
    [SerializeField] private int _amount;
    [SerializeField] private float _itemWeight;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _stackable;
    [SerializeField] private GameObject _itemPrefab;
}
