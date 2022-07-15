using UnityEngine;

/// <summary>
/// èe
/// </summary>
public class WeponGun : MonoBehaviour
{
    [SerializeField]
    private BulletSpawner _spawner;

    [SerializeField]
    private Transform _gunStandartPoint;

    [SerializeField]
    private Transform _muzzleTransform;

    [SerializeField]
    private Camera _camera;

    private void Update()
    {
        UpdateGunRotation();
        Fire();
    }

    /// <summary>
    /// èeÇÃå¸Ç´ÇïœÇ¶ÇÈ
    /// </summary>
    private void UpdateGunRotation()
    {
        _gunStandartPoint.rotation = _camera.transform.rotation;
    }

    /// <summary>
    /// éÀåÇ
    /// </summary>
    private void Fire()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 100f))
        {
            Attack(hit);
        }
    }

    private void Attack(RaycastHit hit)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var go = _spawner.Get(_muzzleTransform.position);

            if (go.TryGetComponent(out IShootable shoot))
            {
                Shoot(hit, shoot);
            }
        }
    }

    private void Shoot(RaycastHit hit, IShootable shoot)
    {
        var forceDir = hit.point - _muzzleTransform.position;
        shoot.Shoot(forceDir, 5f);
    }
}
