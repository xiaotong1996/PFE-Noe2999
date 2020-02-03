using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DontDestroy is used for SunBackground gameobject to keep it available in different screens.
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

}
