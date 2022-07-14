using UnityEngine;

public sealed class InventoryCellCollection : MonoBehaviour
{
    public InventoryCells InventoryCells => _inventoryCells;
    public HotKeyCells HotKeyCells => _hotKeyCells;
    public EquippedItemCells EquippedItemCells => _equippedItemCells;
    
    private readonly InventoryCells _inventoryCells;
    private readonly HotKeyCells _hotKeyCells;
    private readonly EquippedItemCells _equippedItemCells;

    public InventoryCellCollection(InventoryData inventoryData)
    {
        _inventoryCells = new InventoryCells(inventoryData);
        _hotKeyCells = new HotKeyCells(inventoryData);
        _equippedItemCells = new EquippedItemCells(inventoryData);
    }

    public int GetIndexInTypeCollection(Cell cell)
    {
        int cellIndex = default;

        switch (cell.cellType)
        {
            case Cell.CellType.Cell:
                {
                    cellIndex = _inventoryCells.GetIndex(cell);
                    break;
                }
            case Cell.CellType.HotKey:
                {
                    cellIndex = _hotKeyCells.GetIndex(cell);
                    break;
                }
            case Cell.CellType.EquipSlot:
                {
                    cellIndex = _equippedItemCells.GetIndex(cell);
                    break;
                }
        }
        return cellIndex;
    }
}
