using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IShootable
{
    private Rigidbody _rb;

    private WaitForSeconds _wait = new WaitForSeconds(5f);

    private void Start()
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
        StartCoroutine(InvisibleAsync());

        var velo = dir * speed;
        _rb.velocity = velo;
    }

    private IEnumerator InvisibleAsync()
    {
        yield return _wait;
        this.gameObject.SetActive(false);
    }
}