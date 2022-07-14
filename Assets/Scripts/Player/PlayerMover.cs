using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        Look();
    }

    /// <summary>
    /// •à‚­
    /// </summary>
    private void Walk()
    {
        var dir = CreateDirection();

        if (dir != Vector3.zero)
        {
            var velo = dir * _movingSpeed;
            _rb.velocity = velo;
        }
    }

    /// <summary>
    /// Œü‚«‚ğ•Ï‚¦‚é
    /// </summary>
    private void Look()
    {
        var inputX = Input.GetAxis("Mouse X");

        if (inputX != 0)
        {
            transform.Rotate(0f, inputX, 0f);
        }
    }

    /// <summary>
    /// ˆÚ“®‚Ì•ûŒüƒxƒNƒgƒ‹‚ğì¬
    /// </summary>
    private Vector3 CreateDirection()
    {
        var hori = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");

        var dir = Vector3.right * hori + Vector3.forward * ver;

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        return dir;
    }
}
