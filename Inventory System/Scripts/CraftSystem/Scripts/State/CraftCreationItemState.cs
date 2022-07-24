public sealed class CraftCreationItemState : State
{
    public delegate void CreationEvent();
    public event CreationEvent CraftEventAdd;

    private readonly CraftEventItemCreation _craftEventItemCreation;

    public CraftCreationItemState(CraftEventItemCreation craftEventItemCreation)
    {
        if (craftEventItemCreation is null)
        {
            throw new System.ArgumentNullException(nameof(craftEventItemCreation));
        }
        else
        {
            _craftEventItemCreation = craftEventItemCreation;
        }
    }

    public sealed override void Enter()
    {
        _craftEventItemCreation.EnterEvent();
        CraftEventAdd.Invoke();
    }

    public sealed override void Exit() => _craftEventItemCreation.ExitEvent();
}
