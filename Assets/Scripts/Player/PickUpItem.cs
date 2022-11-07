//  (C) Niklas Köppl 2022
//  This code is licensed under Mozilla Public License 2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Rigidbody rb;

    void OnTriggerEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if(collidedObject.tag == "Player")
        {
            transform.SetParent(collidedObject.transform);
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.position = new Vector3(0f, 0f, 0f);
            rb.isKinematic = true;
        }
    }
}
