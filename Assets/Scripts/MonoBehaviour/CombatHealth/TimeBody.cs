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

    void Start()
    {
        positions = new List<Vector3>();
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
    }

    public void StopRewind()
    {
        isRewinding = false;
    }

    void Rewind()
    {
        transform.position = positions[0];
        positions.RemoveAt(0);
        transform.rotation = rotation[0];
        rotation.RemoveAt(0);
    }

    void Record()
    {
        positions.Insert(0, transform.position);
        rotation.Insert(0, transform.rotation);
    }
}
