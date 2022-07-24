using System.Collections.Generic;

public interface IItemRecipe
{
    public List<AssetItem> Materials { get; }
    public AssetItem Results { get; }
    public int Amount { get; }
}
