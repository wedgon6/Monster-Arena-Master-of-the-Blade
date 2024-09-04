using UnityEngine;

public class CanvasType : MonoBehaviour
{
    [SerializeField] private ChoiceMap _choiceMap;//
    [SerializeField] private TrainingShop _trainingShop;//
    [SerializeField] private ViewLeaderboard _leaderboardView;//
    [SerializeField] private Worckshop _worckshop;//
    [SerializeField] private GameObject _leaderboardPanel;

    public ChoiceMap ChoiceMap => _choiceMap;
    public TrainingShop TrainingShop => _trainingShop;
    public ViewLeaderboard LeaderboardView => _leaderboardView;
    public Worckshop Worckshop => _worckshop;
    public GameObject LeaderboardPanel => _leaderboardPanel;
}