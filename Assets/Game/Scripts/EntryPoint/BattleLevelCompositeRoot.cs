using Cinemachine;
using System.Collections;
using UnityEngine;

public class BattleLevelCompositeRoot : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private Player _player;
    [SerializeField] private HealthBarView _playerBar; 
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private TrapSpawner _trapSpawner;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;

    [SerializeField] private ResultsPanel _winPanel;
    [SerializeField] private LosePanel _losePanel;
    
    private Coroutine _corontine;
    private HealthBarView _barView;

    private void Awake()
    {
        if (Services.SaveService.TryGetData(out GameInfo gameInfo))
        {
            _player.Initialize(gameInfo);
            _enemySpawner.RestSpawner(gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
            _trapSpawner.Initialize(gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
        }
        else
        {
            _player.Initialize();
            _enemySpawner.RestSpawner(0, 0);
            _trapSpawner.Initialize(0, 0);
        }

        _barView = _player.GetComponent<HealthBarView>();
    }

    private void OnEnable()
    {
        _enemyCounter.AllEnemyDied += OnWinGame;
        _player.Died += OnLooseGame;
        _losePanel.ShowRevardAd += PlayerResurrected;
        _moneyView.Initialize(0, 0);
    }

    private void OnDisable()
    {
        _enemyCounter.AllEnemyDied -= OnWinGame;
        _player.Died -= OnLooseGame;
        _losePanel.ShowRevardAd -= PlayerResurrected;
    }

    private void OnWinGame()
    {
        //_playerBar.gameObject.SetActive(false);
        CorountineStart(WinGame());
        _player.VictoryDance();
    }

    private void OnLooseGame(Transform transform)
    {
        //_playerBar.gameObject.SetActive(false);
        CorountineStart(LooseGame());
    }

    private void PlayerResurrected()
    {
        //_playerBar.gameObject.SetActive(true);
        _mainCamera.Priority = 1;
        _enemySpawner.ResetEnemyesState();
    }

    private void CorountineStart(IEnumerator corontine)
    {
        _barView.enabled = false;

        if (_corontine != null)
            StopCoroutine(_corontine);

        _corontine = StartCoroutine(corontine);
    }

    private IEnumerator WinGame()
    {
        _mainCamera.Priority = -1;
        yield return new WaitForSeconds(2.2f);
        _winPanel.Initialize(_player);
        _winPanel.gameObject.SetActive(true);
    }

    private IEnumerator LooseGame()
    {
        _mainCamera.Priority = -1;
        yield return new WaitForSeconds(2.2f);
        _losePanel.Initialize(_player);
        _losePanel.gameObject.SetActive(true);
    }
}