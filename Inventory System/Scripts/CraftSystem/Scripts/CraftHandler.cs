public sealed class CraftHandler
{
    private readonly InventoryEventHandler _inventoryEventHandler;
    private readonly StateMachine _stateMachine;

    public CraftHandler(InventoryEventHandler inventoryEventHandler)
    {
        if (inventoryEventHandler is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventHandler));
        }
        else
        {
            _inventoryEventHandler = inventoryEventHandler;
            _stateMachine = new StateMachine();
            _stateMachine.Initialize(new StartInventoryState());
        }
    }

    public void Craft()
    {
        var craftEventItemCreation = new CraftEventItemCreation(_inventoryEventHandler);
        var creationState = new CraftCreationItemState(craftEventItemCreation);
        _stateMachine.ChangeState(creationState);
    }

    public void Remove()
    {
        var craftEventRemove = new CraftEventRemove(_inventoryEventHandler);
        var craftRemoveItemState = new CraftRemoveItemState(craftEventRemove);
        _stateMachine.ChangeState(craftRemoveItemState);
    }
}
