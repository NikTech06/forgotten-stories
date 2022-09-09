using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryEnable : MonoBehaviour
{
    public GameObject inventory;

    public bool enabled = false;

    void Start()
    {
        inventory.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            enabled = !enabled;
            inventory.SetActive(enabled);
            Debug.Log("test");
        }
    }
}
