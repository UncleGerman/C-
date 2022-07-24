public sealed class CraftEventRemove : CraftEvent, IEvent
{
    private readonly CraftRemoveItemState _craftRemoveItemState;

    public CraftEventRemove(InventoryEventHandler inventoryEventHandler, CraftRemoveItemState craftRemoveItemState = null) : base (inventoryEventHandler)
    {
        if (inventoryEventHandler is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventHandler));
        }
        else
        {
            _craftRemoveItemState = craftRemoveItemState;
        }
    }

    public void EnterEvent()
    {
        if (_craftRemoveItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_craftRemoveItemState));
        }
        else
        {
            _craftRemoveItemState.CraftEventRemove += Remove;
        }
    }

    public void ExitEvent()
    {
        if (_craftRemoveItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_craftRemoveItemState));
        }
        else
        {
            _craftRemoveItemState.CraftEventRemove -= Remove;
        }
    }

    private void Remove()
    {
        foreach (AssetItem item in _inventoryEventHandler.InventoryHandler.Craft.Items)
        {
            _inventoryEventHandler.AddItem(item);
        }

        RemoveItems();
    }
}
