using UnityEngine;

public class CanvasType : MonoBehaviour
{
    [SerializeField] private GameObject _trainingShopPanel;
    [SerializeField] private GameObject _trainingShopConteiner;
    [SerializeField] private ViewLeaderboard _leaderboardView;
    [SerializeField] private GameObject _worckshopPanel;
    [SerializeField] private GameObject _weaponShopConteiner;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private WeaponSkeenViewConteiner _viewConteiner;

    public GameObject TrainingShopPanel => _trainingShopPanel;
    public GameObject TrainingShopConteiner => _trainingShopConteiner;
    public GameObject WeaponShopConteiner => _weaponShopConteiner;
    public ViewLeaderboard LeaderboardView => _leaderboardView;
    public GameObject Worckshop => _worckshopPanel;
    public GameObject LeaderboardPanel => _leaderboardPanel;
    public WeaponSkeenViewConteiner ViewConteiner => _viewConteiner;
}