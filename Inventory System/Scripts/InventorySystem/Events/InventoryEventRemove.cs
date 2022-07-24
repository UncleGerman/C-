public sealed class InventoryEventRemove : IEvent
{
    public delegate void EventSetItem(int itemIndex, AssetItem item);

    public event EventSetItem SetItemInInventory;
    public event EventSetItem SetItemInHotkey;
    public event EventSetItem SetItemInEquipped;
    public event EventSetItem SetItemInCraft;

    private readonly InventoryHandler _inventoryHandler;
    private readonly RemoveItemState _removeItemState;

    public InventoryEventRemove(InventoryHandler inventoryHandler, RemoveItemState removeItemState)
    {
        _inventoryHandler = inventoryHandler;
        _removeItemState = removeItemState;
    }

    public void EnterEvent()
    {
        if (_removeItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_removeItemState));
        }
        else
        {
            _removeItemState.RemoveItem += RemoveItem;
        }
    }

    public void ExitEvent()
    {
        if (_removeItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_removeItemState));
        }
        else
        {
            _removeItemState.RemoveItem -= RemoveItem;
        }
    }

    private void RemoveItem(InventoryCell cell)
    {
        if (cell.Amount > 1)
        {
            cell.Amount -= 1;
        }
        else
        {
            cell.Amount = default;
            var itemIndex = _inventoryHandler.InventoryCellsHandler.GetIndexInTypeCollection(cell);

            switch (cell.cellType)
            {
                case InventoryCell.CellType.Cell:
                    {
                        SetItemInInventory(itemIndex, new AssetItem());
                        break;
                    }
                case InventoryCell.CellType.HotKey:
                    {
                        SetItemInHotkey(itemIndex, new AssetItem());
                        break;
                    }
                case InventoryCell.CellType.EquipSlot:
                    {
                        SetItemInEquipped(itemIndex, new AssetItem());
                        break;
                    }
                case InventoryCell.CellType.CraftSlot:
                    {
                        SetItemInCraft(itemIndex, new AssetItem());
                        break;
                    }
            }

        }
    }
}
