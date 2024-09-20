using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObjects/TrainigItem/Damage")]
public class DamageTraining : TrainingItemData
{
    public override void DuffPlayer(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddDamage();
    }
}