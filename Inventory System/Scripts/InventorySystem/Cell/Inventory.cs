using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public IReadOnlyCollection<AssetItem> Items => _items;

    private readonly List<AssetItem> _items;
    private readonly InventoryData _inventoryData;
    private readonly InventoryCellsHandler _inventoryCellsHandler;

    public Inventory(InventoryData inventoryData, InventoryCellsHandler inventoryCellsHandler)
    {
        _inventoryData = inventoryData;
        _inventoryCellsHandler = inventoryCellsHandler;
        _items = FilingInventory(_inventoryData.InventorySize);
    }

    public void EnterSetItem(InventoryEventAdd inventoryEventAdd = null, InventoryEventSwap inventoryEventSwap = null)
    {
        if (inventoryEventAdd != null)
        {
            inventoryEventAdd.SetItemInInventory += SetItem;
        }
        if (inventoryEventSwap != null)
        {
            inventoryEventSwap.SetItemInInventory += SetItem;
        }
    }

    public void ExitSetItem(InventoryEventAdd inventoryEventAdd = null, InventoryEventSwap inventoryEventSwap = null)
    {
        if (inventoryEventAdd != null)
        {
            inventoryEventAdd.SetItemInInventory -= SetItem;
        }

        if (inventoryEventSwap != null)
        {
            inventoryEventSwap.SetItemInInventory -= SetItem;
        }
    }

    public int GetItemIndex(AssetItem item)
    {
        if (item is null)
        {
            throw new System.ArgumentNullException(nameof(item));
        }
        else
        {
            return _items.IndexOf(item);
        }
    }

    public AssetItem GetItem(InventoryCell cell)
    {
        if (cell is null)
        {
            throw new System.ArgumentNullException(nameof(cell));
        }
        else
        {
            Debug.Log(cell.cellType);
            Debug.Log(_inventoryCellsHandler.GetIndexInTypeCollection(cell));
            Debug.Log(_items.Count);
            int itemIndex = _inventoryCellsHandler.GetIndexInTypeCollection(cell);

            if (itemIndex > _items.Count || itemIndex < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            else
            {
                return _items[itemIndex];
            }
        }
    }

    private protected List<AssetItem> FilingInventory(int listSize)
    {
        if (listSize > 0)
        {
            List<AssetItem> items = new List<AssetItem>(listSize);

            for (int i = 0; i < listSize; i++)
            {
                items.Add(new AssetItem());
            }

            return items;
        }
        else
        {
            throw new System.ArgumentNullException(nameof(listSize));
        }
        
    }

    private protected void SetItem(int itemIndex, AssetItem item)
    {
        Debug.Log(itemIndex);

        if (item is null)
        {
            throw new System.ArgumentNullException(nameof(item));
        }
        else
        {
            if (itemIndex > _items.Count || itemIndex < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            else
            {
                _items[itemIndex] = item;
            }
        }
    }
}
