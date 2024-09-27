using MonsterArenaMasterOfTheBlade.SDK;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private ModileCanvas _modileCanvas;
        [SerializeField] private DekstopCanvas _dekstopCanvas;
        [SerializeField] private ChoiceMap _choiceMap;

        [SerializeField] private LeaderBoardButton _boardButton;
        [SerializeField] private OpenButton _battleButton;
        [SerializeField] private OpenButton _trainingButton;
        [SerializeField] private OpenButton _weaponWorshopButton;

        private GameObject _trainingShopConteiner;
        private GameObject _weaponShopConteiner;
        private WeaponSkeenViewConteiner _viewConteiner;

        public GameObject TrainingShopConteiner => _trainingShopConteiner;
        public GameObject WeaponShopConteiner => _weaponShopConteiner;
        public DekstopCanvas DekstopCanvas => _dekstopCanvas;
        public ModileCanvas ModileCanvas => _modileCanvas;
        public WeaponSkeenViewConteiner ViewConteiner => _viewConteiner;

        public void Init()
        {
            _battleButton.Initialaize(_choiceMap.gameObject);

            if (Agava.WebUtility.Device.IsMobile)
            {
                _trainingShopConteiner = _modileCanvas.TrainingShopConteiner;
                _weaponShopConteiner = _modileCanvas.WeaponShopConteiner;
                _viewConteiner = _modileCanvas.ViewConteiner;
                _boardButton.Initialize(_modileCanvas.LeaderboardPanel);
                _trainingButton.Initialaize(_modileCanvas.TrainingShopPanel.gameObject);
                _weaponWorshopButton.Initialaize(_modileCanvas.Worckshop.gameObject);
            }
            else
            {
                _trainingShopConteiner = _dekstopCanvas.TrainingShopConteiner;
                _weaponShopConteiner = _dekstopCanvas.WeaponShopConteiner;
                _viewConteiner = _dekstopCanvas.ViewConteiner;
                _boardButton.Initialize(_dekstopCanvas.LeaderboardPanel);
                _trainingButton.Initialaize(_dekstopCanvas.TrainingShopPanel.gameObject);
                _weaponWorshopButton.Initialaize(_dekstopCanvas.Worckshop.gameObject);
            }
        }
    }
}