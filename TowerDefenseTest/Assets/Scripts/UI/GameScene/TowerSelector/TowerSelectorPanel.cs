using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectorPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;

    public void SetData(TowerSelectorData data, UnityEngine.Events.UnityAction<TowerSelectorData> onClick)
    {
        _nameText.text = data.Name;
        _image.sprite = data.Icon;
        _descriptionText.text = data.Description;
        _priceText.text = $"buy for {data.Price.ToString()}";
        _buyButton.onClick.RemoveAllListeners();
        _buyButton.onClick.AddListener(() => onClick?.Invoke(data));
    }

    public void SetActive(bool isActive)
    {
        _buyButton.interactable = isActive;
    }
}
