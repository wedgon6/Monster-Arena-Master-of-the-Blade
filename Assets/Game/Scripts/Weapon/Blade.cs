using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private Transform _position;

    private void Awake()
    {
        Attack();
    }

    private void Attack()
    {
        transform.DOMove(Vector3.forward * 10, 3);
    }

    private void BackToPoint()
    {
        transform.DOMove(_position.position, 5);
    }
}