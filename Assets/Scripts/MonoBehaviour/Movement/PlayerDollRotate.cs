using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDollRotate : MonoBehaviour
{

    public Transform player;

	/*
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);
        

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerDoll.Rotate(Vector3.up * mouseX * -1);
    }
    */

	private void Update()
	{
        player.transform.eulerAngles = new Vector3(0, 0, 0);/*new Vector3(
            player.transform.eulerAngles.x + transform.rotation.x,
            player.transform.eulerAngles.y,
            player.transform.eulerAngles.z
            );*/
	}
}
