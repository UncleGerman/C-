using UnityEngine;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    public Canvas Canvas => _canvas;
    public ItemInfoEvent ItemInfoEvent;

    [SerializeField] private KeyCode _showInventoryKeyCode;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private Canvas _canvas;

    public void SetInfo(int amount, AssetItem item) => ItemInfoEvent.Invoke(amount, item);

    private void Update()
    {
        if (Input.GetKeyDown(_showInventoryKeyCode))
        {
            OnShowUI(_inventory);
        }
    }

    public void OnShowUI(GameObject container)
    {
        bool showContainer = container.activeSelf;
        if (showContainer)
            container.SetActive(false);
        else
            container.SetActive(true);
    }
}

[System.Serializable]
public class ItemInfoEvent : UnityEvent<int, AssetItem> { }