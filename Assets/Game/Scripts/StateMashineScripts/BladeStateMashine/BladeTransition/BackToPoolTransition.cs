using UnityEngine;

public class BackToPoolTransition : Transition
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Movment player))
        {
            Debug.Log("Collision");
            NeedTransit = true;
        }
    }
}