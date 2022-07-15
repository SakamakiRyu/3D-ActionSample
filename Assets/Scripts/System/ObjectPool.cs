using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// �ȈՓI�ȃI�u�W�F�N�g�v�[��
/// </summary>
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _pooledObject;

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private int _defaultCapacity = 10;

    private List<GameObject> Objects_list;

    private void Start()
    {
        CreatePool(_pooledObject, _parent, _defaultCapacity);
    }

    /// <summary>
    /// �v�[���̍쐬
    /// </summary>
    public void CreatePool(GameObject pooledObject, Transform parent, int capacity)
    {
        Objects_list = new List<GameObject>(capacity);

        for (int i = 0; i < capacity; i++)
        {
            var go = Instantiate(pooledObject, parent);
            go.SetActive(false);
            Objects_list.Add(go);
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g�̎擾
    /// </summary>
    public GameObject Get(Vector3 pos)
    {
        foreach (var item in Objects_list)
        {
            if (item.activeInHierarchy is false)
            {
                item.SetActive(true);
                item.transform.position = pos;
                return item;
            }
        }

        // �g�p�\�ȃI�u�W�F�N�g�����������ꍇ�͐�������
        var go = Instantiate(_pooledObject);
        go.transform.position = pos;
        Objects_list.Add(go);
        return go;
    }
}
