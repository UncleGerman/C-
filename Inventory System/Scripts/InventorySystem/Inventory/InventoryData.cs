using UnityEngine;

public sealed class InventoryData : MonoBehaviour
{
    public InventoryUI InventoryUI => _inventoryUI;

    public InventoryEventHandler InventoryEventHandler => _inventorySystem;

    public int InventorySize => _inventorySize;

    public Transform InventoryContainer => _inventoryContainer;

    public GameObject Cell => _cell;

    public static int HotKeySize => _hotKeySize;

    public Transform HotKeyContainer => _hotKeyContainer;

    public static int EquippednSize => _equippedSize;

    public Transform EquippedContainer => _equippedContainer;

    public static int CraftSize => _craftSize;

    public Transform CraftContainer => _craftContainer;

    public GameObject Craft => _craft;

    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private InventoryEventHandler _inventorySystem;

    [Header("Inventory Container Setting")]
    [Space]
    [SerializeField] private int _inventorySize;
    [SerializeField] private Transform _inventoryContainer;
    [SerializeField] private GameObject _cell;
    
    [Space]
    [Header("HotKey Container Setting")]
    private const int _hotKeySize = 10;
    [SerializeField] private Transform _hotKeyContainer;

    [Space]
    [Header("Equipped Container Setting")]
    private const int _equippedSize = 8;
    [SerializeField] private Transform _equippedContainer;

    [Space]
    [Header("Craft Container Setting")]
    private const int _craftSize = 2;
    [SerializeField] private Transform _craftContainer;
    [SerializeField] private GameObject _craft;
}
