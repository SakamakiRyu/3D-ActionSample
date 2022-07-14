using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 簡易的なオブジェクトプール
/// </summary>
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _pooledObject;

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private int _defaultCapacity;

    private List<GameObject> Objects_list;

    private void Start()
    {
        CreatePool(_pooledObject, _parent, _defaultCapacity);
    }

    /// <summary>
    /// プールの作成
    /// </summary>
    public void CreatePool(GameObject createObject, Transform parent, int capacity)
    {
        Objects_list = new List<GameObject>(capacity);

        for (int i = 0; i < Objects_list.Count; i++)
        {
            var obj = Instantiate(createObject, parent);
            obj.SetActive(false);
            Objects_list[i] = obj;
        }
    }

    /// <summary>
    /// オブジェクトの取得
    /// </summary>
    public GameObject Get(Vector3 pos)
    {
        foreach (var item in Objects_list)
        {
            if (item.activeSelf is false)
            {
                item.transform.position = pos;
                return item;
            }
        }

        // 使用可能なオブジェクトが無かった場合は生成する
        var go = Instantiate(_pooledObject);
        go.transform.position = pos;
        Objects_list.Add(go);
        return go;
    }
}
