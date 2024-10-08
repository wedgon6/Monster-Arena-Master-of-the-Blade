using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using MonsterArenaMasterOfTheBlade.UI;

namespace MonsterArenaMasterOfTheBlade.SaveSystem
{
    public interface ISaveService
    {
        public int RelocateGold { get; set; }
        public int RelocateDaimond { get; set; }

        public bool TryGetData(out GameInfo data);
        public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer,
            TrainingShop abillityShop, WeaponSkeenShop skeenShop);
        public void RelocateData(PlayerWallet playerWallet, int countStars, int earnedScore);
    }
}