using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is to save the information for each food
/// </summary>
public class FoodInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        StorageBoxManager.Instance.StoreItem(Name);
       

        Destroy(gameObject);
    }
}
