using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class AmountEvent : UnityEvent<int> { }

public class InventoryCell : MonoBehaviour
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
        Cell = 1,
        HotKey = 2,
        EquipSlot = 3,
        CraftSlot = 4
    }

    private int _amount;

    [Space]
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _defaultSprite;

    public void SetSprite(Sprite sprite)
    {
        if (sprite is null)
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