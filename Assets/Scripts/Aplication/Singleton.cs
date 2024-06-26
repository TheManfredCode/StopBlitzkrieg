using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool dontDestroy = false;

    protected static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();

                if (m_instance == null)
                {
                    var singleton = new GameObject(typeof(T).Name);
                    m_instance = singleton.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this as T;
            if (dontDestroy)
            {
                transform.parent = null;
                var go = gameObject;
                go.hideFlags = HideFlags.DontSave;
                DontDestroyOnLoad(go);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (m_instance == this as T)
            m_instance = null;
    }

}