using UnityEngine;

[CreateAssetMenu(menuName = "Armor")]
public class AssetItemArmor : AssetItem, IArmor
{
    public int Defance => _defance;
    [SerializeField] private int _defance;

    public ArmorType armorType;
    public enum ArmorType
    {
        Helmet,
        Armor,
        Legs
    }
}
