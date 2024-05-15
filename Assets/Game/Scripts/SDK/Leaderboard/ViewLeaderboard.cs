using System.Collections.Generic;
using UnityEngine;

public class ViewLeaderboard : MonoBehaviour
{
    [SerializeField] private Transform _containet;
    [SerializeField] private ElementPlayer _leaderboardElementPrefab;

    private List<ElementPlayer> _spawnedElements = new List<ElementPlayer>();

    public void ConstructLeaderboard(List<DataPlayer> leaderboardPlayer)
    {
        ClearLeaderboard();

        foreach (DataPlayer player in leaderboardPlayer)
        {
            ElementPlayer elementPlayerInstance = Instantiate(_leaderboardElementPrefab, _containet);
            elementPlayerInstance.Initialize(player.Name, player.Rank, player.Score);
            _spawnedElements.Add(elementPlayerInstance);
        }
    }

    private void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
        {
            Destroy(element.gameObject);
        }

        _spawnedElements = new List<ElementPlayer>();
    }
}