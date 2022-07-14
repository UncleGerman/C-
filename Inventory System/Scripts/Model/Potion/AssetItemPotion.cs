using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class AssetItemPotion : AssetItem, IPotion
{
    public PotionType potionType;

    public enum PotionType
    {
        None = 1,
        HealingPotion,
        ManaPotion,
        StaminaPotion
    }

    public float TimeToUse { get => _timeToUse; set => _timeToUse = value; }
    public int Recovery { get => _recovery; set => _recovery = value; }

    [SerializeField] private float _timeToUse;
    [SerializeField] private int _recovery;
}