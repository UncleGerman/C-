public sealed class InventoryHandler
{
    public InventoryCellsHandler InventoryCellsHandler => _inventoryCellsHandler;
    public Inventory Inventory => _inventory;
    public HotKey HotKey => _hotKey;
    public Equipped Equipped => _equipped;
    public Craft Craft => _craft;

    private readonly InventoryCellsHandler _inventoryCellsHandler;
    private readonly Inventory _inventory;
    private readonly HotKey _hotKey;
    private readonly Equipped _equipped;
    private readonly Craft _craft;

    public InventoryHandler(InventoryData inventoryData)
    {
        if (inventoryData is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryData));
        }
        else
        {
            _inventoryCellsHandler = new InventoryCellsHandler(inventoryData);

            _inventory = new Inventory(inventoryData, _inventoryCellsHandler);
            _equipped = new Equipped(inventoryData, _inventoryCellsHandler);
            _hotKey = new HotKey(inventoryData, _inventoryCellsHandler);
            _craft = new Craft(inventoryData, _inventoryCellsHandler);
        }
    }

    public AssetItem GetItemInType(InventoryCell cell)
    {
        if (cell is null)
        {
            throw new System.ArgumentNullException(nameof(cell));
        }
        else
        {
            switch (cell.cellType)
            {
                case InventoryCell.CellType.Cell:
                    {
                        return _inventory.GetItem(cell);
                    }
                case InventoryCell.CellType.HotKey:
                    {
                        return _hotKey.GetItem(cell);
                    }
                case InventoryCell.CellType.EquipSlot:
                    {
                        return _equipped.GetItem(cell);
                    }
                case InventoryCell.CellType.CraftSlot:
                    {
                        return _craft.GetItem(cell);
                    }
                default:
                    {
                        throw new System.ArgumentNullException(nameof(cell.cellType));
                    }
            }
        }
    }
}
