using UnityEngine;

public sealed class InventoryEventSwap : IEvent
{
    public delegate void EventSetItem(int itemIndex, AssetItem item);

    public event EventSetItem SetItemInInventory;
    public event EventSetItem SetItemInHotkey;
    public event EventSetItem SetItemInEquipped;
    public event EventSetItem SetItemInCraft;

    private readonly InventoryHandler _inventoryHandler;
    private readonly SwapItemState _swapItemState;

    public InventoryEventSwap(InventoryHandler inventoryHandler, SwapItemState swapItemState)
    {
        _inventoryHandler = inventoryHandler;
        _swapItemState = swapItemState;
    }

    public void EnterEvent()
    {
        if (_swapItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_swapItemState));
        }
        else
        {
            _swapItemState.SwapItem += SwapItemsInLists;
        }
    }

    public void ExitEvent()
    {
        if (_swapItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_swapItemState));
        }
        else
        {
            _swapItemState.SwapItem -= SwapItemsInLists;
        }
    }

    private void SwapItemsInLists(InventoryCell firstCell, InventoryCell secondCell)
    {
        AssetItem firstItem = _inventoryHandler.GetItemInType(firstCell);
        AssetItem secondItem = _inventoryHandler.GetItemInType(secondCell);

        if (SetItem(firstCell, secondItem) && SetItem(secondCell, firstItem))
        {
            firstCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{secondItem.itemType}/{secondItem.Name}"));
            secondCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{firstItem.itemType}/{firstItem.Name}"));

            SwapAmount(firstCell, secondCell);
        }
        else
        {
            Debug.Log("Don`t Swap Item");
        }
    }

    private bool SetItem(InventoryCell cell, AssetItem item)
    {
        int itemIndex = _inventoryHandler.InventoryCellsHandler.GetIndexInTypeCollection(cell);

        switch (cell.cellType)
        {
            case InventoryCell.CellType.Cell:
                {
                    SetItemInInventory(itemIndex, item);
                    return true;
                }
            case InventoryCell.CellType.HotKey:
                {
                    SetItemInHotkey(itemIndex, item);
                    return true;
                }
            case InventoryCell.CellType.EquipSlot:
                {
                    if (SuitableType(item, cell))
                    {
                        SetItemInEquipped(itemIndex, item);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            case InventoryCell.CellType.CraftSlot:
                {
                    SetItemInCraft(itemIndex, new AssetItem());
                    return true;
                }
            default:
                {
                    return false;
                }
        }
    }

    private bool SuitableType(AssetItem item, InventoryCell cell)
    {
        var equippedItem = cell.GetComponent<EquippedCell>().equippedType.ToString();

        string itemType;

        switch (item.itemType)
        {
            case AssetItem.ItemType.Armor:
                {
                    AssetItemArmor armor = Resources.Load<AssetItemArmor>($"Items/Data/{item.itemType}/{item.Name}");
                    itemType = armor.armorType.ToString();
                    break;
                }
            case AssetItem.ItemType.Weapon:
                {
                    AssetItemWeapon weapon = Resources.Load<AssetItemWeapon>($"Items/Data/{item.itemType}/{item.Name}");
                    itemType = weapon.itemType.ToString();
                    break;
                }
            default:
                {
                    return false;
                }
        }

        if (equippedItem == itemType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SwapAmount(InventoryCell firstCell, InventoryCell secondCell)
    {
        int amount = firstCell.Amount;
        firstCell.Amount = secondCell.Amount;
        secondCell.Amount = amount;
    }
}
