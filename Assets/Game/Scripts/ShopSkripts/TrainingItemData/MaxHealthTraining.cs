using UnityEngine;

[CreateAssetMenu(fileName = "MaxHealth", menuName = "ScriptableObjects/TrainigItem/MaxHealth")]
public class MaxHealthTraining : TrainingItemData
{
    public override void DuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMaxHealth();
    }
}