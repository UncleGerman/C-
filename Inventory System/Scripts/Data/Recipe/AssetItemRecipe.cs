using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class AssetItemRecipe : ScriptableObject, IItemRecipe
{
    public List<AssetItem> Materials => _materials;
    public AssetItem Results => _result;
    public int Amount => _amount;

    [SerializeField] private List<AssetItem> _materials;
    [SerializeField] private AssetItem _result;
    [SerializeField] private int _amount;
}
