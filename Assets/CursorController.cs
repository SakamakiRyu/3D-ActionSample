using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    private bool _hasCursorActive;

    private void Start()
    {
        Cursor.visible = _hasCursorActive;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
