using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _cameraRotationLimitX;

    private void Update()
    {
        ChengeCameraView();
    }

    /// <summary>
    /// ���͂ɂ���ăJ�����̌�����ς���
    /// </summary>
    private void ChengeCameraView()
    {
        var inputY = Input.GetAxis("Mouse Y") * -1;

        if (inputY != 0)
        {
            _camera.transform.Rotate(inputY, 0f, 0f);
        }
    }
}
