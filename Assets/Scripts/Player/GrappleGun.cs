using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private LayerMask _grappleableLayer;

    [SerializeField]
    private float _forcePower;

    [SerializeField]
    private float _rayDistance;

    public bool IsGrapple { get; private set; }

    private Rigidbody _rb;

    private void Start()
    {
        IsGrapple = false;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Grappling();
    }

    private void Grappling()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, _rayDistance))
        {
            IsGrapple = true;
            if (Input.GetButtonDown("Fire2"))
            {
                var forceDir = hit.point - transform.position;

                _rb.AddForce(forceDir * _forcePower, ForceMode.Impulse);
            }
            return;
        }
        else
        {
            IsGrapple = false;
        }
    }
}
