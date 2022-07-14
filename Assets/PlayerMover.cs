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
    /// 歩く
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
    /// 向きを変える
    /// </summary>
    private void Look()
    {
        var input_x = Input.GetAxis("Mouse X");
        if (input_x != 0)
        {
            transform.Rotate(0f, input_x, 0f);
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
        // カメラを基準にする
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        return dir;
    }
}
