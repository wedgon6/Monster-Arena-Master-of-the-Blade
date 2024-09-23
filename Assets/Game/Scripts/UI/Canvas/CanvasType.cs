using UnityEngine;

public class CanvasType : MonoBehaviour
{
    [SerializeField] private GameObject _trainingShopPanel;
    [SerializeField] private GameObject _trainingShopConteiner;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private ViewLeaderboard _leaderboardView;
    [SerializeField] private GameObject _worckshopPanel;
    [SerializeField] private GameObject _weaponShopConteiner;
    [SerializeField] private GameObject _leaderboardPanel;

    public GameObject TrainingShopPanel => _trainingShopPanel;
    public GameObject TrainingShopConteiner => _trainingShopConteiner;
    public GameObject WeaponShopConteiner => _weaponShopConteiner;
    public ChoiceMap ChoiceMap => _choiceMap;
    public ViewLeaderboard LeaderboardView => _leaderboardView;
    public GameObject Worckshop => _worckshopPanel;
    public GameObject LeaderboardPanel => _leaderboardPanel;
}