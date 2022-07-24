using System.Collections.Generic;
using UnityEngine;

public sealed class CraftCells : InventoryCells
{
    public new IReadOnlyCollection<InventoryCell> Cells => _cells;

    private readonly List<InventoryCell> _cells;

    public CraftCells(InventoryData inventoryData) : base (inventoryData)
    {
        _cells = FilingCells(InventoryData.CraftSize, inventoryData.CraftContainer, inventoryData.Craft);
    }

    private protected override List<InventoryCell> FilingCells(int size, Transform container, GameObject cellObject = null)
    {
        return null;
    }
}
