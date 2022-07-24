using UnityEngine;
using UnityEngine.EventSystems;

public class CellEvent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public InventoryEventHandler InventorySystem { get; set; }
    public InventoryUI InventoryUI { get; set; }

    [SerializeField] private InventoryCell _cell;
    [SerializeField] private RectTransform _iconTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Vector2 _defaultIconPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (_cell.Amount > 0)
        {
            _iconTransform.anchoredPosition += eventData.delta / InventoryUI.Canvas.scaleFactor;
        }   
        else
        {
            _iconTransform.anchoredPosition = _defaultIconPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) => _canvasGroup.alpha = 0.6f;

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1;
        _iconTransform.anchoredPosition = _defaultIconPosition;
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        var cell = eventData.pointerDrag.gameObject.GetComponent<InventoryCell>();
        InventorySystem.SwapItem(_cell, cell);
        _iconTransform.anchoredPosition = _defaultIconPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //InventorySystem.ActionsOnItems.ActionsContainer.SetActive(false);
        //InventoryUI.SetInfo(_cell.Amount, InventorySystem.InventoryHandler.GetItemInType(_cell));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //InventoryUI.SetInfo(_cell.Amount, InventorySystem.InventoryHandler.GetItemInType(_cell));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (_cell.Amount > 0)
            {
                //InventorySystem.ActionsOnItems.SetCell(_cell);
                //InventorySystem.ActionsOnItems.ActionsContainer.SetActive(true);
            }
            else
            {
                Debug.Log("Cell Empty!");
            }
        }
    }
}
