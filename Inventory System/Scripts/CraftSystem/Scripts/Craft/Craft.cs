using System.Collections.Generic;

public sealed class Craft : Inventory
{
    public new IReadOnlyCollection<AssetItem> Items { get => _items; }
    private List<AssetItem> _items;

    public Craft(InventoryData inventoryData, InventoryCellsHandler inventoryCellsHandler) : base(inventoryData, inventoryCellsHandler) => _items = FilingInventory(InventoryData.CraftSize);

    public void EnterSetItem(InventoryEventSwap inventoryEventSwap)
    {
        if (inventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventSwap));
        }
        else
        {
            inventoryEventSwap.SetItemInCraft += SetItem;
        }
    }

    public void ExitSetItem(InventoryEventSwap inventoryEventSwap)
    {
        if (inventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventSwap));
        }
        else
        {
            inventoryEventSwap.SetItemInCraft -= SetItem;
        }
    }
}
