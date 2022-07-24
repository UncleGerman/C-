using System.Collections.Generic;

public class Equipped : Inventory
{
    public new IReadOnlyCollection<AssetItem> Items { get => _items; }
    private List<AssetItem> _items;

    public Equipped(InventoryData inventoryData, InventoryCellsHandler inventoryCellsHandler) : base(inventoryData, inventoryCellsHandler) => _items = FilingInventory(InventoryData.HotKeySize);

    public void EnterSetItem(InventoryEventSwap inventoryEventSwap = null)
    {
        if (inventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventSwap));
        }
        else
        {
            inventoryEventSwap.SetItemInEquipped += SetItem;
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
            inventoryEventSwap.SetItemInEquipped -= SetItem;
        }
    }
}
