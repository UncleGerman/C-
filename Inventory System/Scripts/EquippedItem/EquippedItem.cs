using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    public EquippedType equippedType;
    public enum EquippedType
    {
        Helmet,
        Armor,
        Legs
    }
}
