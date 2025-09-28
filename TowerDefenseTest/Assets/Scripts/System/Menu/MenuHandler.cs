using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private UI_Manager _manager;

    private void Awake()
    {
        MainMenu_UI main = _manager.GetPanel<MainMenu_UI>();
        MapSelector_UI selector = _manager.GetPanel<MapSelector_UI>();
        Settings_UI settings = _manager.GetPanel<Settings_UI>();

        main.OnExit += Exit;
        main.OnSettings += OpenSettings;
        main.OnStart += OpenMapSelector;

        selector.OnClose += OpenMain;
        selector.OnClick += LoadScene;

        settings.OnClose += OpenMain;

        OpenMain();
    }

    private void OpenMain()
    {
        _manager.OpenPanel<MainMenu_UI>();
    }
    private void OpenMapSelector()
    {
        _manager.OpenPanel<MapSelector_UI>();
    }
    private void OpenSettings()
    {
        _manager.OpenPanel<Settings_UI>();
    }

    private void LoadScene(string mapId)
    {
        Debug.Log($"Loading scene {mapId}");
        SceneManager.LoadScene(mapId);
    }
    private void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
