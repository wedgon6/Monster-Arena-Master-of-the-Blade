using Cinemachine;
using Lean.Localization;
using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.SaveSystem;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using MonsterArenaMasterOfTheBlade.TrapScripts;
using MonsterArenaMasterOfTheBlade.UI;
using System.Collections;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.EntryPoint
{
    public class BattleLevelCompositeRoot : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyCounter _enemyCounter;
        [SerializeField] private Player _player;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private TrapSpawner _trapSpawner;
        [SerializeField] private CinemachineVirtualCamera _mainCamera;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private LeanLocalization _localizate;

        [SerializeField] private ResultsPanel _winPanel;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private VariableJoystick _screenStick;

        private Coroutine _corontine;

        private void Awake()
        {
            if (Services.SaveService.TryGetData(out GameInfo gameInfo))
            {
                _player.Initialize(gameInfo, Agava.WebUtility.Device.IsMobile);
                _enemySpawner.RestSpawner(gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
                _trapSpawner.Initialize(gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
            }
            else
            {
                _player.Initialize(Agava.WebUtility.Device.IsMobile);
                _enemySpawner.RestSpawner(0, 0);
                _trapSpawner.Initialize(0, 0);
            }
        }

        private void Start()
        {
            _soundButton.Initialize();
        }

        private void OnEnable()
        {
            if (Agava.WebUtility.Device.IsMobile)
                _screenStick.gameObject.SetActive(true);
            else
                _screenStick.gameObject.SetActive(false);

            _enemyCounter.AllEnemyDied += OnWinGame;
            _player.Died += OnLooseGame;
            _player.Resurred += OnPlayerResurrected;
            _moneyView.Initialize(0, 0);
        }

        private void OnDisable()
        {
            _enemyCounter.AllEnemyDied -= OnWinGame;
            _player.Died -= OnLooseGame;
            _player.Resurred -= OnPlayerResurrected;
        }

        private void OnWinGame()
        {
            CorountineStart(WinGame());
            _player.VictoryDance();
        }

        private void OnLooseGame(Transform transform)
        {
            CorountineStart(LooseGame());
        }

        private void OnPlayerResurrected()
        {
            _mainCamera.Priority = 1;
            _enemySpawner.ResetEnemyesState();
            _losePanel.gameObject.SetActive(false);
        }

        private void CorountineStart(IEnumerator corontine)
        {
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
}