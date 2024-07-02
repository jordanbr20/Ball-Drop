using UnityEngine;
using Steamworks;

public class SteamGameManager : MonoBehaviour
{
    private static SteamGameManager _instance;
    private bool _initialized;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        try
        {
            if (!SteamAPI.Init())
            {
                Debug.LogError("SteamAPI.Init() failed. Refer to Valve's documentation or the comment above this line for more information.");
                return;
            }
        }
        catch (System.DllNotFoundException e)
        {
            Debug.LogError(e);
            return;
        }

        _initialized = true;
    }

    void OnEnable()
    {
        if (_initialized)
        {
            SteamAPI.RunCallbacks();
        }
    }

    void OnDisable()
    {
        if (_initialized)
        {
            SteamAPI.Shutdown();
        }
    }
}
