using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Earth is used for Earth gameobject to keep it available in different screens.
/// </summary>
public class Earth : MonoBehaviour
{

    public static Earth Instance;

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
