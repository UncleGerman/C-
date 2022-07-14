using System.Collections.Generic;
using UnityEngine;

public class InventoryCells : MonoBehaviour
{
    private readonly List<Cell> _cells;
    private protected InventoryData _inventoryData;

    public InventoryCells(InventoryData inventoryData)
    {
        _inventoryData = inventoryData;
        _cells = FilingCells();
    }

    public Cell GetCell(int itemIndex) => _cells[itemIndex];

    internal int GetIndex(Cell cell) => _cells.IndexOf(cell);

    private protected virtual List<Cell> FilingCells()
    {
        List<Cell> cells = new List<Cell>(_inventoryData.InventorySize);

        for (int cell = 0; cell < _inventoryData.InventorySize; cell++)
        {
            GameObject inventoryCell = Instantiate(_inventoryData.Cell);
            inventoryCell.transform.SetParent(_inventoryData.InventoryContainer);

            Cell cellController = inventoryCell.GetComponent<Cell>();

            CellEvent cellEvent = inventoryCell.GetComponent<CellEvent>();
            cellEvent.InventorySystem = _inventoryData.InventorySystem;

            cells.Add(cellController);
        }
        return cells;
    }
}
