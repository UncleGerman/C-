using System.Collections.Generic;

public sealed class Inventory
{
    public delegate void EventAdd(AssetItem item, ref List<AssetItem> items);
    public event EventAdd AddItem;

    public delegate void EventRemove(ref List<AssetItem> items, Cell cell);
    public event EventRemove RemoveItem;

    public delegate void EventSwap(ref List<AssetItem> items, ref List<AssetItem> hotKeysItems, Cell firstCell, Cell secondCell);
    public event EventSwap SwapItem;

    private List<AssetItem> _items;
    private List<AssetItem> _itemsHotKeys;
    private List<AssetItem> _itemsEquip;
    
    private readonly InventoryData _inventoryData;

    public Inventory(InventoryData inventoryData)
    {
        _inventoryData = inventoryData;
        _items = FilingInventory(_inventoryData.InventorySize);
        _itemsHotKeys = FilingInventory(InventoryData.HotKeySize);
        _itemsEquip = FilingInventory(InventoryData.EquippedItemSize);
    }

    public bool OnEmptyPlace(AssetItem itemData)
    {
        foreach (AssetItem item in _items)
        {
            if (item.itemType == 0)
            {
                AddItem.Invoke(itemData, ref _items);
                return true;
            }
        }
        return false;
    }

    public void OnRemoveItem(Cell cell)
    {
        if(cell.GetComponent<HotKeys>())
            RemoveItem.Invoke(ref _itemsHotKeys, cell);
        else
            RemoveItem.Invoke(ref _items, cell);
    }

    public void OnSwapItems(Cell firstCell, Cell secondCell)
    {
        switch (firstCell.cellType)
        {
            case Cell.CellType.Cell:
                {
                    switch (secondCell.cellType)
                    {
                        case Cell.CellType.Cell:
                            {
                                SwapItem.Invoke(ref _items, ref _items, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.HotKey:
                            {
                                SwapItem.Invoke(ref _items, ref _itemsHotKeys, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.EquipSlot:
                            {
                                SwapItem.Invoke(ref _items, ref _itemsEquip, firstCell, secondCell);
                                break;
                            }
                    }
                    break;
                }
            case Cell.CellType.HotKey:
                {
                    switch (secondCell.cellType)
                    {
                        case Cell.CellType.Cell:
                            {
                                SwapItem.Invoke(ref _itemsHotKeys, ref _items, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.HotKey:
                            {
                                SwapItem.Invoke(ref _itemsHotKeys, ref _itemsHotKeys, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.EquipSlot:
                            {
                                SwapItem.Invoke(ref _itemsHotKeys, ref _itemsEquip, firstCell, secondCell);
                                break;
                            }
                    }
                    break;
                }
            case Cell.CellType.EquipSlot:
                {
                    switch (secondCell.cellType)
                    {
                        case Cell.CellType.Cell:
                            {
                                SwapItem.Invoke(ref _itemsEquip, ref _items, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.HotKey:
                            {
                                SwapItem.Invoke(ref _itemsEquip, ref _itemsHotKeys, firstCell, secondCell);
                                break;
                            }
                        case Cell.CellType.EquipSlot:
                            {
                                SwapItem.Invoke(ref _itemsEquip, ref _itemsEquip, firstCell, secondCell);
                                break;
                            }
                    }
                    break;
                }
        }
    }

    public AssetItem GetItem(int itemIndex) => _items[itemIndex];

    public AssetItem GetItemHotKey(int itemIndex) => _itemsHotKeys[itemIndex];

    public AssetItem GetItemEquip(int itemIndex) => _itemsEquip[itemIndex];

    private List<AssetItem> FilingInventory(int listSize)
    {
        List<AssetItem> items = new List<AssetItem>(listSize);

        for (int i = 0; i < listSize; i++)
            items.Add(new AssetItem());
        return items;
    }
}
