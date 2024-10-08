using MonsterArenaMasterOfTheBlade.Characters;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    [CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObjects/TrainigItem/Damage")]
    public class DamageTraining : TrainingItemData
    {
        public override void BuffPlayer(ParametersPlayer parametersPlayer)
        {
            parametersPlayer.AddDamage();
        }
    }
}