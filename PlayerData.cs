using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _health;
    [SerializeField] private int _mana;
    [SerializeField] private int _stamina;

    private void Start()
    {
        _healthBar.SetMaxHealth(_health);
    }
}
