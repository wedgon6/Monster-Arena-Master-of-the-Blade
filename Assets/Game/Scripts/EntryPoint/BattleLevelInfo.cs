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
            Debug.Log($"Достал звезды для спавнеа {gameInfo.CurrentStatrsCount}");
            _currentCountStars = gameInfo.CurrentStatrsCount;
            _enemySpawner.RestSpawner(_currentCountStars);
            Debug.Log($"Предал звезды для спавнеа {_currentCountStars}");
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