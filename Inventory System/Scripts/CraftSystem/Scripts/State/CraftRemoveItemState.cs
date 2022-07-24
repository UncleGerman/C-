public sealed class CraftRemoveItemState : State
{
    public delegate void RemoveEvent();
    public event RemoveEvent CraftEventRemove;

    private readonly CraftEventRemove _craftEventRemove;

    public CraftRemoveItemState(CraftEventRemove craftEventRemove)
    {
        if (craftEventRemove is null)
        {
            throw new System.ArgumentNullException(nameof(craftEventRemove));
        }
        else
        {
            _craftEventRemove = craftEventRemove;
        }
    }

    public sealed override void Enter()
    {
        _craftEventRemove.EnterEvent();
        CraftEventRemove.Invoke();
    }

    public sealed override void Exit() => _craftEventRemove.ExitEvent();
}
