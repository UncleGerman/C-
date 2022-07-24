using UnityEngine;

public sealed class ActionsOnItems : MonoBehaviour
{
    public GameObject ActionsContainer { get => _actionsContainer; set => _actionsContainer = value; }

    [SerializeField] private GameObject _actionsContainer;
    [SerializeField] private InventoryEventHandler _inventorySystem;
    [SerializeField] private HealthBar _healthBar;

    private ItemActions _itemActions;

    private InventoryCell _cell;
    private AssetItem _item;

    public void Start()
    {
        //_itemActions = new ItemActions(_inventorySystem.InventoryEventHandler, _healthBar);
    }

    public void SetCell(InventoryCell cell)
    {
        _cell = cell ?? throw new System.ArgumentNullException(nameof(cell));
        //_item = _inventorySystem.InventoryHandler.GetItemInType(_cell);
        _actionsContainer.transform.position = Input.mousePosition;
    }

    public void OnDropItem()
    {
        if (_cell.Amount > 0)
        {
            //_inventorySystem.InventoryEventHandler.OnRemoveItem(_cell);
            Instantiate(_item.ItemPrefab);
        }
        else
        {
            Debug.Log("Cell Empty!");
        }
    }

    public void OnApllayItem()
    {
        if (_itemActions is null)
            Debug.Log(null);
        _itemActions.ApplyItem(_item, _cell);
    }

    public void OnEquipItem()
    {

    }
}