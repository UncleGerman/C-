using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _helthBar;
    [SerializeField] private int _health;
    [SerializeField] private int _currentHealth;

    public void SetMaxHealth(int value)
    {
        _helthBar.maxValue = value;
        _helthBar.value = value;
        _health = value;
        _currentHealth = value;
    }

    public void TakeDamage(int value)
    {
        if(value > _currentHealth)
        {

        }
        else
        {
            _currentHealth -= value;
            _helthBar.value = _currentHealth;
        }
    }

    public void TakeHealth(int value)
    {
        if(value > _currentHealth)
        {

        }
        else
        {
            _currentHealth += value;
            if(_currentHealth > _health)
            {
                _currentHealth = _health;
                _helthBar.value = _currentHealth;
            }
            else
            {
                _helthBar.value = _currentHealth;
            }
        }
    }
}
