using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static bool _IsApplicationQuitting = false;
    private static object _lock = new object();

    public static T Instance()
    {
        if (_IsApplicationQuitting)
        {
            Debug.LogWarning("Singleton Instance of " + typeof(T) + " is already destroyed by the application");
            return null;
        }

        lock (_lock)
        {
            if (_instance == null)
            {
                //Check in scene if it exists
                _instance = FindObjectOfType(typeof(T)) as T;

                //If there are more, we got a problem
                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    Debug.LogError("More than one instance of singleton" + typeof(T));
                    return _instance;
                }

                //Still no instance, I need to create one
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).ToString());
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
        }

        return _instance;
    }

    protected Singleton()
    {
    }

    public void OnDestroy()
    {
        _IsApplicationQuitting = true;
    }
}