using UnityEngine;

public sealed class ItemActions
{
    private readonly Inventory _inventory;
    private readonly HealthBar _healthBar;

    public ItemActions(Inventory inventory, HealthBar healthBar)
    {
        _inventory = inventory;
        _healthBar = healthBar;
    }

    public void ApplyItem(AssetItem item, Cell cell)
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
                                _inventory.OnRemoveItem(cell);
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
