using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.EntryPoint;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using MonsterArenaMasterOfTheBlade.UI;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SaveSystem
{
    public class SaveAndLoadSytem : MonoBehaviour
    {
        [SerializeField] private CanvasManager _canvasManager;
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private ParametersPlayer _parametersPlayer;

        [SerializeField] private ChoiceMap _choiceMap;
        [SerializeField] private TrainingShop _abillityShop;
        [SerializeField] private WeaponSkeenShop _skeenShop;

        [SerializeField] private EntryPointMainMenu _entry;

        public void Init()
        {
            _wallet.MoneyChanged += SaveGameData;
            _choiceMap.CountStarsChenged += SaveGameData;
            _parametersPlayer.SavedData += SaveGameData;
            _abillityShop.SaveGameData += SaveGameData;
            _skeenShop.SaveGameData += SaveGameData;
            _entry.SaveData += SaveGameData;
        }

        private void OnDisable()
        {
            _wallet.MoneyChanged -= SaveGameData;
            _choiceMap.CountStarsChenged -= SaveGameData;
            _parametersPlayer.SavedData -= SaveGameData;
            _abillityShop.SaveGameData -= SaveGameData;
            _skeenShop.SaveGameData -= SaveGameData;
            _entry.SaveData -= SaveGameData;
        }

        private void SaveGameData() => Services.SaveService.SaveData(_wallet, _choiceMap, _parametersPlayer, _abillityShop, _skeenShop);
    }
}