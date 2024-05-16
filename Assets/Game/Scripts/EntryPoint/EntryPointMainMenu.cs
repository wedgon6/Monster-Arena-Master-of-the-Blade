using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    private GameInfo _gameInfo;
    private void Awake()
    {
        _gameInfo = JsonUtility.FromJson<GameInfo>(Services.SaveService.GetSaveData());
    }
}