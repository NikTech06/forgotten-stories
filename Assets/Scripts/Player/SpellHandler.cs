using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public bool timeReverse = false;

    void Update()
    {
        if(Input.GetButton("TimeReverse"))
        {
            timeReverse = true;
        } else
        {
            timeReverse = false;
        }
    }
}
