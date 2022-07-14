using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Canvas Canvas { get => _canvas; private set => _canvas = value; }
    public Inventory Inventory { get => _inventory; private set => _inventory = value; }
    public InventoryCellCollection InventoryCellCollection { get => _inventoryCellCollection; set => _inventoryCellCollection = value; }
    public ActionsOnItems ActionsOnItems { get => _actionsOnItems; set => _actionsOnItems = value; }
    public InventoryUI InventoryUI { get => _inventoryUI; set => _inventoryUI = value; }

    [SerializeField] private Canvas _canvas;

    private Inventory _inventory;
    private InventoryCellCollection _inventoryCellCollection;

    [SerializeField] private ActionsOnItems _actionsOnItems;

    private InventoryData _inventoryData;
    private InventoryUI _inventoryUI;

    private void Awake()
    {
        _inventoryData = gameObject.GetComponent<InventoryData>();
        Inventory = new Inventory(_inventoryData);
        _inventoryCellCollection = new InventoryCellCollection(_inventoryData);
        _inventoryUI = gameObject.GetComponent<InventoryUI>();
        InventoryEvent inventoryEvent = new InventoryEvent(gameObject.GetComponent<InventorySystem>());
    }
}