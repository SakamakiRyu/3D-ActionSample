using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _forcePower;

    [SerializeField]
    private float _rayDistance;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, _rayDistance))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var forceDir = hit.point - transform.position;

                _rb.AddForce(forceDir * _forcePower, ForceMode.Impulse);
            }
        }
    }
}
