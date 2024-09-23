using UnityEngine;

[CreateAssetMenu(fileName = "MaxHealth", menuName = "ScriptableObjects/TrainigItem/MaxHealth")]
public class MaxHealthTraining : TrainingItemData
{
    public override void BuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMaxHealth();
    }
}