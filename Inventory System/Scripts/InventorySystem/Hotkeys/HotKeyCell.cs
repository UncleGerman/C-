using UnityEngine;
using UnityEngine.UI;

public sealed class HotKeyCell : InventoryCell
{
    [SerializeField] private ActionsOnItems _actionsOnItems;
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private Text _keyCodeInfo;

    private void Awake() => _keyCodeInfo.text = _keyCode.ToString();

    private void Update()
    {
        if(Input.GetKeyDown(_keyCode))
        {
            if (Amount > 0)
            {
                _actionsOnItems.SetCell(gameObject.GetComponent<HotKeyCell>());
                _actionsOnItems.OnApllayItem();
            }
        }
    }
}
