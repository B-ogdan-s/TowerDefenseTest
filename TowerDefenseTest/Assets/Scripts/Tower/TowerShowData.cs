using TMPro;
using UnityEngine;

public class TowerShowData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _levelUpPanel;
    [SerializeField] private TextMeshProUGUI _levelUpText;

    public void ShowLevel(bool value)
    {
        _levelText.gameObject.SetActive(value);
    }
    public void UpdateLevel(int value)
    {
        _levelText.text = $"lvl: {value}";
    }

    public void ShowLevelUp(bool value)
    {
        _levelUpPanel.SetActive(value);
    }
    public void UpdateLevelUp(int value)
    {
        _levelUpText.text = $"price: {value}";
    }
}
