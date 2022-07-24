public class CraftEvent
{
    private protected readonly InventoryEventHandler _inventoryEventHandler;

    public CraftEvent(InventoryEventHandler inventoryEventHandler) => _inventoryEventHandler = inventoryEventHandler ?? throw new System.ArgumentNullException(nameof(inventoryEventHandler));

    private protected void RemoveItems()
    {
        foreach (AssetItem item in _inventoryEventHandler.InventoryHandler.Craft.Items)
        {
            var itemIndex =_inventoryEventHandler.InventoryHandler.Craft.GetItemIndex(item);
            var cell = _inventoryEventHandler.InventoryHandler.InventoryCellsHandler.CraftCells.GetCell(itemIndex);
            _inventoryEventHandler.RemoveItem(cell);
        }
    }
}
