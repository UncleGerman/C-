using UnityEngine;

public sealed class InventoryEventAdd : IEvent
{
    public delegate void EventSetItem(int itemIndex, AssetItem item);
    public event EventSetItem SetItemInInventory;

    private readonly InventoryHandler _inventoryHandler;
    private readonly AddItemState _addItemState;

    private InventoryCell _cell;
    private int _itemIndex;

    public InventoryEventAdd(InventoryHandler inventoryHandler, AddItemState addItemState = null)
    {
        if (inventoryHandler is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryHandler));
        }
        else
        {
            _inventoryHandler = inventoryHandler;
            _addItemState = addItemState;
        }
    }

    public void EnterEvent()
    {
        if (_addItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_addItemState));
        }
        else
        {
            _addItemState.AddItem += IsAddItem;
        }
    }

    public void ExitEvent()
    {
        if (_addItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_addItemState));
        }
        else
        {
            _addItemState.AddItem -= IsAddItem;
        }
    }

    private void IsAddItem(AssetItem item)
    {
        if (IsEmptyPlace())
        {
            if (IsAvailabilityItem(item))
            {
                if (item.Stackable)
                {
                    _cell.Amount++;
                }
                else
                {
                    AddItem(item);
                }
            }
            else
            {
                AddItem(item);
            }
        }
        else
        {
            Debug.Log("Inventory Full!");
        }
    }

    private bool IsEmptyPlace()
    {
        foreach (AssetItem item in _inventoryHandler.Inventory.Items)
        {
            if (item.Id == 0)
            {
                Initialization(item);

                return true;
            }
            else
            {
                continue;
            }
        }

        return false;
    }

    private bool IsAvailabilityItem(AssetItem itemData)
    {
        foreach (AssetItem item in _inventoryHandler.Inventory.Items)
        {
            if (item.Id == itemData.Id)
            {
                Initialization(item);

                return true;
            }
            else
            {
                continue;
            }
        }

        return false;
    }

    private void Initialization(AssetItem item)
    {
        _itemIndex = _inventoryHandler.Inventory.GetItemIndex(item);
        _cell = _inventoryHandler.InventoryCellsHandler.InventoryCells.GetCell(_itemIndex);
    }

    private void AddItem(AssetItem item)
    {
        SetItemInInventory.Invoke(_itemIndex, item);
        _cell.Amount += item.Amount;
        _cell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{item.itemType}/{item.Name}"));
    }
}
