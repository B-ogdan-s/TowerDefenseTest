using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectorPanel : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _recordText;
    [SerializeField] private TextMeshProUGUI _lastText;

    public Action<string> OnClick;

    public void SetMapData(MapData mapData)
    {
        _nameText.text = mapData.MapName;
        _image.sprite = mapData.Icon;

        string recordKey = $"{mapData.SceneId}_record";
        string lastKey = $"{mapData.SceneId}_last";

        _recordText.text = $"Record: {PlayerPrefs.GetInt(recordKey)}";
        _lastText.text = $"Last: {PlayerPrefs.GetInt(lastKey)}";

        _button.onClick.AddListener(() => OnClick?.Invoke(mapData.SceneId));
    }

}
