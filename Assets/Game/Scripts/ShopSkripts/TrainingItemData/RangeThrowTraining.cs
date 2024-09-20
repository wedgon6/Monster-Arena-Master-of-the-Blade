using UnityEngine;

[CreateAssetMenu(fileName = "RangeThrow", menuName = "ScriptableObjects/TrainigItem/RangeThrow")]
public class RangeThrowTraining : TrainingItemData
{
    public override void DuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddRangeThrow();
    }
}