using System.Collections.Generic;
using UnityEngine;

public sealed class HotKeyCells : InventoryCells
{
    public new IReadOnlyCollection<InventoryCell> Cells => _cells;

    private readonly List<InventoryCell> _cells;

    public HotKeyCells(InventoryData inventoryData) : base(inventoryData)
    {
        if (inventoryData is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryData));
        }
        else
        {
            _cells = FilingCells(InventoryData.HotKeySize, _inventoryData.HotKeyContainer);
        }
    }

    private protected sealed override List<InventoryCell> FilingCells(int size, Transform container, GameObject cellObject = null)
    {
        List<InventoryCell> cells = new List<InventoryCell>(size);

        for (int cell = 0; cell < size; cell++)
        {
            var hotKey = container.GetChild(cell).gameObject;
            var hotKeyCell = hotKey.GetComponent<HotKeyCell>();

            InitializeCellEventProperty(hotKey);
            
            cells.Add(hotKeyCell);
        }

        return cells;
    }
}
