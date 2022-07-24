using UnityEngine;

public class InventoryEventHandler : MonoBehaviour
{
    public InventoryHandler InventoryHandler { get => _inventoryHandler; private set => _inventoryHandler = value; }

    private InventoryHandler _inventoryHandler;
    private InventoryData _inventoryData;
    private StateMachine _stateMachine;

    private void Start()
    {
        _inventoryData = gameObject.GetComponent<InventoryData>();
        _inventoryHandler = new InventoryHandler(_inventoryData);
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new StartInventoryState());
    }

    public bool AddItem(AssetItem item)
    {
        if (item is null)
        {
            throw new System.ArgumentNullException(nameof(item));
        }
        else
        {
            foreach(AssetItem assetItem in _inventoryHandler.Inventory.Items)
            {
                if (assetItem.Id == default)
                {
                    var addItemState = new AddItemState(_inventoryHandler, item);

                    InventoryEventAdd inventoryEventAdd = new InventoryEventAdd(_inventoryHandler, addItemState);

                    addItemState.InventoryEventAdd = inventoryEventAdd;

                    _stateMachine.ChangeState(addItemState);

                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }
    }

    public void SwapItem(InventoryCell firstCell, InventoryCell secondCell)
    {
        if (firstCell.Amount > 0 || secondCell.Amount > 0)
        {
            var swapItemState = new SwapItemState(_inventoryHandler, firstCell, secondCell);

            InventoryEventSwap inventoryEventSwap = new InventoryEventSwap(_inventoryHandler, swapItemState);

            swapItemState.InventoryEventSwap = inventoryEventSwap;

            _stateMachine.ChangeState(swapItemState);
        }
        else
        {
            Debug.Log("Don`t Swap!");
        }
    }

    public void RemoveItem(InventoryCell cell)
    {
        if (cell is null)
        {
            throw new System.ArgumentNullException(nameof(cell));
        }
        else
        {
            var removeItemState = new RemoveItemState(_inventoryHandler, cell);

            InventoryEventRemove inventoryEventRemove = new InventoryEventRemove(_inventoryHandler, removeItemState);

            removeItemState.InventoryEventRemove = inventoryEventRemove;

            _stateMachine.ChangeState(removeItemState);
        }
    }
}