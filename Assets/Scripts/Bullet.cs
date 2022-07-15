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
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _rb.velocity = Vector3.zero;
    }

    public void Shoot(Vector3 dir, float speed)
    {
        var velo = dir * speed;
        _rb.velocity = velo;
    }
}