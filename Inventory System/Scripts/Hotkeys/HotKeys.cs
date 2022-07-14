using UnityEngine;
using UnityEngine.UI;

public class HotKeys : MonoBehaviour
{
    public InventorySystem InventorySystem;

    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private Text _keyCodeInfo;
    private Cell _cell;

    private void Awake()
    {
        _cell = gameObject.GetComponent<Cell>();
        _keyCodeInfo.text = _keyCode.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(_keyCode))
        {
            if (_cell.Amount > 0)
            {
                InventorySystem.ActionsOnItems.SetCell(_cell);
                InventorySystem.ActionsOnItems.OnApllayItem();
            }
        }
    }
}
