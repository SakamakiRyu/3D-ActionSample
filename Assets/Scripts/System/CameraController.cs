using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _minCameraVerticalAngle;

    [SerializeField]
    private float _maxCameraVerticalAngle;

    private void Update()
    {
        ChengeCameraView();
    }

    /// <summary>
    /// 入力によってカメラの向きを変える
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