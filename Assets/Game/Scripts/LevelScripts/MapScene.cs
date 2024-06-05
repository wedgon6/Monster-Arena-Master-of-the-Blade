using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level")]
public class MapScene : ScriptableObject
{
    [SerializeField] private string _levelLable;
    [SerializeField] private Sprite _levelIcon;
    [SerializeField] private Object _loadScene;

    private int _currentCountStars = 0;
    private int _maxCountStars = 3;

    public string LevelLable => _levelLable;
    public Sprite LevelIcon => _levelIcon;
    public string LoadScene => _loadScene.name;
    public int CurrentCountStarts => _currentCountStars;

    public void Initialize(int currentCountStars)
    {
        _currentCountStars = currentCountStars;
    }
}