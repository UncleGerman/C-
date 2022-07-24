using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int PlayerSpeed => _playerSpeed;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _health;
    [SerializeField] private int _mana;
    [SerializeField] private int _stamina;
    [Space]
    [Header("PlayerMove")]
    [SerializeField] private int _playerSpeed;

    private void Start()
    {
        _healthBar.SetMaxHealth(_health);
    }
}
