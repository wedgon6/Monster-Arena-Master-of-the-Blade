using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int WaveLenght = 3;

    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Player _player;
    [SerializeField] private EnemiesList _enemiesPrefab;

    [SerializeField] private Pool _poolSmallEnemy;
    [SerializeField] private Pool _poolBigEnemy;
    [SerializeField] private Pool _poolRangeEnemy;

    private EnemyWave _currentWave = null;
    private int _currentWaveNumber = 0;
    private int _countWaves;
    private float _timeAfterLastSpawn;
    private float _delay = 2f;
    private int _spawned;
    private int _countStats;
    private Coroutine _corontine;
    private List<PoolObject> _createdEnemies = new List<PoolObject>();
    private List<EnemyWave> _enemyWaves = new List<EnemyWave>();

    public event Action EnemyDead;
    public event Action<int,int> SetedWaves;

    public void RestSpawner(int statsCount)
    {
        _enemyWaves.Clear();
        _countStats = statsCount;
        _timeAfterLastSpawn = 0;
        _currentWaveNumber = 0;
        _spawned = 0;
        SetWaveComplexity();
    }

    public int GetEnemyCount()
    {
        int enemyCount = 0;

        for (int i = 0; i < _enemyWaves.Count; i++)
        {
            enemyCount += _enemyWaves[i].Template.Count;
        }

        return enemyCount;
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _delay)
        {
            InitializeEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Template == null)
            return;

        if (_currentWave.Template.Count <= _spawned)
        {
            _currentWave = null;

            if (_enemyWaves.Count > _currentWaveNumber + 1)
                CorountineStart(StartNextWave());
        }
    }

    private void InitializeEnemy()
    {
        int currentSpawnPont = UnityEngine.Random.Range(0, _spawnPoints.Length);
        Enemy enemy = _currentWave.GetNextEnemy();

        if (enemy == null)
            return;

        if (TyrFindEnemy(enemy, out Enemy poolEnemy))
        {
            enemy = poolEnemy;
            enemy.transform.position = _spawnPoints[currentSpawnPont].position;
            enemy.gameObject.SetActive(true);
            enemy.ResetState();
        }
        else
        {
            enemy = Instantiate(enemy, _spawnPoints[currentSpawnPont].position, _spawnPoints[currentSpawnPont].rotation, _spawnPoints[currentSpawnPont]).GetComponent<Enemy>();
            InitializeEnemy(enemy);
            _createdEnemies.Add(enemy);
        }
    }

    private void InitializeEnemy(Enemy enemy)
    {
        if (enemy.TryGetComponent(out Enemy standartEnemy))
        {
            enemy.Initialize(_player, this);
            _poolSmallEnemy.InstantiatePoolObject(enemy);
            return;
        }

        if (enemy.TryGetComponent(out Enemy fastEnemy))
        {
            enemy.Initialize(_player, this);
            _poolRangeEnemy.InstantiatePoolObject(enemy);
            return;
        }

        if (enemy.TryGetComponent(out Enemy bigEnemy))
        {
            enemy.Initialize(_player, this);
            _poolBigEnemy.InstantiatePoolObject(enemy);
            return;
        }
    }

    private bool TyrFindEnemy(PoolObject enemyType, out Enemy poolEnemy)
    {
        Enemy enemy = enemyType as Enemy;
        poolEnemy = null;

        if (enemy.TypeEnemy == TypeEnemy.Small.ToString())
        {
            if (_poolSmallEnemy.TryPoolObject(out PoolObject enemyPool))
                poolEnemy = enemyPool as Enemy;
        }

        if (enemy.TypeEnemy == TypeEnemy.Range.ToString())
        {
            if (_poolRangeEnemy.TryPoolObject(out PoolObject enemyPool))
                poolEnemy = enemyPool as Enemy;
        }

        if (enemy.TypeEnemy == TypeEnemy.Big.ToString())
        {
            if (_poolBigEnemy.TryPoolObject(out PoolObject enemyPool))
                poolEnemy = enemyPool as Enemy;
        }

        return poolEnemy != null;
    }

    private void SetWave(int index) => _currentWave = _enemyWaves[index];

    private void NextWave()
    {
        _spawned = 0;
        SetWave(++_currentWaveNumber);
    }

    private void SetWaveComplexity()
    {
        if (_countStats == 0)
        {
            _countWaves = 1;
            SetWaves(_countWaves);
            return;
        }

        if (_countStats == 1)
        {
            _countWaves = 2;
            SetWaves(_countWaves);
            return;
        }

        if (_countStats == 2)
        {
            _countWaves = 3;
            SetWaves(_countWaves);
            return;
        }
    }

    private void SetWaves(int countWave)
    {
        List<Enemy> enemies = new List<Enemy>();

        for (int i = 0; i < countWave; i++)
        {
            for (int j = 0; j < WaveLenght; j++)
            {
                enemies.Add(_enemiesPrefab.GetEnemy());
            }

            _enemyWaves.Add(new EnemyWave(enemies));
        }

        SetWave(_currentWaveNumber);
        SetedWaves?.Invoke(WaveLenght,_enemyWaves.Count);
    }

    private IEnumerator StartNextWave()
    {
        int waitTime = 4;
        yield return new WaitForSeconds(waitTime);
        NextWave();
    }

    private void CorountineStart(IEnumerator corontine)
    {
        if (_corontine != null)
            StopCoroutine(_corontine);

        _corontine = StartCoroutine(corontine);
    }
}