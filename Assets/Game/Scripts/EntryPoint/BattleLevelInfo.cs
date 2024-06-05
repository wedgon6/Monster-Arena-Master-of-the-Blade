using UnityEngine;

public class BattleLevelInfo : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private Player _player;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private CameraController _camera;

    [SerializeField] private WinPanel _winPanel;

    private int _currentCountStars;

    private void Awake()
    {
        if (Services.SaveService.TryGetData(out GameInfo gameInfo))
        {
            _currentCountStars = gameInfo.CurrentStatrsCount;
            _enemySpawner.RestSpawner(_currentCountStars);
        }
        else
        {
            _enemySpawner.RestSpawner(0);
        }
    }

    private void OnEnable()
    {
        _enemyCounter.AllEnemyDied += OnWinGame;
        _moneyView.Initialize(0, 0);
    }

    private void OnDisable()
    {
        _enemyCounter.AllEnemyDied -= OnWinGame;
    }

    private void OnWinGame()
    {
        _winPanel.Initialize(_player);
        _winPanel.gameObject.SetActive(true);
        //_camera.WinGameTransition();
    }
}