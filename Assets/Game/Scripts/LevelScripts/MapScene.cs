using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level")]
public class MapScene : ScriptableObject
{
    [SerializeField] private string _levelLable;
    [SerializeField] private Sprite _levelIcon;
    [SerializeField] private Object _loadScene;

    public string LevelLable => _levelLable;
    public Sprite LevelIcon => _levelIcon;
    public string LoadScene => _loadScene.name;
}