using System.Collections.Generic;
using UnityEngine;

public sealed class EquippedCells : InventoryCells
{
    public new IReadOnlyCollection<InventoryCell> Cells => _cells;

    private readonly List<InventoryCell> _cells;

    public EquippedCells(InventoryData inventoryData) : base(inventoryData)
    {
        if (inventoryData is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryData));
        }
        else
        {
            _cells = FilingCells(InventoryData.EquippednSize, inventoryData.EquippedContainer);
        }
    }

    private protected sealed override List<InventoryCell> FilingCells(int size, Transform container, GameObject cellObject = null)
    {
        List<InventoryCell> cells = new List<InventoryCell>(size);

        for (int cell = 0; cell < size; cell++)
        {
            var equipped = container.GetChild(cell).gameObject;
            var equippedCell = equipped.GetComponent<EquippedCell>();

            InitializeCellEventProperty(equipped);

            cells.Add(equippedCell);
        }

        return cells;
    }
}
