using UnityEngine;

public sealed class ItemActions
{
    //private readonly InventoryEventHandler _inventoryEventHandler;
    private readonly HealthBar _healthBar;

    public ItemActions(HealthBar healthBar)
    {
        //_inventoryEventHandler = inventoryEventHandler ?? throw new System.ArgumentNullException(nameof(inventoryEventHandler));
        _healthBar = healthBar ?? throw new System.ArgumentNullException(nameof(healthBar));
    }

    public void ApplyItem(AssetItem item, InventoryCell cell)
    {
        switch (item.itemType)
        {
            case AssetItem.ItemType.Food:
                break;
            case AssetItem.ItemType.Potion:
                {
                    AssetItemPotion potion = Resources.Load<AssetItemPotion>($"Items/Data/{item.itemType}/{item.Name}");
                    if (potion == null)
                    {
                        Debug.Log("AssetItem == Null!");
                        break;
                    }
                    switch (potion.potionType)
                    {
                        case AssetItemPotion.PotionType.HealingPotion:
                            {
                                //_inventoryEventHandler.OnRemoveItem(cell);
                                _healthBar.TakeHealth(potion.Recovery);
                                break;
                            }
                    }
                    break;
                }
            default:
                break;
        }
    }
}
