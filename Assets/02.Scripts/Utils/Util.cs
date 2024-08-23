using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자주 사용되는 특정 함수들을 모은 클래스

public class Util
{
    // 해당 컴포넌트를 가져오거나 없다면 추가하고 가져오는 기능
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform =  FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;

        return null;
    }
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        // 해당 부모 오브젝트의 자식만 탐색
        if(recursive == false)
        {
            for(int i =0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else // 해당 부모 오브젝트의 자식의 자식까지 전부 탐색
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}
