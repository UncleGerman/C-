public sealed class SwapItemState : State
{
    public delegate void EventSwap(InventoryCell firstCell, InventoryCell secondCell);
    public event EventSwap SwapItem;

    public InventoryEventSwap InventoryEventSwap { private get; set; }

    private readonly InventoryHandler _inventoryHandler;

    private readonly InventoryCell _firstCell;
    private readonly InventoryCell _secondCell;

    public SwapItemState(InventoryHandler inventoryHandler, InventoryCell firstCell, InventoryCell secondCell)
    {
        _inventoryHandler = inventoryHandler;
        _firstCell = firstCell;
        _secondCell = secondCell;
    }

    public override sealed void Enter()
    {
        if (InventoryEventSwap is null)
        {
            throw new System.ArgumentNullException(nameof(InventoryEventSwap));
        }
        else
        {
            InventoryEventSwap.EnterEvent();
            EventInTypeCell(_firstCell, true);
            EventInTypeCell(_secondCell, true);
            SwapItem.Invoke(_firstCell, _secondCell);
        }
    }

    public override sealed void Exit()
    {
        InventoryEventSwap.ExitEvent();
        EventInTypeCell(_firstCell, false);
        EventInTypeCell(_secondCell, false);
    }

    private void EventInTypeCell(InventoryCell cell, bool enter)
    {
        switch (cell.cellType)
        {
            case InventoryCell.CellType.Cell:
                {
                    if (enter == true)
                    {
                        _inventoryHandler.Inventory.EnterSetItem(null, InventoryEventSwap);
                    }
                    else
                    {
                        _inventoryHandler.Inventory.ExitSetItem(null, InventoryEventSwap);
                    }    
                    
                    break;
                }
            case InventoryCell.CellType.HotKey:
                {
                    if (enter == true)
                    {
                        _inventoryHandler.HotKey.EnterSetItem(InventoryEventSwap);
                    }
                    else
                    {
                        _inventoryHandler.HotKey.ExitSetItem(InventoryEventSwap);
                    }

                    break;
                }
            case InventoryCell.CellType.EquipSlot:
                {
                    if (enter == true)
                    {
                        _inventoryHandler.Equipped.EnterSetItem(InventoryEventSwap);
                    }
                    else
                    {
                        _inventoryHandler.Equipped.ExitSetItem(InventoryEventSwap);
                    }

                    break;
                }
            case InventoryCell.CellType.CraftSlot:
                {
                    if (enter == true)
                    {
                        _inventoryHandler.Craft.EnterSetItem(InventoryEventSwap);
                    }
                    else
                    {
                        _inventoryHandler.Craft.ExitSetItem(InventoryEventSwap);
                    }

                    break;
                }
        }
    }
}
