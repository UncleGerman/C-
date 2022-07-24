using System.Collections.Generic;

public sealed class HotKey : Inventory
{
    public new IReadOnlyCollection<AssetItem> Items { get => _items; }
    private List<AssetItem> _items;

    public HotKey(InventoryData inventoryData, InventoryCellsHandler inventoryCellsHandler) : base(inventoryData, inventoryCellsHandler) => _items = FilingInventory(InventoryData.HotKeySize);

    public void EnterSetItem(InventoryEventSwap inventoryEventSwap = null)
    {
        if (inventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventSwap));
        }
        else
        {
            inventoryEventSwap.SetItemInHotkey += SetItem;
        }
    }

    public void ExitSetItem(InventoryEventSwap inventoryEventSwap = null)
    {
        if (inventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventSwap));
        }
        else
        {
            inventoryEventSwap.SetItemInHotkey -= SetItem;
        }
    }
}
