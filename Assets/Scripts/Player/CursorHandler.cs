// ##############################
// #                            #
// #  (C) 2022 by Niklas Köppl  #
// #                            #
// ##############################
//
// This software is licensed under Mozilla Public License 2.0

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using Microsoft.Win32;
using TMPro;

public class CursorHandler : MonoBehaviour
{
    public bool HideAtStart = true;

    void Start()
    {
        if(HideAtStart)
        {
            Hide();
        }
    }

    public void Hide()
	{
        Cursor.lockState = CursorLockMode.Locked;
	}

    public void Show()
	{
        Cursor.lockState = CursorLockMode.Confined;
	}
}
