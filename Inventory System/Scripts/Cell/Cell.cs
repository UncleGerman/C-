using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class Cell : MonoBehaviour
{
    public AmountEvent AmountEvent;
    public int Amount 
    { 
        get => _amount;
        set
        {
            if (value > 0)
            {
                _amount = value;
                AmountEvent.Invoke(_amount);
            }
            else
            {
                _amount = default;
                AmountEvent.Invoke(_amount);
            }
            if (value == 0)
                _icon.sprite = _defaultSprite;
        }
    }

    public CellType cellType;
    public enum CellType
    {
        Cell,
        HotKey,
        EquipSlot
    }

    private int _amount;

    [Space]
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _defaultSprite;

    public void SetSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            _icon.sprite = _defaultSprite;
            Debug.Log("Resourse sprite == null\n Sprite == DefaultSprite");
        }
        else
        {
            _icon.sprite = sprite;
        }
    }

}

[System.Serializable]
public class AmountEvent : UnityEvent<int> { }
