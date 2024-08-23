using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    // 경로를 입력받아 해당 경로의 파일을 T타입으로 불러오는 메소드
    public T Load<T>(string path) where T : Object
    {
        // 만약 타입이 게임오브젝트일 경우
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

    // 경로를 입력받아 해당 경로의 게임오브젝트를 생성(선택: 부모)
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null) // Load에 실패하면 경로가 잘못 설정된 것이므로 오류 로그 출력
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // 풀링 대상일 경우
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        // 풀링 대상이 아닌 경우(카메라, UI 등)
        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null) // 풀링 대상일 경우
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
