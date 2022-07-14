using UnityEngine;
using UnityEngine.EventSystems;

public class CellEvent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventorySystem InventorySystem { get; set; }

    [SerializeField] private Cell _cell;
    [SerializeField] private RectTransform _iconTransform;
    [SerializeField] private CanvasGroup _canvasGroup;

    #region Events
    public void OnDrag(PointerEventData eventData)
    {
        if (_cell.Amount > 0)
            _iconTransform.anchoredPosition += eventData.delta / InventorySystem.Canvas.scaleFactor;
        else
            _iconTransform.anchoredPosition = default;
    }

    public void OnBeginDrag(PointerEventData eventData) => _canvasGroup.alpha = 0.6f;

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1;
        _iconTransform.anchoredPosition = default;
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        Cell cellDrag = eventData.pointerDrag.gameObject.GetComponent<Cell>();

        if (_cell.Amount > 0 || cellDrag.Amount > 0)
            InventorySystem.Inventory.OnSwapItems(_cell, cellDrag);
        _iconTransform.anchoredPosition = default;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventorySystem.ActionsOnItems.ActionsContainer.SetActive(false);
        CheckContainer();
    }

    public void OnPointerExit(PointerEventData eventData) => CheckContainer();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(_cell.Amount > 0)
            {
                InventorySystem.ActionsOnItems.SetCell(_cell);
                InventorySystem.ActionsOnItems.ActionsContainer.SetActive(true);
            }
        }
    }

    private void CheckContainer()
    {
        switch (_cell.cellType)
        {
            case Cell.CellType.Cell:
                {
                    InventorySystem.InventoryUI.SetInfo(_cell.Amount, InventorySystem.Inventory.GetItem(InventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_cell)));
                    break;
                }
            case Cell.CellType.HotKey:
                {
                    InventorySystem.InventoryUI.SetInfo(_cell.Amount, InventorySystem.Inventory.GetItemHotKey(InventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_cell)));
                    break;
                }
            case Cell.CellType.EquipSlot:
                {
                    InventorySystem.InventoryUI.SetInfo(_cell.Amount, InventorySystem.Inventory.GetItemEquip(InventorySystem.InventoryCellCollection.GetIndexInTypeCollection(_cell)));
                    break;
                }
        }  
    }
    #endregion
}
