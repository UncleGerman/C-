using UnityEngine;

public class RemoveItemState : State
{
    public delegate void EventRemove(InventoryCell cell);
    public event EventRemove RemoveItem;

    public InventoryEventRemove InventoryEventRemove { private get; set; }

    private readonly InventoryCell _cell;

    public RemoveItemState(InventoryHandler inventoryHandler, InventoryCell inventoryCell)
    {
        if (inventoryHandler is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryHandler));
        }
        else
        {
            _cell = inventoryCell;
        }
    }

    public override void Enter()
    {
        if (_cell is null)
        {
            throw new System.NullReferenceException(nameof(_cell));
        }
        else
        {
            if (_cell.Amount > 0)
            {
                if (InventoryEventRemove is null)
                {
                    throw new System.NullReferenceException(nameof(InventoryEventRemove));
                }
                else
                {
                    InventoryEventRemove.EnterEvent();
                }
            }
            else
            {
                Debug.Log("Cell Empty!");
            }
        }
    }

    public override void Exit()
    {
        InventoryEventRemove.EnterEvent();
    }
}
