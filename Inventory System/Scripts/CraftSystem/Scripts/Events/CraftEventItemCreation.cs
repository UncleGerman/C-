using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class CraftEventItemCreation : CraftEvent, IEvent
{
    private readonly List<AssetItemRecipe> _recipes;
    private readonly CraftCreationItemState _craftCreationItemState;

    public CraftEventItemCreation(InventoryEventHandler inventoryEventHandler, CraftCreationItemState craftCreationItemState = null) : base (inventoryEventHandler)
    {
        if (inventoryEventHandler is null)
        {
            throw new System.ArgumentNullException(nameof(inventoryEventHandler));
        }
        else
        {
            _recipes = Resources.LoadAll<AssetItemRecipe>("").ToList();
            _craftCreationItemState = craftCreationItemState;
        }
    }

    public void EnterEvent()
    {
        if (_craftCreationItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_craftCreationItemState)); 
        }
        else
        {
            _craftCreationItemState.CraftEventAdd += Craft;
        }
    }

    public void ExitEvent()
    {
        if (_craftCreationItemState is null)
        {
            throw new System.ArgumentNullException(nameof(_craftCreationItemState));
        }
        else
        {
            _craftCreationItemState.CraftEventAdd -= Craft;
        }
    }

    private void Craft()
    {
        foreach (AssetItemRecipe recipe in _recipes)
        {
            if (_inventoryEventHandler.InventoryHandler.Craft.Items == recipe.Materials)
            {
                _inventoryEventHandler.AddItem(recipe.Results);
                break;
            }
            else
            {
                continue;
            }
        }

        RemoveItems();
    }
}
