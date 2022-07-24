public sealed class AddItemState : State
{
    public delegate void EventAdd(AssetItem item);
    public event EventAdd AddItem;

    public InventoryEventAdd InventoryEventAdd { private get; set; }

    private readonly InventoryHandler _inventoryHandler;
    private readonly AssetItem _item;

    public AddItemState(InventoryHandler inventoryHandler, AssetItem item)
    {
        _inventoryHandler = inventoryHandler;
        _item = item;
    }

    public override sealed void Enter()
    {
        InventoryEventAdd.EnterEvent();

        if (_item is null)
        {
            throw new System.ArgumentNullException(nameof(_item));
        }
        else
        {
            if (InventoryEventAdd is null)
            {
                throw new System.ArgumentNullException(nameof(InventoryEventAdd));
            }
            else
            {
                _inventoryHandler.Inventory.EnterSetItem(InventoryEventAdd);
                AddItem.Invoke(_item);
            }
        }
    }

    public override sealed void Exit()
    {
        _inventoryHandler.Inventory.ExitSetItem(InventoryEventAdd);
        InventoryEventAdd.ExitEvent();
    }
}
