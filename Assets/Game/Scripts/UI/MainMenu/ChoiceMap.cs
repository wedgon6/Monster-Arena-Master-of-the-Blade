using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Localization;

public class ChoiceMap : MonoBehaviour
{
    [SerializeField] private List<MapScene> _levels;
    [SerializeField] private Image _levelIcon;
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private Button _playButton;
    [SerializeField] private GameObject _starsViewPrefab;
    [SerializeField] private GameObject _starsConteiner;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _proUGUI;
    [SerializeField] private LoadPanel _loadPanel;

    private int _currentLevelIndex;
    private int _currentStars;
    private MapScene _currentLevel;

    public int CurrentLevelIndex => _currentLevelIndex;
    public int CurrentStars => _currentStars;

    public event Action CountStarsChenged;

    public void Initialize(int currentMapIndex, int currentCountStats)
    {
        Debug.Log($"Enter start - {currentCountStats}");
        _currentLevelIndex = currentMapIndex;
        _currentLevel = _levels[currentMapIndex];
        _currentStars = currentCountStats;
        Debug.Log($"Current count stars start initialize - {_currentStars}");

        if (_currentStars > 2)
            SetNextMap();

        int countStarsView = _currentStars + 1;

        for (int i = 0; i < countStarsView; i++)
        {
            Instantiate(_starsViewPrefab, _starsConteiner.transform);
        }

        CountStarsChenged?.Invoke();
        Debug.Log($"Current count stars after initialize - {_currentStars}");
    }

    private void SetNextMap()
    {
        _currentStars = 0;
        _currentLevelIndex++;

        if (_currentLevelIndex < 0)
            _currentLevelIndex = _levels.Count - 1;
        else if (_currentLevelIndex > _levels.Count - 1)
            _currentLevelIndex = 0;

        ShowLevel(_levels[_currentLevelIndex]);
    }

    private void ShowLevel(MapScene map)
    {
        _currentLevel = map;
        _levelIcon.sprite = map.LevelIcon;
        _levelName.text = map.LevelLable.ToString();
        _proUGUI.TranslationName = _currentLevel.LocalizationKey;
        _proUGUI.UpdateTranslation(LeanLocalization.GetTranslation(_proUGUI.TranslationName));

        EneblePlayButton();
    }

    private void OnEnable()
    {
        ShowLevel(_currentLevel);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
    }

    private void EneblePlayButton()
    {
        _playButton.onClick.RemoveListener(OnClickPlayButton);
        _playButton.onClick.AddListener(OnClickPlayButton);
    }

    private void OnClickPlayButton()
    {
        Services.AdvertisemintService.ShowInterstitialAd();
        _loadPanel.OpenLoadPanel(_currentLevel.LoadScene);
    }
}