using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    // ��θ� �Է¹޾� �ش� ����� ������ TŸ������ �ҷ����� �޼ҵ�
    public T Load<T>(string path) where T : Object
    {
        // ���� Ÿ���� ���ӿ�����Ʈ�� ���
        if(typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index > 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    // ��θ� �Է¹޾� �ش� ����� ���ӿ�����Ʈ�� ����(����: �θ�)
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null) // Load�� �����ϸ� ��ΰ� �߸� ������ ���̹Ƿ� ���� �α� ���
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // Ǯ�� ����� ���
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        // Ǯ�� ����� �ƴ� ���(ī�޶�, UI ��)
        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null) // Ǯ�� ����� ���
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
