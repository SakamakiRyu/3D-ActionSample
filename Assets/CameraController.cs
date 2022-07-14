using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _cameraRotationLimitX;

    private void Update()
    {
        var Y = Input.GetAxis("Mouse Y") * -1;

        if (Y != 0)
        {
            _camera.transform.Rotate(Y, 0f, 0f);
        }
    }
}
