using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float _movingSpeed;

    [SerializeField]
    private float _lineLength;

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
    /// 歩く
    /// </summary>
    private void Walk()
    {
        var dir = CreateDirection();

        if (IsGrounded())
        {
            if (dir != Vector3.zero)
            {
                var velo = dir * _movingSpeed;
                _rb.velocity = velo;
            }
        }
    }

    /// <summary>
    /// 向きを変える
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
    /// 移動の方向ベクトルを作成
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

    /// <summary>
    /// 接地判定
    /// </summary>
    private bool IsGrounded()
    {
        var start = this.transform.position;
        var end = start + Vector3.down * _lineLength;
        return Physics.Linecast(start, end);
    }
}
