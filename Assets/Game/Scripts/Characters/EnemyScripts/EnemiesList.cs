using UnityEngine;

[System.Serializable]
public class EnemiesList
{
    [SerializeField] private Enemy _smallEnemy;
    [SerializeField] private Enemy _rangeEnemy;
    [SerializeField] private Enemy _bigEnemy;

    [SerializeField] private int _maxIndexSmallEnemy = 5;
    [SerializeField] private int _maxIndexRangeEnemy = 9;
    [SerializeField] private int _maxIndexBigEnemy = 11;

    public EnemiesList(Enemy smallEnemy, Enemy rangeEnemy, Enemy bigEnemy)
    {
        _smallEnemy = smallEnemy;
        _rangeEnemy = rangeEnemy;
        _bigEnemy = bigEnemy;
    }

    public Enemy SnalltEnemy => _smallEnemy;
    public Enemy RangeEnemy => _rangeEnemy;
    public Enemy BigEnemy => _bigEnemy;

    public Enemy GetEnemy()
    {
        int enemyIndex = Random.Range(0, _maxIndexBigEnemy); ;

        if (enemyIndex <= _maxIndexSmallEnemy)
        {
            return _smallEnemy;
        }
        else if (enemyIndex > _maxIndexSmallEnemy && enemyIndex <= _maxIndexRangeEnemy)
        {
            return _rangeEnemy;
        }
        else if (enemyIndex > _maxIndexRangeEnemy)
        {
            return _bigEnemy;
        }

        return null;
    }
}