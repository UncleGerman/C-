using System.Collections.Generic;
using UnityEngine;

public sealed class InventoryEvent : MonoBehaviour
{
    private readonly InventorySystem _inventorySystem;
    private List<AssetItem> _firstItems;
    private List<AssetItem> _secondItems;
    private Cell _cell;
    private int _itemIndex;

    private Cell _firstCell;
    private Cell _secondCell;

    private int _firstIndex;
    private int _secondIndex;

    public InventoryEvent(InventorySystem inventorySystem)
    {
        _inventorySystem = inventorySystem;
        _inventorySystem.Inventory.AddItem += CheckInventory;
        _inventorySystem.Inventory.RemoveItem += RemoveItem;
        _inventorySystem.Inventory.SwapItem += SwapItemsInLists;
    }

    private void CheckInventory(AssetItem item, ref List<AssetItem> items)
    {
        _firstItems = items; 
        if(IsEmptyPlace())
        {
            if(IsAvailabilityItem(item))
            {
                if(item.Stackable)
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
        foreach (AssetItem item in _firstItems)
        {
            if (item.itemType == 0)
            {
                ItemInitialization(item);
                return true;
            }
        }
        return false;
    }

    private bool IsAvailabilityItem(AssetItem itemData)
    {
        foreach (AssetItem item in _firstItems)
        {
            if (item.Name == itemData.Name)
            {
                ItemInitialization(item);
                return true;
            }
        }
        return false;
    }

    private void ItemInitialization(AssetItem item)
    {
        _cell = _inventorySystem.InventoryCellCollection.InventoryCells.GetCell(_firstItems.IndexOf(item));
        _itemIndex = _firstItems.IndexOf(item);
    }

    private void AddItem(AssetItem item)
    {
        _firstItems[_itemIndex] = item;
        _cell.Amount += item.Amount;
        _cell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{item.itemType}/{item.Name}"));
    }

    private void RemoveItem(ref List<AssetItem> items, Cell cell)
    {
        _firstItems = items;

        if (cell.Amount > 1)
            cell.Amount -= 1;
        else
        {
            cell.Amount = default;
            items[_inventorySystem.InventoryCellCollection.GetIndexInTypeCollection(cell)] = new AssetItem();
        }
    }

    #region SwapItem
    private void SwapItemsInLists(ref List<AssetItem> firstItems, ref List<AssetItem> secondItems, Cell firstCell, Cell secondCell)
    {
        _secondItems = secondItems;
        _firstItems = firstItems;

        _firstCell = firstCell;
        _secondCell = secondCell;

        _firstIndex = _inventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_firstCell);
        _secondIndex = _inventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_secondCell);

        switch (firstCell.cellType)
        {
            case Cell.CellType.Cell:
                {
                    SetItem();
                    break;
                }
            case Cell.CellType.HotKey:
                {
                    switch (_secondCell.cellType)
                    {
                        case Cell.CellType.HotKey:
                            {
                                SetItem();
                                break;
                            }
                        default:
                            {
                                SetItem();
                                break;
                            }
                    }
                    break;
                }
            case Cell.CellType.EquipSlot:
                {
                    switch (_secondCell.cellType)
                    {
                        case Cell.CellType.HotKey:
                            {
                                SetItem();
                                break;
                            }
                        default:
                            {
                                if (SuitableType())
                                    SetItem();
                                else
                                    Debug.Log("ItemData = Null");
                                break;
                            }
                    }

                    break;
                }
        }
    }

    private void SetItem()
    {
        SwapAmount();

        AssetItem item;

        if (_firstCell.cellType == _secondCell.cellType)
        {
            _firstCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{_firstItems[_secondIndex].itemType}/{_firstItems[_secondIndex].Name}"));
            _secondCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{_firstItems[_firstIndex].itemType}/{_firstItems[_firstIndex].Name}"));

            item = _firstItems[_secondIndex];
            _firstItems[_secondIndex] = _firstItems[_firstIndex];
            _firstItems[_firstIndex] = item;
        }
        else
        {
            _firstCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{_secondItems[_secondIndex].itemType}/{_secondItems[_secondIndex].Name}"));
            _secondCell.SetSprite(Resources.Load<Sprite>($"Items/Sprite/{_firstItems[_firstIndex].itemType}/{_firstItems[_firstIndex].Name}"));

            item = _firstItems[_firstIndex];
            _firstItems[_firstIndex] = _secondItems[_secondIndex];
            _secondItems[_secondIndex] = item;
        }
    }

    private void SwapAmount()
    {
        int amount = _firstCell.Amount;
        _firstCell.Amount = _secondCell.Amount;
        _secondCell.Amount = amount;
    }

    #endregion

    //
    private bool SuitableType()
    {
        EquippedItem equippedItem = _firstCell.GetComponent<EquippedItem>();
        AssetItemArmor itemAsset;

        AssetItem item = _secondItems[_secondIndex];

        switch (item.itemType)
        {
            case AssetItem.ItemType.Armor:
                {
                    itemAsset = Resources.Load<AssetItemArmor>($"Items/Data/{item.itemType}/{item.Name}");
                    break;
                }
            case AssetItem.ItemType.Weapon:
                {
                    itemAsset = Resources.Load<AssetItemArmor>($"Items/Data/{item.itemType}/{item.Name}");
                    break;
                }
            default:
                {
                    itemAsset = default;
                    break;
                }
        }
        if (itemAsset == null)
            return false;
        else
        {
            if (equippedItem.equippedType == (EquippedItem.EquippedType)itemAsset.itemType)
                return true;
            else
                return false;
        }
    }
}
