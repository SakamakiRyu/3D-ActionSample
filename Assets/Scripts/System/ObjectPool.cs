using System.Collections.Generic;
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
    private int _defaultCapacity;

    private List<GameObject> Objects_list;

    private void Start()
    {
        CreatePool(_pooledObject, _parent, _defaultCapacity);
    }

    /// <summary>
    /// �v�[���̍쐬
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
    /// �I�u�W�F�N�g�̎擾
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

        // �g�p�\�ȃI�u�W�F�N�g�����������ꍇ�͐�������
        var go = Instantiate(_pooledObject);
        go.transform.position = pos;
        Objects_list.Add(go);
        return go;
    }
}
