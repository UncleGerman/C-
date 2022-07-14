using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public int InventorySize { get => _inventorySize; set => _inventorySize = value; }
    public Transform InventoryContainer { get => _inventoryContainer; set => _inventoryContainer = value; }
    public GameObject Cell { get => _cell; set => _cell = value; }
    public InventorySystem InventorySystem { get => _inventorySystem; set => _inventorySystem = value; }
    public static int HotKeySize => _hotKeySize;
    public Transform HotKeyContainer { get => _hotKeyContainer; set => _hotKeyContainer = value; }
    public static int EquippedItemSize => _equippedItemSize;
    public Transform EquippedItemContainer { get => _equippedItemContainer; set => _equippedItemContainer = value; }

    [SerializeField] private int _inventorySize;
    [SerializeField] private Transform _inventoryContainer;
    [SerializeField] private GameObject _cell;
    [Space]
    [SerializeField] private InventorySystem _inventorySystem;
    [Space]
    private const int _hotKeySize = 10;
    [SerializeField] private Transform _hotKeyContainer;
    [Space]
    private const int _equippedItemSize = 4;
    [SerializeField] private Transform _equippedItemContainer;
}
