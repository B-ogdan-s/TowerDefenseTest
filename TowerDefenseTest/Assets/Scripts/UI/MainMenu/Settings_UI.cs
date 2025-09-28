using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings_UI : UI_Panel
{
    [SerializeField] private Button _closeButton;

    public Action OnClose;

    private void Awake()
    {
        _closeButton.onClick.AddListener(()=>OnClose?.Invoke());
    }
}
