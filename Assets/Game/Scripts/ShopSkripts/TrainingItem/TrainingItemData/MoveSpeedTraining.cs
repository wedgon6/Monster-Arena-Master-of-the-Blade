using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/TrainigItem/MoveSpeed")]
public class MoveSpeedTraining : TrainingItemData
{
    public override void BuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMoveSpeed();
    }
}