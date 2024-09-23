using UnityEngine;

[CreateAssetMenu(fileName = "RangeThrow", menuName = "ScriptableObjects/TrainigItem/RangeThrow")]
public class RangeThrowTraining : TrainingItemData
{
    public override void BuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddRangeThrow();
    }
}