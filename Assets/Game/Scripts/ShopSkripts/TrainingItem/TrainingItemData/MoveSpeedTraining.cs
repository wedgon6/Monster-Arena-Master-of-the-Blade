using MonsterArenaMasterOfTheBlade.Characters;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    [CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/TrainigItem/MoveSpeed")]
    public class MoveSpeedTraining : TrainingItemData
    {
        public override void BuffPlayer(ParametersPlayer parametersPlayer)
        {
            parametersPlayer.AddMoveSpeed();
        }
    }
}