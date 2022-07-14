using UnityEngine;
using UnityEngine.UI;

public sealed class ItemInfo : MonoBehaviour
{
    [SerializeField] private Text _itemNameText;
    [SerializeField] private Text _itemDescriptionText;

    public void SetInfo(int amount, AssetItem item)
    {
        bool isVisibleInfo = amount > 0;
        _itemNameText.text = item.Name;
        _itemDescriptionText.text = item.Description;
        gameObject.SetActive(isVisibleInfo);
    }
}
