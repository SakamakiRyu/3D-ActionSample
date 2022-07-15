using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IShootable
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnDisable()
    {
    }

    public void Shoot(Vector3 dir, float speed)
    {
        var velo = dir * speed;
        _rb.velocity = velo;
    }
}