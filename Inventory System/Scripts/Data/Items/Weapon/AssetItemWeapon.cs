using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class AssetItemWeapon : AssetItem, IWeapon
{
    public enum WeaponType
    {
        None = 0,
        RangedWeapons = 1,
        MeleeWeapon = 2
    };

    public WeaponType weaponType;

    public float Range => _range;

    public float Delay => _delay;

    [SerializeField] private float _range;
    [SerializeField] private float _delay;
}
