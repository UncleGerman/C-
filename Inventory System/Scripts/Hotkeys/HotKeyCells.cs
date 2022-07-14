using System.Collections.Generic;
using UnityEngine;

public sealed class HotKeyCells : InventoryCells
{
    private readonly List<Cell> _cells;

    public HotKeyCells(InventoryData inventoryData) : base(inventoryData) => _cells = FilingCells();

    private protected override List<Cell> FilingCells()
    {
        List<Cell> cells = new List<Cell>(InventoryData.HotKeySize);
        for (int cell = 0; cell < InventoryData.HotKeySize; cell++)
        {
            GameObject inventoryHotKey = _inventoryData.HotKeyContainer.GetChild(cell).gameObject;
            Cell cellHotKey = inventoryHotKey.GetComponent<Cell>();

            CellEvent cellEvent = inventoryHotKey.GetComponent<CellEvent>();
            cellEvent.InventorySystem = _inventoryData.InventorySystem;

            HotKeys hotKeys = inventoryHotKey.GetComponent<HotKeys>();
            hotKeys.InventorySystem = _inventoryData.InventorySystem;
            
            cells.Add(cellHotKey);
        }
        return cells;
    }
}
