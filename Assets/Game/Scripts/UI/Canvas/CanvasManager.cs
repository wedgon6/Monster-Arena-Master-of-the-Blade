using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ModileCanvas _modileCanvas;
    [SerializeField] private DekstopCanvas _dekstopCanvas;

    [SerializeField] private LeaderBoardButton _boardButton;
    [SerializeField] private OpenButton _battleButton;
    [SerializeField] private OpenButton _trainingButton;
    [SerializeField] private OpenButton _weaponWorshopButton;

    public DekstopCanvas DekstopCanvas => _dekstopCanvas;
    public ModileCanvas ModileCanvas => _modileCanvas;

    private void Awake()
    {
        if (Agava.WebUtility.Device.IsMobile)
        {
            _boardButton.Initialize(_modileCanvas.LeaderboardPanel);
            _battleButton.Initialaize(_modileCanvas.ChoiceMap.gameObject);
            _trainingButton.Initialaize(_modileCanvas.TrainingShop.gameObject);
            _weaponWorshopButton.Initialaize(_modileCanvas.Worckshop.gameObject);
        }
        else
        {
            _boardButton.Initialize(_dekstopCanvas.LeaderboardPanel);
            _battleButton.Initialaize(_dekstopCanvas.ChoiceMap.gameObject);
            _trainingButton.Initialaize(_dekstopCanvas.TrainingShop.gameObject);
            _weaponWorshopButton.Initialaize(_dekstopCanvas.Worckshop.gameObject);
        }
    }
}