using System.Collections.Generic;
using UnityEngine;

public class InventoryCells : MonoBehaviour
{
    public IReadOnlyCollection<InventoryCell> Cells => _cells;

    private readonly List<InventoryCell> _cells;
    private protected InventoryData _inventoryData;

    public InventoryCells(InventoryData inventoryData)
    {
        if (inventoryData is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryData));
        }
        else
        {
            _inventoryData = inventoryData;
            _cells = FilingCells(_inventoryData.InventorySize, _inventoryData.InventoryContainer, _inventoryData.Cell);
        }
    }

    internal protected InventoryCell GetCell(int itemIndex)
    {
        if(_cells.Count < itemIndex || itemIndex < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        else
        {
            return _cells[itemIndex];
        }
    }

    internal protected int GetIndex(InventoryCell cell)
    {
        if (cell is null)
        {
            throw new System.ArgumentNullException(nameof(cell));
        }
        else
        {
            Debug.Log(cell.cellType);
            Debug.Log(_cells.Count);
            Debug.Log(_cells.IndexOf(cell));
            return _cells.IndexOf(cell);
        }
    }

    private protected virtual List<InventoryCell> FilingCells(int size, Transform container, GameObject cellObject = null)
    {
        List<InventoryCell> cells = new List<InventoryCell>(size);

        for (int cell = 0; cell < size; cell++)
        {
            var inventoryCell = Instantiate(cellObject);
            inventoryCell.transform.SetParent(container);

            var cellController = inventoryCell.GetComponent<InventoryCell>();

            InitializeCellEventProperty(inventoryCell);

            cells.Add(cellController);
        }

        return cells;
    }

    private protected void InitializeCellEventProperty(GameObject cell)
    {
        var cellEvent = cell.GetComponent<CellEvent>();
        cellEvent.InventorySystem = _inventoryData.InventoryEventHandler;
        cellEvent.InventoryUI = _inventoryData.InventoryUI;
    }
}
