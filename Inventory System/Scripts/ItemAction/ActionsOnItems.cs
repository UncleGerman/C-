using UnityEngine;

public sealed class ActionsOnItems : MonoBehaviour
{
    public GameObject ActionsContainer { get => _actionsContainer; set => _actionsContainer = value; }

    private Cell _cell;
    private ItemActions _itemActions;
    [SerializeField] private GameObject _actionsContainer;
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private HealthBar _healthBar;

    public void SetCell(Cell cell)
    {
        _cell = cell;
        _actionsContainer.transform.position = Input.mousePosition;
    }

    public void OnDropItem()
    {
        if (_cell.Amount > 0)
        {
            AssetItem item = GetItem();
            _inventorySystem.Inventory.OnRemoveItem(_cell);
            Instantiate(item.ItemPrefab);
        }
        else
            Debug.Log("Cell Empty!");
    }

    public void OnApllayItem() => _itemActions.ApplyItem(GetItem(), _cell);

    public void OnEquipItem()
    {

    }

    private void Start() => _itemActions = new ItemActions(_inventorySystem.Inventory, _healthBar);

    private AssetItem GetItem()
    {
        AssetItem item = new AssetItem();
        
        int itemIndex = _inventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_cell);
        
        switch (_cell.cellType)
        {
            case Cell.CellType.Cell:
                {
                    item = _inventorySystem.Inventory.GetItem(itemIndex);
                    break;
                }
            case Cell.CellType.HotKey:
                {
                    item = _inventorySystem.Inventory.GetItemHotKey(itemIndex);
                    break;
                }
            case Cell.CellType.EquipSlot:
                {
                    item = _inventorySystem.Inventory.GetItemEquip(itemIndex);
                    break;
                }
        }

        return item;
    }
}