using UnityEngine;

public class CanvasType : MonoBehaviour
{
    [SerializeField] private GameObject _trainingShopPanel;
    [SerializeField] private GameObject _trainingShopConteiner;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private ViewLeaderboard _leaderboardView;
    [SerializeField] private Worckshop _worckshop;
    [SerializeField] private GameObject _leaderboardPanel;

    public GameObject TrainingShopPanel => _trainingShopPanel;
    public GameObject TrainingShopConteiner => _trainingShopConteiner;
    public ChoiceMap ChoiceMap => _choiceMap;
    public ViewLeaderboard LeaderboardView => _leaderboardView;
    public Worckshop Worckshop => _worckshop;
    public GameObject LeaderboardPanel => _leaderboardPanel;
}