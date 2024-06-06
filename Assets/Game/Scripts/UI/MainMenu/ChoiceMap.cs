using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChoiceMap : MonoBehaviour
{
    [SerializeField] private List<MapScene> _levels;
    [SerializeField] private Image _levelIcon;
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private Button _playButton;
    [SerializeField] private GameObject _starsViewPrefab;
    [SerializeField] private GameObject _starsConteiner;

    private int _currentLevelIndex;
    private int _currentStars;
    private MapScene _currentLevel;

    public int CurrentLevelIndex => _currentLevelIndex;
    public int CurrentStars => _currentStars;

    public event Action CountStarsChenged;

    public void Initialize(int currentMapIndex, int currentCountStats)
    {
        Debug.Log($"Полученные звезды - {currentCountStats}");
        _currentLevel = _levels[currentMapIndex];
        _currentStars = currentCountStats;

        if (_currentStars > 2)
        {
            _currentStars = 0;
            Debug.Log($"Уменьшил звезды - {_currentStars}");
            int nextLevelIndex = _currentStars + 1;
            ShowLevel(nextLevelIndex);

        }

        int countStarsView = _currentStars + 1;

        for (int i = 0; i < countStarsView; i++)
        {
            Instantiate(_starsViewPrefab, _starsConteiner.transform);
        }

        CountStarsChenged?.Invoke();
    }

    private void ShowLevel(int change)
    {
        _currentLevelIndex += change;

        if (_currentLevelIndex < 0)
            _currentLevelIndex = _levels.Count - 1;
        else if (_currentLevelIndex > _levels.Count - 1)
            _currentLevelIndex = 0;

        _currentLevel = _levels[_currentLevelIndex];
        _levelIcon.sprite = _levels[_currentLevelIndex].LevelIcon;
        _levelName.text = _levels[_currentLevelIndex].LevelLable.ToString();

        EneblePlayButton();
    }

    private void OnEnable()
    {
        ShowLevel(_currentLevelIndex);
    }

    private void EneblePlayButton()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
        _playButton.onClick.AddListener(OnClickPlayButton);
    }

    private void OnClickPlayButton()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_levels[_currentLevelIndex].LoadScene);
        //asyncOperation.completed += _ => GameplayScene();
    }

    private void GameplayScene()
    {
        //Services.Init();
        
    }
}