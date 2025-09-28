using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Data/MapData")]
public class MapData : ScriptableObject
{
    [SerializeField] private string _mapName;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _sceneId;

    public string MapName => _mapName;
    public Sprite Icon => _icon;
    public string SceneId => _sceneId;
}
