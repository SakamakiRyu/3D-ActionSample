using UnityEngine;

/// <summary>
/// çUåÇâ¬î\Ç»èe
/// </summary>
public class WeponGun : MonoBehaviour
{
    [SerializeField]
    private BulletSpawner _spawner;

    [SerializeField]
    private Transform _muzzleTransform;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var go = _spawner.Get(_muzzleTransform.position);
            go.TryGetComponent(out IShootable shoot);

            if (shoot is not null)
            {
                shoot.Shoot(_muzzleTransform.forward, 10f);
            }
        }
    }
}
