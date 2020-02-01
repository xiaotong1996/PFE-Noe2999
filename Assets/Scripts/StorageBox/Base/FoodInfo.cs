using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Debug.Log(hit.collider.name);

        Destroy(gameObject);
    }
}
