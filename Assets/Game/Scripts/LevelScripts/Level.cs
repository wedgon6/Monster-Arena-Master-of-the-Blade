using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level")]
public class Level : ScriptableObject
{
    [SerializeField] private string _levelLable;
    [SerializeField] private Sprite _levelIcon;
    [SerializeField] private Object _loadScene;

    private int _currentCountStars = 0;
    private int _maxCountStars = 3;

    public string LevelLable => _levelLable;
    public Sprite LevelIcon => _levelIcon;
    public string LoadScene => _loadScene.name;

    public void Initialize(int currentCountStars)
    {
        _currentCountStars = currentCountStars;
    }

    public void AddStars()
    {
        _currentCountStars++;

        if (_currentCountStars == _maxCountStars)
            _currentCountStars = 0;
    }
}