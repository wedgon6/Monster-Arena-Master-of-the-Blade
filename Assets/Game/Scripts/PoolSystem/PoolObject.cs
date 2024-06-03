using System;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public event Action<PoolObject> PoolReturned;

    public void ReturObjectPool()
    {
        ReturnToPool();
    }

    protected virtual void ReturnToPool()
    {
        Debug.Log("Return to pool");
        gameObject.SetActive(false);
        PoolReturned?.Invoke(this);
    }
}