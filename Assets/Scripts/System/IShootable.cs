using UnityEngine;

/// <summary>
/// 射撃可能にする
/// </summary>
internal interface IShootable
{
    public void Shoot(Vector3 dir, float speed);
}