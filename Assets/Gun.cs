using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _forcePower;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var forceDir = hit.point - transform.position;
                
                _rb.AddForce(forceDir * _forcePower, ForceMode.Impulse);
            }
        }
    }
}
