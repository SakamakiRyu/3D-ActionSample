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

    public bool IsGrappleable { get; private set; } = false;

    private Rigidbody _rb;

    private void Start()
    {
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
            IsGrappleable = true;
            if (Input.GetButtonDown("Fire2"))
            {
                var forceDir = hit.point - _player.transform.position;

                _rb.AddForce(forceDir * _forcePower, ForceMode.Impulse);
            }
            return;
        }
        else
        {
            IsGrappleable = false;
        }
    }
}
