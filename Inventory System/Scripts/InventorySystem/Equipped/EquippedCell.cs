public sealed class EquippedCell : InventoryCell
{
    public EquippedType equippedType;
    public enum EquippedType
    {
        Helmet,
        Armor,
        Legs,
        Weapon
    }
}
