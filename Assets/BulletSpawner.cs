using UnityEngine;

/// <summary>
/// �v�[������̎󂯓n���N���X
/// </summary>
public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private ObjectPool _bulletPool;

    public GameObject Get(Vector3 pos)
    {
        return _bulletPool.Get(pos);
    }
}