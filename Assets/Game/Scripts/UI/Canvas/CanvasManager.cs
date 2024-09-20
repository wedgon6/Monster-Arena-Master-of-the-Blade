using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ModileCanvas _modileCanvas;
    [SerializeField] private DekstopCanvas _dekstopCanvas;

    [SerializeField] private LeaderBoardButton _boardButton;
    [SerializeField] private OpenButton _battleButton;
    [SerializeField] private OpenButton _trainingButton;
    [SerializeField] private OpenButton _weaponWorshopButton;

    private GameObject _trainingShopConteiner;

    public GameObject TrainingShopConteiner => _trainingShopConteiner;
    public DekstopCanvas DekstopCanvas => _dekstopCanvas;
    public ModileCanvas ModileCanvas => _modileCanvas;

    public void Init()
    {
        if (Agava.WebUtility.Device.IsMobile)
        {
            _boardButton.Initialize(_modileCanvas.LeaderboardPanel);
            _battleButton.Initialaize(_modileCanvas.ChoiceMap.gameObject);
            _trainingButton.Initialaize(_modileCanvas.TrainingShopConteiner.gameObject);
            _weaponWorshopButton.Initialaize(_modileCanvas.Worckshop.gameObject);
        }
        else
        {
            _trainingShopConteiner = _dekstopCanvas.TrainingShopConteiner;
            Debug.Log(_trainingShopConteiner == null);

            _boardButton.Initialize(_dekstopCanvas.LeaderboardPanel);
            _battleButton.Initialaize(_dekstopCanvas.ChoiceMap.gameObject);
            _trainingButton.Initialaize(_dekstopCanvas.TrainingShopPanel.gameObject);
            _weaponWorshopButton.Initialaize(_dekstopCanvas.Worckshop.gameObject);
        }
    }
}