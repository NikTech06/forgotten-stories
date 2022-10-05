using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    //Must be on any object affected by time reverse spell

    public SpellHandler spellHandler;

    //[HideInInspector]
    public bool isRewinding = false;

    List<Vector3> positions;
    List<Quaternion> rotation;

    Rigidbody rb;

    public int maxFrames = 250;

    void Start()
    {
        positions = new List<Vector3>();
        rotation = new List<Quaternion>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(spellHandler.timeReverse)
        {
            StartRewind();
        } else
        {
            StopRewind();
        }

    }

    void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        } else
        {
            Record();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    void Rewind()
    {
        if(positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
            transform.rotation = rotation[0];
            rotation.RemoveAt(0);
        } else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if(positions.Count > maxFrames)
        {
            positions.RemoveAt(positions.Count - 1);
            rotation.RemoveAt(rotation.Count - 1);

        }

        positions.Insert(0, transform.position);
        rotation.Insert(0, transform.rotation);
    }
}
