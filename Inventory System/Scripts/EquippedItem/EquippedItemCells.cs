using System.Collections.Generic;
using UnityEngine;

public sealed class EquippedItemCells : InventoryCells
{
    private readonly List<Cell> _cells;

    public EquippedItemCells(InventoryData inventoryData) : base(inventoryData) => _cells = FilingCells();

    private protected override List<Cell> FilingCells()
    {
        List<Cell> cells = new List<Cell>(InventoryData.EquippedItemSize);
        for (int cell = 0; cell < InventoryData.EquippedItemSize; cell++)
        {
            GameObject inventoryHotKey = _inventoryData.EquippedItemContainer.GetChild(cell).gameObject;
            Cell cellEquip = inventoryHotKey.GetComponent<Cell>();

            CellEvent cellEvent = inventoryHotKey.GetComponent<CellEvent>();
            cellEvent.InventorySystem = _inventoryData.InventorySystem;

            cells.Add(cellEquip);
        }
        return cells;
    }
}
