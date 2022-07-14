using UnityEngine;
using UnityEngine.UI;

public sealed class AmountText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _textContainer;
    private string _template = "{0}";

    public void SetAmount(int amount)
    {
        bool isVisibleText = amount > 0;
        _textContainer.SetActive(isVisibleText);
        _text.text = string.Format(_template, amount);
    }
}
