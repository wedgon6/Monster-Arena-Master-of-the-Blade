using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class ChoiceMap : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private Image _levelIcon;
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private Button _playButton;

    private int _currentLevelIndex;
    private Level _currentLevel;

    public int CurrentLevelIndex => _currentLevelIndex;

    //private void Awake()
    //{
    //    ShowLevel(0);
    //}

    public void Initialize(int currentMapIndex, int currentCountStats)
    {
        _currentLevel = _levels[currentMapIndex];
        _currentLevel.Initialize(currentCountStats);
    }

    public void ShowLevel(int change)
    {
        _currentLevelIndex += change;

        if (_currentLevelIndex < 0)
            _currentLevelIndex = _levels.Count - 1;
        else if (_currentLevelIndex > _levels.Count - 1)
            _currentLevelIndex = 0;

        _levelIcon.sprite = _levels[_currentLevelIndex].LevelIcon;
        _levelName.text = _levels[_currentLevelIndex].LevelLable.ToString();

        EneblePlayButton();
    }

    private void EneblePlayButton()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
        _playButton.onClick.AddListener(OnClickPlayButton);
    }

    private void OnClickPlayButton()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_levels[_currentLevelIndex].LoadScene);
        asyncOperation.completed += _ => GameplayScene();
    }

    private void GameplayScene()
    {
        //Services.Init();
        
    }
}