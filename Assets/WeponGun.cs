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
        if (Input.GetButtonDown("Fire2"))
        {
            var go = _spawner.Get(_muzzleTransform.position);
            go.TryGetComponent<IShootable>(out var shoot);

            shoot.Shoot(Vector3.forward, 5f);
        }
    }
}
