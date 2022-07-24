public sealed class InventoryCellsHandler
{
    public InventoryCells InventoryCells => _inventoryCells;
    public HotKeyCells HotKeyCells => _hotKeyCells;
    public EquippedCells EquippedCells => _equippedCells;
    public CraftCells CraftCells => _craftCells;

    private readonly InventoryCells _inventoryCells;
    private readonly HotKeyCells _hotKeyCells;
    private readonly EquippedCells _equippedCells;
    private readonly CraftCells _craftCells;

    public InventoryCellsHandler(InventoryData inventoryData)
    {
        if (inventoryData is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryData));
        }
        else
        {
            _inventoryCells = new InventoryCells(inventoryData);
            _hotKeyCells = new HotKeyCells(inventoryData);
            _equippedCells = new EquippedCells(inventoryData);
            _craftCells = new CraftCells(inventoryData);
        }
    }

    public int GetIndexInTypeCollection(InventoryCell cell)
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
                        return _inventoryCells.GetIndex(cell);
                    }
                case InventoryCell.CellType.HotKey:
                    {
                        return _hotKeyCells.GetIndex(cell);
                    }
                case InventoryCell.CellType.EquipSlot:
                    {
                        return _equippedCells.GetIndex(cell);
                    }
                case InventoryCell.CellType.CraftSlot:
                    {
                        return _craftCells.GetIndex(cell);
                    }
                default:
                    {
                        throw new System.NullReferenceException(nameof(cell.cellType));
                    }
            }
        }
    }
}
